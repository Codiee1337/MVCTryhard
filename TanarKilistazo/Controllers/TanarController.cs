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
    public class TanarController : ApiController
    {

        private DBManager.DBManager dbmngr = new DBManager.DBManager();




        [HttpGet]
        [Route("Teszt")]
        public String Teszt()
        {
            return "A WebAPI működik!";
        }

        [HttpGet]
        [Route("TanarLista")]
        public String TanarLista()
        {

            TanarListaResponse resp = new TanarListaResponse();

            try
            {

                resp.TanarLista = dbmngr.TanarListaKikero();
                resp.ErrorCode = 0;

            }catch(Exception e)
            {
                resp.ErrorCode = -1;
                resp.ErrorMessage = e.Message;
            }

            return JsonConvert.SerializeObject(resp);


        }

        [HttpPost]
        [Route("TanarHozzaad")]
        public String TanarHozzaad([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                dbmngr.TanarHozzaad(value.Vezeteknev.ToString(), value.Keresztnev.ToString(), value.Monogram.ToString());
                resp.ErrorCode = 0;
               
            }catch(TanarMarLetezikError e)
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
        [Route("TanarTorol")]
        public String TanarTorol([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                Guid ID = Guid.Parse(value.ID.ToString());

                dbmngr.TanarTorol(ID);
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

        [HttpPost]
        [Route("TanarFrissit")]
        public String TanarFrissit([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {
                Guid ID = Guid.Parse(value.ID.ToString());
                dbmngr.TanarFrissit(ID, value.Vezeteknev.ToString(), value.Keresztnev.ToString(), value.Monogram.ToString());
                resp.ErrorCode = 0;

            }
            catch(TanarNemLetezikError e)
            {
                resp.ErrorMessage = e.ErrorMessage;
                resp.ErrorCode = e.ErrorCode;
            }
            catch(Exception e)
            {
                resp.ErrorCode = -1;
                resp.ErrorMessage = e.Message;
            }
            return JsonConvert.SerializeObject(resp);
        }



    }
}
