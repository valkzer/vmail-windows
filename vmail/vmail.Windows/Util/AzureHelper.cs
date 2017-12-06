using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace vmail.Util
{
    class AzureHelper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://isw-1313.azurewebsites.net");
    }
}
