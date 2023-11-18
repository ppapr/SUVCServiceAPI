using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUVCServiceAPI.Entities;

namespace SUVCServiceAPI.Models
{
    public class ResponseSpares
    {
        public ResponseSpares(SparesEquipment spare) {
            ID = spare.ID;
            SpareName = spare.SpareName;
            Equipment = spare.Equipment.EquipmentName + " " + spare.Equipment.InventoryName + " " + spare.Equipment.NetworkName;
        }
        public int ID { get; set; }
        public string SpareName { get; set; }
        public string Equipment { get; set; }
    }
}