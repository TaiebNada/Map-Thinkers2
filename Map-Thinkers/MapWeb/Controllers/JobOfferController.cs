using MapDomain.Entities;
using MapService.ServiceRadhouen;
using MapWeb.Models.RadhouenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace MapWeb.Controllers
{
    public class JobOfferController : HomeController
    {

        ServiceJobOffer Svo = new ServiceJobOffer();
        ServiceJobRequest JOR = new ServiceJobRequest();
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

        public ActionResult GetAllAppAdmin()
        {
            var JobRequest = JOR.GetMany();
            List<JobRequestModels> jrm = new List<JobRequestModels>();
            foreach (var t in JobRequest)
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
                          JobRequestId = t.JobRequestId,
                          JobRequest_Motivation = t.JobRequest_Motivation,



                      });
                

            }
            return View(jrm);
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
                    JobOfferId=jo.JobOfferId,
                    Poste_numb = jo.Poste_numb,
                    Required_Profile = jo.Required_Profile
                };


                if (j.DateDeb < j.DateFin && j.DateDeb>DateTime.Now)
                {
                    Svo.Add(j);
                    Svo.Commit();
                }

                else
                {

                    TempData["msg"] = "<script>alert('Check the start and end date of the offer');</script>";
                   
                   
                }

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


        ///////////////////////////////////////////////////////////////


        public ActionResult DetailsRADMIN(int id)
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


        ////////////////////////////////////////////

        public ActionResult DeleteRADMIN(int id)
        {
            JobRequest j = JOR.GetById(id);
            JobOffer jb = Svo.GetById(j.JobOfferId);
            JOR.Delete(JOR.GetById(id));
            JOR.Commit();


            return RedirectToAction("GetAllAppAdmin");
        }

        // POST: JobRequest/Delete/5
        [HttpPost]
        public ActionResult DeleteRADMIN(int id, JobRequestModels JR)
        {
            JobRequest j = JOR.GetById(id);
            JobOffer jb = Svo.GetById(j.JobOfferId);
            j.JobOfferId = JR.JobOfferId;
            j.JobRequestState = JR.JobRequestState;
            j.JobRequest_Motivation = JR.JobRequest_Motivation;
            j.RequestDate = JR.RequestDate;
            j.Speciality = JR.Speciality;
            j.JobOffer = JR.JobOffer;

            JOR.Delete(j);
            JOR.Commit();
            jb.Poste_numb = jb.Poste_numb + 1;

            return RedirectToAction("GetAllAppAdmin");

       

        }



        /////////////////////////////////////////////
        public ActionResult EditRADMIN(int id)
        {
            JobRequestModels g = new JobRequestModels();
            JobRequest JBO = JOR.GetById(id);
            g.JobRequestState = JBO.JobRequestState;

            return View(g);
        }

        // POST: JobRequest/Edit/5
        [HttpPost]
        public ActionResult EditRADMIN(int id, JobRequestModels JBO)
        {
            JobRequest g = JOR.GetById(id);

            g.JobRequestState = JBO.JobRequestState;

            return RedirectToAction("GetAllAppAdmin");
        }

    }
}
