using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;
using WebApplication1.Models;
using System.Threading.Tasks;
using System.Threading;

namespace WebApplication1.Controllers
{
    public class TantargyController : Controller
    {

        public ActionResult Index()
        {
            
            if (Belepette.userLogged == null)
            {

                return Redirect("/");

            }
            else
            {
                if (Belepette.userLogged.ErrorCode != 0)
                {
                    return Redirect("/");
                }
            }
            

            Proxy p = new Proxy();


            TantargyListaResponse resp = new TantargyListaResponse();

            resp = (TantargyListaResponse)Task.Run(() => p.GetTantargyLista()).Result;



            ViewData["TantargyLista"] = resp.TantargyLista;


            return View();
        }

        [HttpPost]
        public JsonResult TantargyHozzaad(Models.Tantargyak req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TantargyHozzaad(req)).Result;

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

        [HttpPost]
        public JsonResult TantargyTorol(Models.Tantargyak req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TantargyTorol(req)).Result;

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

        [HttpPost]
        public JsonResult TantargyFrissit(Models.Tantargyak req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TantargyFrissit(req)).Result;

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
