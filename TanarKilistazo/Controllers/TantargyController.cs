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
    [RoutePrefix("api/Tantargy")]
    public class TantargyController : ApiController
    {

        private DBManager.DBManager dbmngr = new DBManager.DBManager();

        [HttpPost]
        [Route("Teszt")]
        public String Teszt()
        {

            return "A WebApi működik!";
        }

        [HttpGet]
        [Route("TantargyLista")]
        public String TantargyLista()
        {

            TantargyListaResponse resp = new TantargyListaResponse();

            try
            {

                resp.TantargyLista = dbmngr.TantargyListaKikero();
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
        [Route("TantargyHozzaad")]
        public String TantargyHozzaad([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                dbmngr.TantargyHozzaad(value.Tantargy.ToString(), value.Tantargyroviditese.ToString());
                resp.ErrorCode = 0;

            }
            catch (TantargyMarLetezikError e)
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
        [Route("TantargyTorol")]
        public String TantargyTorol([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                Guid ID = Guid.Parse(value.ID.ToString());

                dbmngr.TantargyTorol(ID);
                resp.ErrorCode = 0;

            }
            catch (TantargyNemLetezikError e)
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
        [Route("TantargyFrissit")]
        public String TantargyFrissit([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {
                Guid ID = Guid.Parse(value.ID.ToString());
                dbmngr.TantargyFrissit(ID, value.Tantargy.ToString(), value.Tantargyroviditese.ToString());
                resp.ErrorCode = 0;

            }
            catch (TantargyNemLetezikError e)
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
