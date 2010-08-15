using System;

namespace Scrumr.Domain
{
    public class EmailAddress
    {
        private readonly string _value;

        public EmailAddress(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
