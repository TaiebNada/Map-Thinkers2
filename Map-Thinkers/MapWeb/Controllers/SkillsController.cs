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
    public class SkillsController : HomeController
    {
        // GET: Skills
        public ActionResult AllSkills()

        {
            ServiceSkills sk = new ServiceSkills();
            var skills=sk.GetMany();
            return View(skills);
        }

        // GET: Skills/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        public ActionResult Create(SkillsViewModel svm)
        {
            Skills sk = new Skills();
            ServiceSkills skill = new ServiceSkills();
            sk.SkillDescription = svm.SkillDescription;
            sk.SkillName = svm.SkillName;
          //  sk.SkillRate = svm.SkillRate;
            skill.Add(sk);
            skill.Commit();
            return RedirectToAction("AllSkills");
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            SkillsViewModel svm = new SkillsViewModel();
            Skills skill= new Skills();
            ServiceSkills sk = new ServiceSkills();
            skill = sk.GetById(id);
            svm.SkillName = skill.SkillName;
            svm.SkillDescription = skill.SkillDescription;
           // svm.SkillRate = skill.SkillRate;
            return View(svm);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SkillsViewModel svm)
        {
            
            Skills sk = new Skills();
            ServiceSkills service = new ServiceSkills();
            sk = service.GetById(id);
         //   sk.SkillRate = svm.SkillRate;
            sk.SkillName = svm.SkillName;
            sk.SkillDescription = svm.SkillDescription;
            service.Update(sk);
            service.Commit();
            return RedirectToAction("AllSkills");

        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int id, SkillsViewModel svm)
        {
            Skills skill = new Skills();
            ServiceSkills sk = new ServiceSkills();
            skill = sk.GetById(id);
            //svm.SkillRate = skill.SkillRate;
            svm.SkillName = skill.SkillName;
            svm.SkillDescription = skill.SkillDescription;
            return View(svm);
            
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Skills sk = new Skills();
            ServiceSkills service = new ServiceSkills();
            sk = service.GetById(id);
            service.Delete(sk);
            service.Commit();
            return RedirectToAction("AllSkills");
        }
    }
}
