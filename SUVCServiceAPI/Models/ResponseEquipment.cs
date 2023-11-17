using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUVCServiceAPI.Entities;

namespace SUVCServiceAPI.Models
{
    public class ResponseEquipment
    {
        public ResponseEquipment(Equipment equipment) { 
            ID=equipment.ID;
            EquipmentName=equipment.EquipmentName;
            EquipmentDescription=equipment.EquipmentDescription;
            NetworkName=equipment.NetworkName;
            InventoryName=equipment.InventoryName;
            OwnerName = equipment.Users.FullName;
            StatusName = equipment.StatusEquipment.NameStatus;
            Location = equipment.LocationAuditorium.ToString();
        }
        public int ID { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public string NetworkName { get; set; }
        public string InventoryName { get; set; }
        public string OwnerName { get; set; }
        public string StatusName { get; set; }
        public string Location { get; set; }

    }
}