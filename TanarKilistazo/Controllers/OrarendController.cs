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
    [RoutePrefix("api/Tanarok")]
    public class OrarendController : ApiController
    {
        private DBManager.DBManager dbmngr = new DBManager.DBManager();

        [HttpGet]
        [Route("Teszt")]
        public String Teszt()
        {
            return "A WebAPI működik!";
        }

        [HttpGet]
        [Route("OrarendLista")]
        public String OrarendLista()
        {

            OrarendListaResponse resp = new OrarendListaResponse();

            try
            {

                resp.OrarendLista = dbmngr.OrarendListaKikero();
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
        [Route("OrarendHozzaad")]
        public String OrarendHozzaad([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {
                Guid Osztaly = Guid.Parse(value.OsztalyID.ToString());
                    Guid Tanterem = Guid.Parse(value.TanteremID.ToString());
                Guid Tanar = Guid.Parse(value.TanarID.ToString());
                Guid Tantargy = Guid.Parse(value.TantargyID.ToString());
                int Nap = int.Parse(value.Nap.ToString());
                int Ora = int.Parse(value.Ora.ToString());

                dbmngr.OrarendHozzaad(Osztaly,Tanterem,Tanar,Tantargy,Nap,Ora);
                resp.ErrorCode = 0;

            }
            catch (OrarendMarLetezikError e)
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
        [Route("OrarendTorol")]
        public String OrarendTorol([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                Guid ID = Guid.Parse(value.ID.ToString());

                dbmngr.OrarendTorol(ID);
                resp.ErrorCode = 0;

            }
            catch (OrarendNemLetezikError e)
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
        [Route("OrarendFrissit")]
        public String OrarendFrissit([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {
                Guid ID = Guid.Parse(value.ID.ToString());
                Guid Osztaly = Guid.Parse(value.OsztalyID.ToString());
                Guid Tanterem = Guid.Parse(value.TanteremID.ToString());
                Guid Tanar = Guid.Parse(value.TanarID.ToString());
                Guid Tantargy = Guid.Parse(value.TantargyID.ToString());
                int Nap = int.Parse(value.Nap.ToString());
                int Ora = int.Parse(value.Ora.ToString());
                dbmngr.OrarendFrissit(ID, Osztaly, Tanterem, Tanar, Tantargy, Nap, Ora);
                resp.ErrorCode = 0;

            }
            catch (OrarendNemLetezikError e)
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
