using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TanarKilistazo.Models;
using TanarKilistazo.DBManager;
using Newtonsoft.Json;
using TanarKilistazo.Exceptions;

namespace TanarKilistazo.Controllers
{
    [RoutePrefix("api/Osztalyok")]
    public class OsztalyController : ApiController
    {
        private DBManager.DBManager dbmngr = new DBManager.DBManager();




        [HttpGet]
        [Route("Teszt")]
        public String Teszt()
        {
            return "A WebAPI működik!";
        }

        [HttpGet]
        [Route("OsztalyLista")]
        public String OsztalyLista()
        {

            OsztalyListaResponse resp = new OsztalyListaResponse();

            try
            {

                resp.OsztalyLista = dbmngr.OsztalyListaKikero();
                resp.ErrorCode = 0;

            }
            catch (Exception e)
            {
                resp.ErrorCode = -1;
                resp.ErrorMessage = e.Message;
            }

            return JsonConvert.SerializeObject(resp);


        }

        [HttpPost]
        [Route("OsztalyHozzaad")]
        public String OsztalyHozzaad([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                dbmngr.OsztalyHozzaad(value.Osztaly.ToString());
                resp.ErrorCode = 0;

            }
            catch (OsztalyMarLetezikError e)
            {
                resp.ErrorMessage = e.ErrorMessage;
                resp.ErrorCode = e.ErrorCode;
            }
            catch (Exception e)
            {
                resp.ErrorCode = -1;
                resp.ErrorMessage = e.Message;
            }

            return JsonConvert.SerializeObject(resp);

        }

        [HttpPost]
        [Route("OsztalyTorol")]
        public String OsztalyTorol([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                Guid ID = Guid.Parse(value.ID.ToString());

                dbmngr.OsztalyTorol(ID);
                resp.ErrorCode = 0;

            }
            catch (OsztalyNemLetezikError e)
            {
                resp.ErrorMessage = e.ErrorMessage;
                resp.ErrorCode = e.ErrorCode;
            }
            catch (Exception e)
            {
                resp.ErrorCode = -1;
                resp.ErrorMessage = e.Message;
            }

            return JsonConvert.SerializeObject(resp);

        }

        [HttpPost]
        [Route("OsztalyFrissit")]
        public String OsztalyFrissit([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {
                Guid ID = Guid.Parse(value.ID.ToString());
                dbmngr.OsztalyFrissit(ID, value.Osztaly.ToString());
                resp.ErrorCode = 0;

            }
            catch (OsztalyNemLetezikError e)
            {
                resp.ErrorMessage = e.ErrorMessage;
                resp.ErrorCode = e.ErrorCode;
            }
            catch (Exception e)
            {
                resp.ErrorCode = -1;
                resp.ErrorMessage = e.Message;
            }
            return JsonConvert.SerializeObject(resp);
        }


    }
}
