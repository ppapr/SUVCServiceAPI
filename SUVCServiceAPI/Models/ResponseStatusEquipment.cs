using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUVCServiceAPI.Entities;

namespace SUVCServiceAPI.Models
{
    public class ResponseStatusEquipment
    {
        public ResponseStatusEquipment(StatusEquipment statusEquipment)
        {
            ID = statusEquipment.ID;
            NameStatus = statusEquipment.NameStatus;
        }

        public int ID { get; set; }
        public string NameStatus { get; set; }
    }
}