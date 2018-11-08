using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDomain.Entities
{
    public enum ClientType { CurrentClient, NewClient, ContractAdded }
    public enum ClientCategory { Private, Public }
    public class Client : User
    {
      
        public string Name { get; set; }
       
   
        public string Adress { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public int NbProjects { get; set; }
        public int NbRessources { get; set; }
        public ClientType ClientType { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
