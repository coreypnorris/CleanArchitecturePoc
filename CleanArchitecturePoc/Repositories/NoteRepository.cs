using CleanArchitecturePoc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Repositories
{
    public class NoteRepository
    {
        private readonly string _context;

        public NoteRepository(string context)
        {
            _context = context;
        }

        public IEnumerable<NoteModel> GetNotes()
        {
            List<NoteModel> notes;
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\notes.json");
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                string json = reader.ReadToEnd();
                notes = JsonConvert.DeserializeObject<List<NoteModel>>(json);
            }
            return notes;
        }
    }
}