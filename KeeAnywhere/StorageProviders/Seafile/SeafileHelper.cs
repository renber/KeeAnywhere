using SeafClient;
using SeafClient.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeAnywhere.StorageProviders.Seafile
{
    public static class SeafileHelper
    {

        /// <summary>
        /// Splits a seafile path into library part and file part
        /// </summary>
        public static void SplitLibraryPath(string path, out string libName, out string entryPath)
        {
            int slashPos = path.IndexOf("/");
            if (slashPos == -1)
            {
                // root directory of the library
                libName = path;
                entryPath = "/";
            }
            else
            {
                libName = path.Substring(0, slashPos);
                entryPath = path.Substring(slashPos);
            }
        }

        public static async Task<SeafLibrary> GetLibraryById(SeafSession session, String libraryId)
        {
            var libs = await session.ListLibraries();
            var lib = libs.FirstOrDefault(x => x.Id == libraryId);
            if (lib != null)
                return lib;

            var sharedLibs = await session.ListSharedLibraries();
            return sharedLibs.FirstOrDefault(x => x.Id == libraryId);
        }

        public static async Task<SeafLibrary> GetLibraryByName(SeafSession session, String libraryName)
        {
            var libs = await session.ListLibraries();
            var sharedLibs = await session.ListSharedLibraries();

            var allLibs = libs.Union(sharedLibs);

            if (libraryName.StartsWith("{"))
            {
                // library name is prepended by the owner
                int closingBraceIdx = libraryName.IndexOf("}");
                string owner = libraryName.Substring(1, closingBraceIdx - 2);
                libraryName = libraryName.Substring(closingBraceIdx + 1);
                
                return sharedLibs.FirstOrDefault(x => x.Name == libraryName && x.Owner == owner);
            } else
            {                
                return libs.FirstOrDefault(x => x.Name == libraryName);
            }
        }

    }
}
