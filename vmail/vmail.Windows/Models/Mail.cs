using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmail.Models
{
    class Mail
    {
        private String id;
        private String subject;
        private String to;
        private String from;
        private String message;
        private Boolean read;

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

        public String getId()
        {
            return id;
        }

        public Mail setId(String id)
        {
            this.id = id;
            return this;
        }

        public String getSubject()
        {
            return subject;
        }

        public Mail setSubject(String subject)
        {
            this.subject = subject;
            return this;
        }

        public String getTo()
        {
            return to;
        }

        public Mail setTo(String to)
        {
            this.to = to;
            return this;
        }

        public String getFrom()
        {
            return from;
        }

        public Mail setFrom(String from)
        {
            this.from = from;
            return this;
        }

        public String getMessage()
        {
            return message;
        }

        public Mail setMessage(String message)
        {
            this.message = message;
            return this;
        }

        public Boolean getRead()
        {
            return read;
        }

        public Mail setRead(Boolean read)
        {
            this.read = read;
            return this;
        }
    }
}
