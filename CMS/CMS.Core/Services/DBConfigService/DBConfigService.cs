using CMS.Core.Services.LoggerService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CMS.Core.Services.ConfigService
{
    public class DBConfigService : IDBConfigService
    {
        Dictionary<String, String> data = null;
        ILoggerService logger = null;

        public DBConfigService(ILoggerService logger)
        {
            this.logger = logger;

            data = new Dictionary<string, string>();
        }

        /// <summary>
        /// Loads configuration data from file. Returns LoadResult.Success if there were no errors. 
        /// </summary>
        public LoadResult Load(string file)
        {
            if (!File.Exists(file))
                return LoadResult.FileNotFound;

            var xmlContent = new StreamReader(file).ReadToEnd();

            XDocument xmlDocument = null;
            try
            {
                xmlDocument = XDocument.Parse(xmlContent);
            }
            catch(Exception ex)
            {
                logger.Log(Level.Error, ex);
                return LoadResult.ParseError;
            }

            if (!xmlDocument.Elements("configuration").Any())
                return LoadResult.IncorrectStructure;
            var root = xmlDocument.Descendants("configuration");

            var items = root.Elements();
            if (items.Any(p => p.Name != "item"))
                return LoadResult.IncorrectStructure;

            foreach (XElement e in items)
            {
                if (!e.Elements("key").Any() || !e.Elements("value").Any())
                {
                    data.Clear();
                    return LoadResult.IncorrectStructure;
                }

                var key = e.Element("key").Value;
                var value = e.Element("value").Value;

                data.Add(key, value);
            }
            
            return LoadResult.Success;
        }

        /// <summary>
        /// Returns true if key exist.
        /// </summary>
        public bool Exist(string key)
        {
            return data.Any(p => p.Key == key);
        }

        /// <summary>
        /// Returns value of specific key or null if key not exist.
        /// </summary>
        public string GetValue(string key)
        {
            return data.FirstOrDefault(p => p.Key == key).Value;
        }
    }
}