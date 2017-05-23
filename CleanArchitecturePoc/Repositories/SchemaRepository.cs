using CleanArchitecturePoc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Repositories
{
    public class SchemaRepository
    {
        private readonly SchemaModel _schema;

        public SchemaRepository()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\schema.json");
            SchemaModel schema;
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                var data = reader.ReadToEnd();
                schema = JsonConvert.DeserializeObject<SchemaModel>(data);
            }
            _schema = schema;
        }

        public SchemaModel GetSchema()
        {
            return _schema;
        }
    }
}