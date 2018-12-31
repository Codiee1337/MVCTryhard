using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TanarKilistazo.DBManager;
using TanarKilistazo.Exceptions;
using TanarKilistazo.Models;
using Newtonsoft.Json;

namespace TanarKilistazo.Controllers
{
    [RoutePrefix("api/Global")]
    public class GlobalController : ApiController
    {
        private DBManager.DBManager dbmngr = new DBManager.DBManager();

        [HttpPost]
        [Route("Login")]
        public String Login([FromBody]dynamic value)
        {
            WebApiResponse resp = new WebApiResponse();
            try
            {

                dbmngr.Login(value.Felhasznalonev.ToString(), value.Jelszo.ToString(), value.ipcim.ToString());
                resp.ErrorCode = 0;

            }
            catch (IlyenFelhasznaloNemLetezikError e)
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
