using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmail.Models
{
    class EmailAddress
    {
        private String id;
        private String email;

        public EmailAddress()
        {
        }

        public EmailAddress(String id, String email)
        {
            this.id = id;
            this.email = email;
        }

        public String getId()
        {
            return id;
        }

        public EmailAddress setId(String id)
        {
            this.id = id;
            return this;
        }

        public String getEmail()
        {
            return email;
        }

        public EmailAddress setEmail(String email)
        {
            this.email = email;
            return this;
        }
    }
}
