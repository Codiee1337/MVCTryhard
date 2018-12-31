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

    public class OsztalyController : Controller
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


            OsztalyListaResponse resp = new OsztalyListaResponse();

            resp = (OsztalyListaResponse)Task.Run(() => p.GetOsztalyLista()).Result;

            ViewData["OsztalyLista"] = resp.OsztalyLista;

            return View();
        }

        [HttpPost]
        public JsonResult OsztalyHozzaad(Models.Osztalyok req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.OsztalyHozzaad(req)).Result;

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
        public JsonResult OsztalyTorol(Models.Osztalyok req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.OsztalyTorol(req)).Result;

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
        public JsonResult OsztalyFrissit(Models.Osztalyok req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.OsztalyFrissit(req)).Result;

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
