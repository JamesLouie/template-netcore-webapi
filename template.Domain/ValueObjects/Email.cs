using System;

namespace template.Domain.ValueObjects
{
    public class Email
    {
        public string CompleteEmailAddress { get; private set; }
        public string LocalName { get; private set; }
        public string DomainAddress { get; private set; }

        public Email(string emailAddress)
        {
            CompleteEmailAddress = emailAddress;

            if (!emailAddress.Contains("@"))
                throw new ArgumentException("Invalid email address format");

            var emailComponents = emailAddress.Split('@');
            LocalName = emailComponents[0];
            DomainAddress = emailComponents[1];
        }
    }
}
