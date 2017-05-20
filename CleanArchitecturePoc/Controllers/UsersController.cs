﻿using CleanArchitecturePoc.Models;
using CleanArchitecturePoc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CleanArchitecturePoc.Controllers
{
    public class UsersController : ApiController
    {
        private readonly string _context;
        private readonly UserRepository _userRepository;

        public UsersController()
        {
            _context = AppDomain.CurrentDomain.BaseDirectory.ToString();
            _userRepository = new UserRepository(_context);
        }

        public List<UserModel> Get()
        {
            return _userRepository.GetUsers().ToList();
        }
    }
}