using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUVCServiceAPI.Entities;

namespace SUVCServiceAPI.Models
{
    public class ResponseRegistry
    {
        public ResponseRegistry(RegistryPrograms registry)
        {
            ID = registry.ID;
            NameProgram = registry.NameProgram;
            VersionProgram  = registry.VersionProgram;
            DescriptionProgram = registry.DescriptionProgram;
            Specialization = registry.Specialization.NameSpecialization;
            IDSpecialization = registry.Specialization.ID;
        }
        public int ID { get; set; }
        public string NameProgram { get; set; }
        public string VersionProgram { get; set; }
        public string DescriptionProgram { get; set; }
        public string Specialization { get; set; }
        public int IDSpecialization { get; set; }
    }
}