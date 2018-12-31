using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Models
{
    public class WebApiResponse
    {

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

    }

    public class Tanar : WebApiResponse
    {
        public System.Guid ID { get; set; }
        public string Keresztnev { get; set; }
        public string Vezeteknev { get; set; }
        public string Monogram { get; set; }
    }

    public class Tanterem : WebApiResponse
    {
        public System.Guid ID { get; set; }
        public String Tanteremnev { get; set; }
    }

    public class Tantargyak : WebApiResponse
    {
        public System.Guid ID { get; set; }
        public String Tantargy { get; set; }
        public String Tantargyroviditese { get; set; }
    }

    public class Osztalyok : WebApiResponse
    {
        public System.Guid ID { get; set; }
        public String Osztaly { get; set; }
    }

    public class Login : WebApiResponse
    {
        public String Felhasznalonev { get; set; }
        public String Jelszo { get; set; }
        public String ipcim { get; set; }

    }

    public class TanarListaResponse : WebApiResponse { public List<Tanar> TanarLista { get; set; } }

    public class TanteremListaResponse : WebApiResponse {public List<Tanterem> TanteremLista { get; set; } }

    public class TantargyListaResponse : WebApiResponse { public List<Tantargyak> TantargyLista { get; set; } }

    public class OsztalyListaResponse : WebApiResponse { public List<Osztalyok> OsztalyLista { get; set; } }

    public class LoginResponse : WebApiResponse { public Login Response { get; set; } }

}


