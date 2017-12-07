using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using vmail.Util;
using Windows.UI.Xaml.Controls;

namespace vmail.Models
{
    class EmailAddress
    {
        public String id { set; get; }
        public String email { set; get; }

        public EmailAddress()
        {
        }

        public EmailAddress(String id, String email)
        {
            this.id = id;
            this.email = email;
        }

        public async Task save()
        {
            await AzureHelper.emailAddressTable.InsertAsync(this);
        }

        internal static async Task<MobileServiceCollection<EmailAddress, EmailAddress>> getAll()
        {
            MobileServiceCollection<EmailAddress, EmailAddress> items;
            items = await AzureHelper.emailAddressTable
                    .ToCollectionAsync();
            return items;
        }
    }
}
