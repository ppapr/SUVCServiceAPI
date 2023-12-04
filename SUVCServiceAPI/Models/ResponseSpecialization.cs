using SUVCServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUVCServiceAPI.Models
{
    public class ResponseSpecialization
    {
        public ResponseSpecialization(Specialization specialization)
        {
            ID = specialization.ID;
            NameSpecialization = specialization.NameSpecialization;
        }
        public int ID { get; set; }
        public string NameSpecialization { get; set; }
    }
}