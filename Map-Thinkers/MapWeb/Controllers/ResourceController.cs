using MapDomain.Entities;
using MapService;
using MapWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class ResourceController : HomeController
    {
        // GET: Resource
        public ActionResult AllResources()
        {
            ServiceResource sr = new ServiceResource();
            var Resources = sr.GetMany(r => r.AccountType == "Ressource");
            return View(Resources);
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            User u = new User();
            ServiceResource Sr = new ServiceResource();
            RessourceViewModel rvm = new RessourceViewModel();
            u = Sr.GetById(id);
            rvm.Email = u.Email;
            rvm.Id = u.Id;
            rvm.PhoneNumber = u.PhoneNumber;
            rvm.AccountType = u.AccountType;
            rvm.UserName = u.UserName;


            //Sr.Delete(rvm);
            return View(rvm);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RessourceViewModel rvm)
        {
            User u = new User();
            ServiceResource Sr = new ServiceResource();
          
            u = Sr.GetById(id);
            u.UserName = rvm.UserName;
            u.PhoneNumber = rvm.PhoneNumber;
            u.Email = rvm.Email;
           Sr.Update(u);
            Sr.Commit();
            return RedirectToAction("AllResources");
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            User u = new User();
            
            ServiceResource Sr = new ServiceResource();
            RessourceViewModel rvm = new RessourceViewModel();  
            u = Sr.GetById(id);
            rvm.Email = u.Email;
            rvm.Id = u.Id;
            rvm.PhoneNumber = u.PhoneNumber;
            rvm.AccountType = u.AccountType;
            rvm.UserName = u.UserName;
            
            
        
        
            //Sr.Delete(rvm);
            return View(rvm);
        }

        // POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
            User u = new User();
            ServiceResource Sr = new ServiceResource();
            u = Sr.GetById(id);
            Sr.Delete(u);
            Sr.Commit();

            return RedirectToAction("AllResources");
            
          
         
        }

        public ActionResult CompleteProfile(int id)
        {
      //   public enum ContractType { Employee, Freelancer }
   // public enum WorkType { IT, HR, Finance, Administration }
        Ressource r = new Ressource();
            RessourceViewModel rvm = new RessourceViewModel();
            ServiceRessource sr = new ServiceRessource();
            Skills s = new Skills();
            ServiceSkills ser = new ServiceSkills();
           
            var nomskill = ser.GetMany();
            List<String> SkillsList = new List<string>();
            foreach (var item in nomskill)
            {
                SkillsList.Add(item.SkillName);
            }
            
            List<String> WType = (new List<String> { "IT", "HR", "Finance", "Administration" });
            List<String> CType = (new List<String> { "Employee", "Freelancer"});
            List<String> SType = (new List<String> { "Junior", "Senior" });

            ViewBag.list1 = WType;
            ViewBag.list2 = CType;
            ViewBag.list3 = SType;
            ViewBag.list4 = SkillsList;
            r = sr.GetById(id);
            rvm.UserName = r.UserName;
            rvm.AccountType = r.AccountType;
            rvm.Id = r.Id;
             rvm.ContractType = (MapWeb.Models.ContractType)r.ContractType;
            rvm.WorkType = (MapWeb.Models.WorkType)r.WorkType;

            return View(rvm);
        }
        [HttpPost]
        public ActionResult CompleteProfile(int id, RessourceViewModel rvm)
        {
            Ressource r = new Ressource();
           // RessourceViewModel rvm = new RessourceViewModel();
            ServiceRessource sr = new ServiceRessource();
            Skills s = new Skills();
            ServiceSkills ser = new ServiceSkills();
            ServiceSkillRessource skillressource = new ServiceSkillRessource();
            SkillRessource skr = new SkillRessource();
            var nomskill = ser.GetMany();
            List<String> SkillsList = new List<string>();
            foreach(var item in nomskill)
            {
                SkillsList.Add(item.SkillName);
            }
            
            List<String> WType = (new List<String> { "IT", "HR", "Finance", "Administration" });
            List<String> CType = (new List<String> { "Employee", "Freelancer" });
            List<String> SType = (new List<String> { "Junior", "Senior" });
            var x = ser.Get(t => t.SkillName == rvm.Skill);
            ViewBag.list1 = WType;
            ViewBag.list2 = CType;
            ViewBag.list3 = SType;
            ViewBag.list4 = SkillsList;
            skr.SkillRate = rvm.Note;
            skr.IdRessource = id;
            skr.IdSkill = x.SkillId;
            r = sr.GetById(id);
            r.WorkType = (MapDomain.Entities.WorkType)rvm.WorkType;
            r.ContractType= (MapDomain.Entities.ContractType)rvm.ContractType;
            sr.Update(r);
            sr.Commit();
            skillressource.Add(skr);
            skillressource.Commit();
            return RedirectToAction("AllResources");

        }
        public enum ContractType
        {
            Employee = 1,
            Freelancer = 2
        }
        public enum WorkType
        {
            IT = 1,
            HR = 2,
            Finance = 3,
            Administration =4    
            
        }
    }
}
