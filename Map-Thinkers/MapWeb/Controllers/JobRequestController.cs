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
using Microsoft.AspNet.Identity;

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
            var JobRequest = JOR.GetMany();
            List<JobRequestModels> jrm = new List<JobRequestModels>();
            foreach (var t in JobRequest)
            {




                if (t.UserId == int.Parse(User.Identity.GetUserId()))
                {
                    jrm.Add(

                      new JobRequestModels
                      {
                          RequestDate = t.RequestDate,
                          Speciality = t.Speciality,
                          JobRequestState = t.JobRequestState,
                          JobOfferId = t.JobOfferId,
                          UserId = t.UserId,
                          JobOffer = Svo.GetById(t.JobOfferId),
                          JobRequestId=t.JobRequestId,
                          JobRequest_Motivation = t.JobRequest_Motivation,



                      });
                }

            }
            return View(jrm);
        }

        // GET: JobRequest/Details/5
        public ActionResult Details(int id)
        {
            JobRequestModels g = new JobRequestModels();
            JobRequest JBO = JOR.GetById(id);
            g.JobRequestState = JBO.JobRequestState;
            g.JobRequest_Motivation = JBO.JobRequest_Motivation;
            g.RequestDate = JBO.RequestDate;
            g.Speciality = JBO.Speciality;
            g.JobOffer = Svo.GetById(JBO.JobOfferId);
            g.JobOfferId = JBO.JobOfferId;
            g.UserId = JBO.UserId;


            

            return View(g);
        }

        // GET: JobRequest/Create
        public ActionResult CreateApp()
        {
            JobRequestModels jp = new JobRequestModels();
            return View(jp);
        }

        // POST: JobRequest/Create
        [HttpPost]
        public ActionResult CreateApp(JobRequestModels jr,int id)
        {
            JobOffer jv = Svo.GetById(id);

            try
            {
                JobRequest j = new JobRequest
                {
                    JobRequestState = State.notApplay,
                    Speciality = jr.Speciality,
                    JobRequest_Motivation = jr.JobRequest_Motivation,
                    RequestDate = DateTime.Now,
                    UserId = int.Parse(User.Identity.GetUserId()),
                    JobOfferId = id
                  
                };

                if (jv.Poste_numb > 0)
                {
                    JOR.Add(j);
                    JOR.Commit();
                    jv.Poste_numb = jv.Poste_numb - 1;
                }
                else
                {

                    TempData["msg"] = "<script>alert('No places');</script>";
                }

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
        public ActionResult DeleteR(int id)
        {
            JOR.Delete(JOR.GetById(id));
            JOR.Commit();


            return RedirectToAction("GetAllApp");
        }

        // POST: JobRequest/Delete/5
        [HttpPost]
        public ActionResult DeleteR(int id, JobRequestModels JR)
        {
            JobRequest j=JOR.GetById(id);
            j.JobOfferId = JR.JobOfferId;
            j.JobRequestState = JR.JobRequestState;
            j.JobRequest_Motivation = JR.JobRequest_Motivation;
            j.RequestDate = JR.RequestDate;
            j.Speciality = JR.Speciality;

            JOR.Delete(j);
            JOR.Commit();

            return RedirectToAction("GetAllApp");






        }
    }
}
