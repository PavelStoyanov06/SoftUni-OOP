﻿using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users = new List<IUser>();

        public UserRepository()
        {
            this.users = new List<IUser>();
        }

        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return users.FirstOrDefault(x => x.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return users;
        }

        public bool RemoveById(string identifier)
        {
            return users.Remove(FindById(identifier));
        }
    }
}