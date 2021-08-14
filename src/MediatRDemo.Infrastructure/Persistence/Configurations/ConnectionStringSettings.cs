using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRDemo.Infrastructure.Persistence.Configurations
{
    public class ConnectionStringSettings
    {
        public const string Section = "ConnectionStrings";
        public string Database { get; set; }
        public string Master { get; set; }
    }
}
