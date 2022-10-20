using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public class ConfigService : IConfigService
    {
        public string GetValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
