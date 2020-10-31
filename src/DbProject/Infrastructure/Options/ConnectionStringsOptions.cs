using System;
using System.Collections.Generic;
using System.Text;

namespace DbProject.Infrastructure.Options
{
    public class ConnectionStringsOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";

        public string AppConnection { get; set; }
    }
}
