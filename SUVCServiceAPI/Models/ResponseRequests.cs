using SUVCServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUVCServiceAPI.Models
{
    public class ResponseRequests
    {
        public ResponseRequests(Requests requests)
        {
            ID = requests.ID;
            Description = requests.Description;
            DateCreateRequest = requests.DateCreateRequest;
            DateExecuteRequest = (DateTime)requests.DateExecuteRequest;
            UserRequestName = requests.Users1.FullName;
            UserExecutorName = requests.Users.FullName;
            PriorityName = requests.PriorityRequest.NamePriority;
            EquipmentName = requests.Equipment.EquipmentName + " " + requests.Equipment.NetworkName;
            StatusName = requests.StatusRequest.StatusName;
            EquipmentID = requests.IDEquipment;
            PriorityID = requests.IDPriority;
            StatusID = requests.IDStatus;
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime DateCreateRequest { get; set; }
        public DateTime DateExecuteRequest { get; set; }
        public string UserRequestName { get; set; }
        public string UserExecutorName { get; set; }
        public string StatusName { get; set; }
        public string PriorityName { get; set; }
        public string EquipmentName { get; set; }
        public int EquipmentID { get; set; }
        public int PriorityID { get; set; }
        public int StatusID { get; set; }
    }
}