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
    public class TestController : HomeController
    {


        ServiceTest cs = new ServiceTest();
        ServiceQuestion iqs = new ServiceQuestion();
        ServiceTestMark itm = new ServiceTestMark();

        // GET: Test
        public ActionResult GetAllTests()
        {
            TestModel tm = new TestModel();
            Test c = new Test();
            List<TestModel> l = new List<TestModel>();
            List<Question> lq = new List<Question>();
            c = cs.GetMany().First();
            tm.Version = c.Version;
            tm.Type = c.Type;
            lq = c.Questions.OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            tm.Questions = lq;
            l.Add(tm);

            return View(l);
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
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

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
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

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
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
