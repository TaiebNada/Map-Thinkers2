using MapData;
using MapDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class BaseController : Controller
    {

        public static int UserId;
        public static string UserType;
        public static User UserDb;
        // GET: Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
            using ( MapContext _context = new MapContext())
            {
                var UserDb = _context.Users.SingleOrDefault(x=>x.Email == System.Web.HttpContext.Current.User.Identity.Name);
                if (UserDb != null)
                {
                    UserType = UserDb.AccountType;
                }
                else
                    UserType = "";
            }
            ViewData["UserType"] = UserType;
            base.OnActionExecuted(filterContext);
        }


      
    }
}