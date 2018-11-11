using MapDomain.Entities;
using MapService.M;
using MapService.ServiceRadhouen;
using MapWeb.Models.RadhouenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
namespace MapWeb.Controllers
{
    public class JobRequestController : HomeController
    {
        ServiceJobOffer Svo = new ServiceJobOffer();
        ServiceJobRequest JOR = new ServiceJobRequest();
        User u = new User();
        // GET: JobOffer
        public ActionResult AllJobOffersCand()
        {
            var JobOffer = Svo.GetMany();
            List<JobOfferModels> jom = new List<JobOfferModels>();
            foreach (var t in JobOffer)
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
                        JobOfferId = t.JobOfferId


                    });

            }
            return View(jom);
        }





        // GET: JobRequest
        public ActionResult GetAllApp()
        {
            return View();
        }

        // GET: JobRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobRequest/Create
        public ActionResult CreateApp()
        {
            JobRequestModels jr = new JobRequestModels();
            return View(jr);
        }

        // POST: JobRequest/Create
        [HttpPost]
        public ActionResult CreateApp(JobRequestModels jr)
        {
            jr.JobRequestState = State.notApplay;
            try
            {
                JobRequest j = new JobRequest
                {
                    JobRequestState = jr.JobRequestState,
                    Speciality = jr.Speciality,
                    JobRequest_Motivation = jr.JobRequest_Motivation,
                    RequestDate = DateTime.Now,
                    UserId = u.Id,
                    JobOfferId=jr.JobOfferId,
                    
                  
                    

                };
                JOR.Add(j);
                JOR.Commit();

                return RedirectToAction("AllJobOffersCand");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
