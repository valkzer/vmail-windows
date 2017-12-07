using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using vmail.Util;

namespace vmail.Models
{
    class Mail
    {
        public String id { set; get; }
        public String subject { set; get; }
        public String to { set; get; }
        public String from { set; get; }
        public String message { set; get; }
        public Boolean read { set; get; }

        public Mail()
        {
            this.read = false;
        }

        public Mail(String id, String subject, String to, String from, String body, Boolean read)
        {
            this.id = id;
            this.subject = subject;
            this.to = to;
            this.from = from;
            this.message = body;
            this.read = read;
        }

        public static async Task<MobileServiceCollection<Mail, Mail>> getUnreadMail(EmailAddress emailAddress)
        {
            MobileServiceCollection<Mail, Mail> items;
            items = await AzureHelper.mailTable
                    .Where(Mail => Mail.read == false)
                    .Where(Mail => Mail.to == emailAddress.email)
                    .ToCollectionAsync();
            return items;
        }

        public static async Task<MobileServiceCollection<Mail, Mail>> getReadMail(EmailAddress emailAddress)
        {
            MobileServiceCollection<Mail, Mail> items;
            items = await AzureHelper.mailTable
                    .Where(Mail => Mail.read == true)
                    .Where(Mail => Mail.to == emailAddress.email)
                    .ToCollectionAsync();
            return items;
        }

        public async void markAsRead()
        {
            this.read = true;
            await AzureHelper.mailTable.UpdateAsync(this);
        }

        public async Task save()
        {
            await AzureHelper.mailTable.InsertAsync(this);
        }
    }
}
