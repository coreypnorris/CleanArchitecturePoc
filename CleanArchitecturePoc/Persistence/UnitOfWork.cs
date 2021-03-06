﻿using CleanArchitecturePoc.Core;
using CleanArchitecturePoc.Core.Models;
using CleanArchitecturePoc.Core.RepositoryInterfaces;
using CleanArchitecturePoc.Persistence.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CleanArchitecturePoc.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISchemaRepository SchemaContext {get; private set;}
        public IUserRepository Users { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IEnrollmentRepository Enrollments { get; private set; }

        public UnitOfWork(SchemaModel schemaModel)
        {
            SchemaContext = new SchemaRepository();
            Users = new UserRepository(SchemaContext.Schema());
            Courses = new CourseRepository(SchemaContext.Schema());
            Enrollments = new EnrollmentRepository(SchemaContext.Schema());
        }

        public void Complete()
        {
            string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\schema.json");
            using (StreamWriter file = File.CreateText(jsonFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, SchemaContext.Schema());
            }
        }
    }
}