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
        public async System.Threading.Tasks.Task<ActionResult> CreateJobOffer(JobOfferModels jo)
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


              
                Svo.Add(j);
                Svo.Commit();

                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("radhouen.abidi@esprit.tn"));  // replace with valid value 
                message.From = new MailAddress("radhouen.abidi@esprit.tn");  // replace with valid value
                message.Subject = "Event Created ! ";
                message.Body = string.Format(body, "Event Services", "radhouen.abidi@esprit.tn", "Your event has been created succuesufly");
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "radhouen.abidi@gmail.com",  // replace with valid value
                        Password = "vamoslafrewa1"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);


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
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id, JobOfferModels JBO)
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
