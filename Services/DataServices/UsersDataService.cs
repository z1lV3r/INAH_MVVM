using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Exceptions;
using INAH.Models;

namespace INAH.Services.DataServices
{
    public class UsersDataService
    {
        public void Upsert(Users user)
        {
            using (var dataEntities = new TempDataEntities())
            {
                var local = dataEntities.Users.FirstOrDefault(u => u.Email == user.Email) ?? new Users();
                local.Email = user.Email;
                local.Password = user.Password;
                local.Name = user.Name;
                local.Role = user.Role;
                if (local.Id == default) dataEntities.Users.Add(local);
                dataEntities.SaveChanges();
            }
        }

        public Users Find(Users user)
        {
            using (var dataEntities = new TempDataEntities())
            {
                return dataEntities.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            }
        }
    }
}
