using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<EnrollmentModel> Enrollments { get; set; }
    }
}