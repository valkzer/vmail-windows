using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vmail.Util;

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
    }
}
