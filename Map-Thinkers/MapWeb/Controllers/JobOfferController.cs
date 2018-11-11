using MapDomain.Entities;
using MapService.ServiceRadhouen;
using MapWeb.Models.RadhouenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class JobOfferController : HomeController
    {

        ServiceJobOffer Svo = new ServiceJobOffer();
        // GET: JobOffer
        public ActionResult AllJobOffers()
        {
            var JobOffer = Svo.GetMany();
            List<JobOfferModels> jom = new List<JobOfferModels>();
            foreach(var t in JobOffer)
            {
                jom.Add(

                    new JobOfferModels
                    {
                        DateDeb = t.DateDeb,
                        DateFin = t.DateFin,
                        Experience = t.Experience,
                        Function = t.Function,
                        JobOfferDesrip = t.JobOfferDesrip,
                        Poste_numb = t.Poste_numb,
                        Required_Profile = t.Required_Profile,
                        JobOfferId=t.JobOfferId
                   
                    
                });

            }
            return View(jom);
        }

        // GET: JobOffer/Details/5
        public ActionResult Details(int id)
        {
            JobOfferModels g = new JobOfferModels();
            JobOffer JBO = Svo.GetById(id);
            g.Experience = JBO.Experience;
            g.DateDeb = JBO.DateDeb;
            g.DateFin = JBO.DateFin;
            g.Function = JBO.Function;
            g.JobOfferDesrip = JBO.JobOfferDesrip;
            g.Poste_numb = JBO.Poste_numb;
            g.Required_Profile = JBO.Required_Profile;

            return View(g);
        }

        // GET: JobOffer/Create
        public ActionResult CreateJobOffer()
        {


            JobOfferModels jp = new JobOfferModels();         
            return View(jp);
           
        }

        // POST: JobOffer/Create
        [HttpPost]
        public ActionResult CreateJobOffer(JobOfferModels jo)
        {     
            try
            {
                JobOffer j = new JobOffer
                {
                    DateDeb = jo.DateDeb,
                    DateFin = jo.DateFin,
                    Experience = jo.Experience,
                    Function = jo.Function,
                    JobOfferDesrip = jo.JobOfferDesrip,
                   
                    Poste_numb = jo.Poste_numb,
                    Required_Profile = jo.Required_Profile
                };
                Svo.Add(j);
                Svo.Commit();

                return RedirectToAction("AllJobOffers");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobOffer/Edit/5
        public ActionResult Edit(int id)
        {
            JobOfferModels g = new JobOfferModels();
            JobOffer JBO = Svo.GetById(id);
            g.Experience = JBO.Experience;
            g.DateDeb = JBO.DateDeb;
            g.DateFin = JBO.DateFin;
            g.Function = JBO.Function;
            g.JobOfferDesrip = JBO.JobOfferDesrip;
            g.Poste_numb = JBO.Poste_numb;
            g.Required_Profile = JBO.Required_Profile;

            return View(g);

        }

        // POST: JobOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, JobOfferModels JBO)
        {
            JobOffer g = Svo.GetById(id);
            g.Experience = JBO.Experience;
            g.DateDeb = JBO.DateDeb;
            g.DateFin = JBO.DateFin;
            g.Function = JBO.Function;
            g.JobOfferDesrip = JBO.JobOfferDesrip;
            g.Poste_numb = JBO.Poste_numb;
            g.Required_Profile = JBO.Required_Profile;

            return RedirectToAction("AllJobOffers");
        }

        // GET: JobOffer/Delete/5
        public ActionResult Delete(int id)
        {
            Svo.Delete(Svo.GetById(id));
            Svo.Commit();
            

            return RedirectToAction("AllJobOffers");
        }

        // POST: JobOffer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, JobOfferModels JBO)
        {
            JobOffer g = Svo.GetById(id);
            g.Experience = JBO.Experience;
            g.DateDeb = JBO.DateDeb;
            g.DateFin = JBO.DateFin;
            g.Function = JBO.Function;
            g.JobOfferDesrip = JBO.JobOfferDesrip;
            g.Poste_numb = JBO.Poste_numb;
            g.Required_Profile = JBO.Required_Profile;
            
            Svo.Delete(g);
            Svo.Commit();

            return RedirectToAction("AllJobOffers", "Home");
        }




        [HttpPost]
        public ActionResult AllJobOffers(string searchString)
        {
           
            if (!String.IsNullOrEmpty(searchString))
            {
                //resultatTask = resultatTask.Where(m => m.Task_Type.Contains(searchString)).ToList();
                var evn = Svo.getJobOfferExperience(searchString);

                List<JobOfferModels> tVM = new List<JobOfferModels>();

                foreach (var t in evn)
                {
                    tVM.Add(
                        new JobOfferModels
                        {
                            DateDeb = t.DateDeb,
                            DateFin = t.DateFin,
                            Experience = t.Experience,
                            Function = t.Function,
                            JobOfferDesrip = t.JobOfferDesrip,
                            Poste_numb = t.Poste_numb,
                            Required_Profile = t.Required_Profile,
                           
                        });

                }

                return View(tVM);
            }
            else
            {
                var evn = Svo.GetMany();

                List<JobOfferModels> tVM = new List<JobOfferModels>();

                foreach (var t in evn)
                {
                    tVM.Add(
                        new JobOfferModels
                        {
                            DateDeb = t.DateDeb,
                            DateFin = t.DateFin,
                            Experience = t.Experience,
                            Function = t.Function,
                            JobOfferDesrip = t.JobOfferDesrip,
                            Poste_numb = t.Poste_numb,
                            Required_Profile = t.Required_Profile,

                        });

                }

                return View(tVM);
            }



        }
    }
}
