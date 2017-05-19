using CleanArchitecturePoc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Repositories
{
    public class UserRepository
    {
        private readonly string _context;

        public UserRepository(string context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            List<UserModel> users;
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\users.json");
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string json = reader.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<UserModel>>(json);
            }
            return users;
        }
    }
}