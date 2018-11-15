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
    public class SkillRessourcesController : HomeController
    {
        // GET: SkillRessources
        public ActionResult Affect()
        {
            ServiceSkillRessource s = new ServiceSkillRessource();
            ServiceResource ressource = new ServiceResource();
            ServiceSkills skill = new ServiceSkills();


            var sr = s.GetMany();
           
            List<SkillRessourceViewModel> list = new List<SkillRessourceViewModel>();
            foreach (var item in sr)
            {
                SkillRessourceViewModel svm = new SkillRessourceViewModel();

                User rs = new User();
                rs=ressource.GetById(item.IdRessource);
                Skills sk = new Skills();
                sk=skill.GetById(item.IdSkill);
                string nomressource = rs.UserName;
                string nomskill = sk.SkillName;
                float skillrate = item.SkillRate;
                svm.nomressource = nomressource;
                svm.nomskill = nomskill;
                svm.SkillRate = skillrate;
                //svm.IdRessource = item.IdRessource;
               // svm.IdSkill = item.IdSkill;
                svm.id = item.id;
                list.Add(svm);
                             
            }
                return View(list);
        }

        // GET: SkillRessources/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillRessources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillRessources/Create
        [HttpPost]
        public ActionResult Create(SkillRessourceViewModel srv)
        {
            ServiceSkillRessource s = new ServiceSkillRessource();
            SkillRessource sr = new SkillRessource();
            sr.IdRessource = srv.IdRessource;
            sr.IdSkill = srv.IdSkill;
           // sr.SkillRate = srv.SkillRate;
            s.Add(sr);
            s.Commit();
            return RedirectToAction("Index");
        }

        // GET: SkillRessources/Edit/5
        public ActionResult Edit(int id)
        {
            SkillRessourceViewModel svm = new SkillRessourceViewModel();
            SkillRessource sr = new SkillRessource();
            ServiceSkillRessource sk = new ServiceSkillRessource();
            ServiceResource serviceressource = new ServiceResource();
            ServiceSkills serviceskill = new ServiceSkills();
            sr = sk.GetById(id);
            int idr = sr.IdRessource;
            int ids = sr.IdSkill;
            var s = serviceskill.GetById(ids);
            var r = serviceressource.GetById(idr);

            svm.id = sr.id;
            svm.SkillRate = sr.SkillRate;
            svm.nomressource = r.UserName;
            svm.nomskill = s.SkillName;
         
            return View(svm);
        }

        // POST: SkillRessources/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SkillRessourceViewModel svm)
        {
            SkillRessource sr = new SkillRessource();
            ServiceSkillRessource sk = new ServiceSkillRessource();
            sr = sk.GetById(id);
            //   sk.SkillRate = svm.SkillRate;
            sr.SkillRate = svm.SkillRate;
         
            sk.Update(sr);
            sk.Commit();
            return RedirectToAction("Affect");

        }

        // GET: SkillRessources/Delete/5
        public ActionResult Delete(int id)
        {
            SkillRessourceViewModel svm = new SkillRessourceViewModel();
            SkillRessource sr = new SkillRessource();
            ServiceSkillRessource sk = new ServiceSkillRessource();
            ServiceResource serviceressource = new ServiceResource();
            ServiceSkills serviceskill = new ServiceSkills();
            sr = sk.GetById(id);
            int idr = sr.IdRessource;
            int ids = sr.IdSkill;
            var s = serviceskill.GetById(ids);
            var r = serviceressource.GetById(idr);

            svm.id = sr.id;
            svm.SkillRate = sr.SkillRate;
            svm.nomressource = r.UserName;
            svm.nomskill = s.SkillName;

            return View(svm);

        }

        // POST: SkillRessources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            SkillRessource sr = new SkillRessource();
            ServiceSkillRessource sk = new ServiceSkillRessource();
            sr = sk.GetById(id);
            sk.Delete(sr);
            sk.Commit();
            return RedirectToAction("Affect");

        }
    }
}
