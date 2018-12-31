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
    public class TanteremController : Controller
    {
        // GET: Tanterem
        public ActionResult Index()
        {


            
           if(Belepette.userLogged == null)
           {

                   return Redirect("/");

           }
           else
           {
               if(Belepette.userLogged.ErrorCode != 0)
               {
                  return Redirect("/");
               }
           }
           


            Proxy p = new Proxy();


            TanteremListaResponse resp = new TanteremListaResponse();

            resp = (TanteremListaResponse)Task.Run(() => p.GetTanteremLista()).Result;



            ViewData["TanteremLista"] = resp.TanteremLista;


            return View();

        }

        [HttpPost]
        public JsonResult TanteremHozzaad(Models.Tanterem req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TanteremHozzaad(req)).Result;

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
        public JsonResult TanteremFrissit(Models.Tanterem req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TanteremFrissit(req)).Result;

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
        public JsonResult TanteremTorol(Models.Tanterem req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TanteremTorol(req)).Result;

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
