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
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobOffer/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                return RedirectToAction("HomeBack","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobOffer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobOffer/Edit/5
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

        // GET: JobOffer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobOffer/Delete/5
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
