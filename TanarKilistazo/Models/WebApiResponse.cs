using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanarKilistazo.Models
{
    public class WebApiResponse
    {
        public String ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }

    public class TanarListaResponse : WebApiResponse
    {

        public List<Tanarok> TanarLista { get; set; }

    }

    public class OsztalyListaResponse : WebApiResponse
    {
        public List<Osztalyok> OsztalyLista {get;set;}
    }

    public class TanteremListaResponse : WebApiResponse
    {

        public List<Tantermek> TanteremLista { get; set; }

    }

    public class TantargyListaResponse : WebApiResponse
    {
        public List<Tantargyak> TantargyLista { get; set; }
    }

    public class OrarendListaResponse : WebApiResponse
    {
        public List<Orarendek> OrarendLista { get; set; }
    }

}