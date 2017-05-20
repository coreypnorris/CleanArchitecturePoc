using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CleanArchitecturePoc.Controllers
{
    public class NotesController : ApiController
    {
        private readonly string _context;
        private readonly NoteRepository _noteRepository;

        public NotesController()
        {
            _context = AppDomain.CurrentDomain.BaseDirectory.ToString();
            _noteRepository = new NoteRepository(_context);
        }

        public List<NoteModel> GetNotes()
        {
            return _noteRepository.GetNotes().ToList();
        }
    }
}
