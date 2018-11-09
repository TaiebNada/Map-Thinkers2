using MapDomain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;    

using System.Text;
using System.Threading.Tasks;
using static MapDomain.Entities.User;

namespace MapData
{
    public class MapContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public MapContext() : base("Map")
        {
         



        }

        public static MapContext Create()
        {
            return new MapContext();
        }
        static MapContext()
        {
            Database.SetInitializer<MapContext>(null);
        }

        //public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<DayOff> DayOff { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<InterMandate> InterMandate { get; set; }
        public DbSet<JobRequest> JobRequest { get; set; }
        public DbSet<Mandate> Mandate { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Organigram> Organigram { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Folder> Folder { get; set; }



    }

    public class ContexInit : DropCreateDatabaseIfModelChanges<MapContext>
    {
        protected override void Seed(MapContext context)
        {
            /*   List<Patient> patients = new List<Patient>() {
                   new Patient {PatientId=1
                               }

               };
               context.Patients.AddRange(patients);
               context.SaveChanges();*/
        }
    }


}

