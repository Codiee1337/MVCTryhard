using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public JsonResult Login(Models.Login req)
        {



            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.Login(req)).Result;
                Belepette.userLogged = response;
                return Json(response);

            }
            catch (Exception ex)
            {

                WebApiResponse resp = new WebApiResponse();
                resp.ErrorCode = -1;
                resp.ErrorMessage = "Generic error!";

                return Json(resp);
            }

        }
    }
}
