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
    [RoutePrefix("api/Tantermek")]
    public class TanteremController : ApiController
    {

        private DBManager.DBManager dbmngr = new DBManager.DBManager();

        [HttpPost]
        [Route("Teszt")]
        public String Teszt()
        {

            return "A WebApi működik!";
        }

        [HttpGet]
        [Route("TanteremLista")]
        public String TanteremLista()
        {

            TanteremListaResponse resp = new TanteremListaResponse();

            try
            {

                resp.TanteremLista = dbmngr.TanteremListaKikero();
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
        [Route("TanteremHozzaad")]
        public String TanteremHozzaad([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                dbmngr.TanteremHozzaad(value.Tanteremnev.ToString());
                resp.ErrorCode = 0;

            }
            catch (TanteremMarLetezikError e)
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
        [Route("TanteremTorol")]
        public String TanteremTorol([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                Guid ID = Guid.Parse(value.ID.ToString());

                dbmngr.TanteremTorol(ID);
                resp.ErrorCode = 0;

            }
            catch (TanteremNemLetezikError e)
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
        [Route("TanteremFrissit")]
        public String TanteremFrissit([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {
                Guid ID = Guid.Parse(value.ID.ToString());
                dbmngr.TanteremFrissit(ID, value.Tanteremnev.ToString());
                resp.ErrorCode = 0;

            }
            catch (TanarNemLetezikError e)
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
