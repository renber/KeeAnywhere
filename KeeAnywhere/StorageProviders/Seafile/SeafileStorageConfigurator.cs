using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeeAnywhere.Configuration;
using KeePass.UI;
using System.Windows.Forms;

namespace KeeAnywhere.StorageProviders.Seafile
{
    public class SeafileStorageConfigurator : IStorageConfigurator
    {
        public async Task<AccountConfiguration> CreateAccount()
        {            
            var dlg = new SeafileAccountForm();
            var result = UIUtil.ShowDialogAndDestroy(dlg);

            if (result != DialogResult.OK)
                return null;

            var account = new AccountConfiguration
            {
                Type = StorageType.Seafile,
                Id = dlg.Server,
                Name = dlg.Username,
                Secret = "<not required>"
            };

            account.AdditionalSettings = new Dictionary<string, string>() { { "Server", dlg.Server }, { "Username", dlg.Username } };            

            return account;
        }
    }
}
