using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vmail.Models;

namespace vmail
{
    class SessionHelper
    {

        private static Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public static EmailAddress getCurrentEmailAddress()
        {
            string email = (String)localSettings.Values["currentUserEmailAddressEmail"];
            string id = (String)localSettings.Values["currentUserEmailAddressId"];
            bool isEmailRegistered = email != null && id != null;

            if (isEmailRegistered)
            {
                return new EmailAddress(id, email);
            }
            else
            {
                return null;
            }
        }

        public static void setCurrentEmailAddress(EmailAddress emailAddress)
        {
            localSettings.Values["currentUserEmailAddressEmail"] = emailAddress.email;
            localSettings.Values["currentUserEmailAddressId"] = emailAddress.id;
        }
    }
}
