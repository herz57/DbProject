using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Options
{
    public class EncryptionOptions
    {
        public const string Encryption = "Encryption";

        public string Key { get; set; }
        public string IV { get; set; }
    }
}
