using CMS.Core.Database;
using CMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Core.Services.ConfigService
{
    public class ConfigService : IConfigService
    {
        IDatabaseContext db = null;

        public ConfigService(IDatabaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Adds record to configuration table. Returns false if key already exist.
        /// </summary>
        public bool AddKey(string key, string value)
        {
            if (Exist(key))
                return false;

            var newKey = new ConfigModel()
            {
                Key = key,
                Value = value
            };

            db.Set<ConfigModel>().Add(newKey);
            db.Save();

            return true;
        }

        /// <summary>
        /// Returns value of specific key. Returns null if key not exist.
        /// </summary>
        public string GetValue(string key)
        {
            if (!Exist(key))
                return null;
            return db.Set<ConfigModel>().First(p => p.Key == key).Value;
        }

        /// <summary>
        /// Removes key from configuration table. Returns false if key not exist.
        /// </summary>
        public bool RemoveKey(string key)
        {
            if (!Exist(key))
                return false;

            var entity = db.Set<ConfigModel>().First(p => p.Key == key);
            db.Set<ConfigModel>().Remove(entity);
            db.Save();

            return true;
        }

        /// <summary>
        /// Sets value of specific key. Returns false if key not exist.
        /// </summary>
        public bool SetValue(string key, string value)
        {
            if (!Exist(key))
                return false;

            var entity = db.Set<ConfigModel>().First(p => p.Key == key);
            entity.Value = value;
            db.Save();

            return true;
        }

        /// <summary>
        /// Returns true if key exist
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exist(string key)
        {
            return db.Set<ConfigModel>().Any(p => p.Key == key);
        }
    }
}