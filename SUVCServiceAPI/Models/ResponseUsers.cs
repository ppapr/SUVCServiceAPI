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
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}