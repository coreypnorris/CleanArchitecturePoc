using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Persistence
{
    public class UnitOfWork
    {
        private readonly SchemaModel _context;
        public UserRepository Users { get; private set; }
        public CourseRepository Courses { get; private set; }
        public EnrollmentRepository Enrollments { get; private set; }

        public UnitOfWork(SchemaModel context)
        {
            _context = context;
            Users = new UserRepository(context);
            Courses = new CourseRepository(context);
            Enrollments = new EnrollmentRepository(context);
        }

        public void Complete()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\schema.json");
            using (StreamWriter file = File.CreateText(jsonFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _context);
            }
        }
    }
}