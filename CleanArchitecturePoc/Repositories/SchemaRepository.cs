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
        private readonly SchemaModel _context;

        public SchemaRepository()
        {
            SchemaModel schema;
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\schema.json");
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                var data = reader.ReadToEnd();
                schema = JsonConvert.DeserializeObject<SchemaModel>(data);
            }
            _context = schema;
        }

        public SchemaModel GetSchema()
        {
            return _context;
        }
    }
}