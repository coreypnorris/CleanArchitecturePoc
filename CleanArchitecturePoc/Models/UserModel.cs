using System.Collections;
using System.Collections.Generic;

namespace CleanArchitecturePoc.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<NoteModel> Notes { get; set; }
    }
}