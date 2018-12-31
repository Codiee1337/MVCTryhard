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
    public class TanarController : Controller
    {
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


            TanarListaResponse resp = new TanarListaResponse();

            resp = (TanarListaResponse)Task.Run(() => p.GetTanarLista()).Result;
     


            ViewData["TanarLista"] = resp.TanarLista;    
            

            return View();
        }

        [HttpPost]
        public JsonResult TanarHozzaad(Models.Tanar req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TanarHozzaad(req)).Result;

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
        public JsonResult TanarTorol(Models.Tanar req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TanarTorol(req)).Result;

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
        public JsonResult TanarFrissit(Models.Tanar req)
        {
            try
            {
                Proxy p = new Proxy();

                WebApiResponse response = (WebApiResponse)Task.Run(() => p.TanarFrissit(req)).Result;

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