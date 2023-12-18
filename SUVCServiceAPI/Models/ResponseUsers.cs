using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUVCServiceAPI.Entities;

namespace SUVCServiceAPI.Models
{
    public class ResponseUsers
    {
        public ResponseUsers(Users users)
        {
            ID = users.ID;
            Name = users.Name;
            Surname = users.Surname;
            MiddleName = users.MiddleName;
            Login = users.Login;
            Password = users.Password;
            Role = users.Roles.RoleName;
            FullName = users.FullName;
            IDRole = users.Roles.ID;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public int IDRole { get; set; }

    }
}