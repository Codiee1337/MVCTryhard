using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace Utilities
{

    public class Belepette
    {
        public static WebApiResponse userLogged
        {
            get
            {
                return (WebApiResponse)HttpContext.Current.Session["userLogged"];
            }
            set
            {
                HttpContext.Current.Session["userLogged"] = value;
            }
        }
    }

    public class Costants
    {
        public const string baseUrlApi = "http://localhost:58788/api";
        public const int ERROR_NONE = 0;
        public const int ERROR_NET = -999;
        public const int ERROR_GENERIC = -1;
    }

    public class Proxy : Costants
    {
        #region Inicializáció
        protected HttpClient HttpClient { get; set; }
        protected CookieContainer CookieJar { get; }

        public TimeSpan Timeout { get; set; }

        public Proxy()
        {
            CookieJar = new CookieContainer();
            Timeout = new TimeSpan(0, 0, 20);
        }

        void InitHttpClient()
        {
            HttpClient = new HttpClient();
            if (Timeout > new TimeSpan(0, 0, 1))
                HttpClient.Timeout = Timeout;
            HttpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            HttpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            HttpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
        }
        #endregion

        #region LOGIN
        public async Task<LoginResponse> Login(Login req)
        {
            InitHttpClient();
            var resp = new LoginResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Global/Login");


                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<LoginResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }
        #endregion

        #region Tanar
        public async Task<TanarListaResponse> GetTanarLista()
        {
            InitHttpClient();
            var resp = new TanarListaResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tanarok/TanarLista");
                var r = await HttpClient.GetAsync(endpoint);
                if(r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<TanarListaResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }

        }

        public async Task<WebApiResponse> TanarHozzaad(Tanar req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tanarok/TanarHozzaad");

                

                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }



        public async Task<WebApiResponse> TanarTorol(Tanar req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tanarok/TanarTorol");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> TanarFrissit(Tanar req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tanarok/TanarFrissit");

                var json = JsonConvert.SerializeObject(req);

                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));

                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }
        #endregion

        #region Tantermek

        public async Task<TanteremListaResponse> GetTanteremLista()
        {
            InitHttpClient();
            var resp = new TanteremListaResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantermek/TanteremLista");
                var r = await HttpClient.GetAsync(endpoint);
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<TanteremListaResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }

        }

        public async Task<WebApiResponse> TanteremHozzaad(Tanterem req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantermek/TanteremHozzaad");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> TanteremFrissit(Tanterem req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantermek/TanteremFrissit");

                var json = JsonConvert.SerializeObject(req);

                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));

                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> TanteremTorol(Tanterem req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantermek/TanteremTorol");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        #endregion

        #region Tantargyak

        public async Task<TantargyListaResponse> GetTantargyLista()
        {
            InitHttpClient();
            var resp = new TantargyListaResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantargy/TantargyLista");
                var r = await HttpClient.GetAsync(endpoint);
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<TantargyListaResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }

        }

        public async Task<WebApiResponse> TantargyHozzaad(Tantargyak req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantargy/TantargyHozzaad");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> TantargyFrissit(Tantargyak req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantargy/TantargyFrissit");

                var json = JsonConvert.SerializeObject(req);

                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));

                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> TantargyTorol(Tantargyak req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Tantargy/TantargyTorol");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        #endregion

        #region Osztalyok

        public async Task<OsztalyListaResponse> GetOsztalyLista()
        {
            InitHttpClient();
            var resp = new OsztalyListaResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Osztalyok/OsztalyLista");
                var r = await HttpClient.GetAsync(endpoint);
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<OsztalyListaResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }

        }

        public async Task<WebApiResponse> OsztalyHozzaad(Osztalyok req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Osztalyok/OsztalyHozzaad");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> OsztalyFrissit(Osztalyok req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Osztalyok/OsztalyFrissit");

                var json = JsonConvert.SerializeObject(req);

                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));

                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        public async Task<WebApiResponse> OsztalyTorol(Osztalyok req)
        {
            InitHttpClient();
            var resp = new WebApiResponse();
            try
            {
                var endpoint = string.Format(baseUrlApi + "/Osztalyok/OsztalyTorol");



                var json = JsonConvert.SerializeObject(req);
                var r = await HttpClient.PostAsync(endpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                if (r.IsSuccessStatusCode)
                {
                    var contents = await r.Content.ReadAsStringAsync();
                    var returnValue = JsonConvert.DeserializeObject(contents);
                    resp = JsonConvert.DeserializeObject<WebApiResponse>(returnValue.ToString());
                }
                else
                {
                    resp.ErrorCode = ERROR_NET;
                    resp.ErrorMessage = r.StatusCode.ToString();
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.ErrorCode = ERROR_GENERIC;
                resp.ErrorMessage = ex.ToString();
                return resp;
            }
        }

        #endregion
    }

}

