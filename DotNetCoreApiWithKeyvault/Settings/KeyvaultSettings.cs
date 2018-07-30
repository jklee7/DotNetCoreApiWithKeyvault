using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApiWithKeyvault.Settings
{
    public class KeyvaultSettings
    {
        public string Uri { get; set; }
        public string AppId { get; set; }
        public string Secret { get; set; }
    }
}
