using System;

namespace CleanArchitecturePoc.Models
{
    public class EnrollmentModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}