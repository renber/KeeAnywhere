using KeeAnywhere.Configuration;
using SeafClient;
using SeafClient.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeeAnywhere.StorageProviders.Seafile
{
    public class SeafileStorageProvider : IStorageProvider
    {
        private readonly AccountConfiguration account;
        private SeafSession _session;
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public SeafileStorageProvider(AccountConfiguration account)
        {
            this.account = account;            
        }

        protected async Task<SeafSession> GetSession()
        {
            try
            {
                await semaphore.WaitAsync();

                if (_session == null)                
                    _session = await SeafSession.Establish(new Uri(account.AdditionalSettings["Server"]), account.AdditionalSettings["Username"], "test123".ToCharArray());                

                return _session;
            }
            finally
            {
                semaphore.Release();
            }            
        }

        public async Task<IEnumerable<StorageProviderItem>> GetChildrenByParentItem(StorageProviderItem parent)
        {
            var session = await GetSession();
            if (String.IsNullOrEmpty(parent.Id))
            {
                // list libraries as folders
                var libs = await session.ListLibraries();
                var sharedLibs = await session.ListSharedLibraries();

                return libs.Union(sharedLibs).Select(x =>
                {
                    var spi = new StorageProviderItem()
                    {
                        Type = StorageProviderItemType.Folder,
                        ParentReferenceId = parent.Id,
                        Id = x.Id,
                        LastModifiedDateTime = x.Timestamp
                    };

                    if (x.Owner != session.Username)
                            // library shared by a different user
                            spi.Name = "{" + x.Owner + "}" + x.Name;
                    else
                            // self-owned library
                            spi.Name = x.Name;

                    return spi;
                });
            }
            else
            {
                // first path part is the library
                // followed by the path
                string libId, path;
                int slashPos = parent.Id.IndexOf("/");
                if (slashPos == -1)
                {
                    // root directory of the library
                    libId = parent.Id;
                    path = "/";
                }
                else
                {
                    libId = parent.Id.Substring(0, slashPos);
                    path = parent.Id.Substring(slashPos);
                }

                var lib = await SeafileHelper.GetLibraryById(session, libId);
                if (lib != null)
                {
                    var dir = await session.ListDirectory(lib, path);
                    return dir.Select(x => new StorageProviderItem()
                    {
                        Type = x.Type == DirEntryType.Dir ? StorageProviderItemType.Folder : StorageProviderItemType.File,
                        ParentReferenceId = parent.Id,
                        Id = lib.Id + "/" + x.Path,
                        Name = x.Name,
                        LastModifiedDateTime = x.Timestamp
                    });
                }
            }

            return new List<StorageProviderItem>(0);
        }

        public async Task<StorageProviderItem> GetRootItem()
        {
            return new StorageProviderItem() { Type = StorageProviderItemType.Folder, ParentReferenceId = null, Id = "", Name = "root", LastModifiedDateTime = null };
        }

        public bool IsFilenameValid(string filename)
        {
            if (string.IsNullOrEmpty(filename)) return false;

            char[] invalidChars = { '<', '>', '/', '\\', ':', '*', '?', '"', '|' };
            return filename.All(c => c >= 32 && !invalidChars.Contains(c));
        }

        public async Task<Stream> Load(string path)
        {
            string libName, libPath;
            SeafileHelper.SplitLibraryPath(path, out libName, out libPath);

            var session = await GetSession();
            // path does not use the library id, but the name
            var lib = await SeafileHelper.GetLibraryByName(session, libName);
            if (lib != null)
            {
                string fileUri = await session.GetFileDownloadLink(lib, libPath);                

                using (HttpClient client = new HttpClient())
                {                    
                    // HttpClient.GetStreamAsync seems to have some problems (prematurely closing the stream)
                    // when using it, KeePass reports that the file would be corrupted
                    byte[] data = await client.GetByteArrayAsync(fileUri);                    
                    return new MemoryStream(data);
                }
            }
            else
                return null;
        }

        public async Task<bool> Save(Stream stream, string path)
        {
            string libName, libPath;
            SeafileHelper.SplitLibraryPath(path, out libName, out libPath);

            var session = await GetSession();
            // path does not use the library id, but the name
            var lib = await SeafileHelper.GetLibraryByName(session, libName);
            if (lib != null)
            {                
                string targetDir = libPath.Remove(libPath.LastIndexOf('/') + 1);
                string targetFilename = Path.GetFileName(libPath);                

                return await session.UpdateSingle(lib, targetDir, targetFilename, stream, (v) => { /* hide progress */ });                                
            }
            else
                return false;
        }
    }
}
