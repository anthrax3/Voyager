using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace CMS.Core.Services.Implementations
{
    public class ConfigService : IConfigService
    {
        Dictionary<String, String> data = null;
        ILoggerService logger = null;

        public ConfigService(ILoggerService logger)
        {
            this.logger = logger;

            data = new Dictionary<string, string>();
        }

        public void Load(string file)
        {
            var xmlContent = new StreamReader(file).ReadToEnd();
            var xmlDocument = XDocument.Parse(xmlContent);
            var root = xmlDocument.Descendants("configuration");
            var items = root.Descendants("item");

            foreach(XElement element in items)
            {
                var key = element.Element("key").Value;
                var value = element.Element("value").Value;

                data.Add(key, value);
            }
        }

        public bool Exist(string key)
        {
            return data.Any(p => p.Key == key);
        }

        public string GetValue(string key)
        {
            if (!Exist(key))
                throw new KeyNotFoundException(key);
            return data.First(p => p.Key == key).Value;
        }
    }
}