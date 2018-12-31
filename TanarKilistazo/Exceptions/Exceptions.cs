using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanarKilistazo.Exceptions
{
    public class GenericErrorHandling : Exception
    {

        public int ErrorCode = -1;
        public String ErrorMessage = "Generic error";

    }

    public class TanarMarLetezikError : Exception
    {
        public int ErrorCode = -10;
        public String ErrorMessage = "Ilyen nevű tanár már létezik!";
    }
    public class TanarNemLetezikError : Exception
    {
        public int ErrorCode = -11;
        public String ErrorMessage = "Ilyen tanár nem létezik!";
    }

    public class TanteremMarLetezikError : Exception
    {
        public int ErrorCode = -20;
        public String ErrorMessage = "Ilyen nevű tanterem már létezik!";
    }

    public class TanteremNemLetezikError : Exception
    {
        public int ErrorCode = -21;
        public String ErrorMessage = "Ilyen tanterem nem létezik!";
    }
    public class IlyenFelhasznaloNemLetezikError : Exception
    {
        public int ErrorCode = -30;
        public String ErrorMessage = "Rossz felhasználónév és jelszó!";
    }
    public class TantargyNemLetezikError : Exception
    {
        public int ErrorCode = -40;
        public String ErrorMessage = "Ilyen tantárgy nem létezik!";
    }
    public class TantargyMarLetezikError : Exception
    {
        public int ErrorCode = -41;
        public String ErrorMessage = "Ilyen tantárgy már létezik!";
    }
    public class OsztalyNemLetezikError : Exception
    {
        public int ErrorCode = -50;
        public String ErrorMessage = "Ilyen osztály nem létezik!";
    }
    public class OsztalyMarLetezikError : Exception
    {
        public int ErrorCode = -51;
        public String ErrorMessage = "Ilyen osztály már létezik!";
    }
    public class OrarendMarLetezikError : Exception
    {
        public int ErrorCode = -60;
        public String ErrorMessage = "Ezen a napon ebben az órában órarend már hozzá lett adva!";
    }
    public class OrarendNemLetezikError : Exception
    {
        public int ErrorCode = -61;
        public String ErrorMessage = "Nincs ilyen órarend!";
    }

}