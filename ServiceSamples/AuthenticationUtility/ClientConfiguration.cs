using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUtility
{
    public partial class ClientConfiguration
    {
        //public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        /*public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            UriString = "https://usnconeboxax1aos.cloud.onebox.dynamics.com/",
            UserName = "",
            Password = "",
            ActiveDirectoryResource = "https://usnconeboxax1aos.cloud.onebox.dynamics.com",
            ActiveDirectoryTenant = "https://raikesdesignstudio.onmicrosoft.com/",
            ActiveDirectoryClientAppId = "0ad95f25-12af-4bf2-9e3b-26e34747fcf1",
            //ActiveDirectoryClientAppSecret = "luveHIRZ6390$edpIBT2)*!",
            ActiveDirectoryClientAppSecret = "lBJGr1Rkmo95KgIWofyU/4TR/Sk1x3TUt90ak5eaUUs=",
        };*/

        public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            UriString = "https://usnconeboxax1aos.cloud.onebox.dynamics.com/",
            UserName = "",
            Password = "",
            ActiveDirectoryResource = "https://usnconeboxax1aos.cloud.onebox.dynamics.com",
            ActiveDirectoryTenant = "raikesdesignstudio.onmicrosoft.com",
            ActiveDirectoryClientAppId = "0ad95f25-12af-4bf2-9e3b-26e34747fcf1",
            //ActiveDirectoryClientAppId = "d8da61f7-f80e-4cf4-b7c2-85324dce4eb5",
            //ActiveDirectoryClientAppId = "d8192dda-bb8a-4bd5-8262-48c789201381",
            AADClientSecret = "",
            AzureAuthEndPoint = "https://login.windows.net",
        };

        public string UriString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public String ActiveDirectoryTenant { get; set; }
        public String ActiveDirectoryClientAppId { get; set; }
        public string AADClientSecret { get; set; }
        public string AzureAuthEndPoint { get; set; }
    }
}
