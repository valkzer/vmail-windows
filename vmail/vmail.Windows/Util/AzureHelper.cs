using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using vmail.Models;

namespace vmail.Util
{
    class AzureHelper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://isw-1313.azurewebsites.net");
        public static IMobileServiceTable<EmailAddress> emailAddressTable = MobileService.GetTable<EmailAddress>();
        public static IMobileServiceTable<Mail> mailTable = MobileService.GetTable<Mail>();
        
    }
}