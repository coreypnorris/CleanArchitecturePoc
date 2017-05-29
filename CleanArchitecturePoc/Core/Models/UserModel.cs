using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace CleanArchitecturePoc.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<EnrollmentModel> Enrollments { get; set; }
    }
}