using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TanarKilistazo.Models;
using TanarKilistazo.Exceptions;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;




namespace TanarKilistazo.DBManager
{

    

    public class DBManager
    {

        TanarKilistazoEntities dbMngr = new TanarKilistazoEntities();

        #region LOGIN

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public void ipcimlogolo(String ipcim, Boolean Sikeresbelepes, String Felhasznalonev, String Jelszo, String ujjelszo)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(HttpRuntime.AppDomainAppPath.ToString()+"/LOGOK/loginlog.txt", true))
            {
                file.WriteLine("\"" + ipcim + "\":{\"Ido\":\"" + DateTime.Now + "\",\"Sikeresbelepes\":\"" + Sikeresbelepes.ToString() + "\",\"Felhasznalonev\":\"" + Felhasznalonev + "\",\"Jelszo\":\"" + Jelszo + "\",\"HASH\":\"" + ujjelszo + "\"},");
                
                
            }
        }

        public void Login(String Felhasznalonev, String Jelszo, String ipcim)
        {

            Boolean Sikeresbelepes = false;
            String ujjelszo = GenerateSHA512String(Jelszo);

            var res = dbMngr.Felhasznalok.Where(x => x.Felhasznalonev.Equals(Felhasznalonev) && x.Jelszo.Equals(ujjelszo)).FirstOrDefault();

            if(res != null)
            {
                Sikeresbelepes = true;
                res.UtolsoBejelentkezes = DateTime.Now;
                dbMngr.SaveChanges();
                ipcimlogolo(ipcim, Sikeresbelepes, Felhasznalonev, Jelszo, ujjelszo);
            }
            else
            {
                ipcimlogolo(ipcim, Sikeresbelepes, Felhasznalonev, Jelszo, ujjelszo);
                throw new IlyenFelhasznaloNemLetezikError();
            }
            

        }
        
        
        
        #endregion

        #region Tanar

        public List<Tanarok> TanarListaKikero()
        {
                return dbMngr.Tanarok.ToList();
        }

        public void TanarHozzaad(String Vezeteknev, String Keresztnev, String Monogram)
        {
       

                Tanarok result = new Tanarok();

                result.ID = Guid.NewGuid();
                result.Vezeteknev = Vezeteknev;
                result.Keresztnev = Keresztnev;
                result.Monogram = Monogram;

                if (dbMngr.Tanarok.Where(x => x.Keresztnev==result.Keresztnev).FirstOrDefault() != null && dbMngr.Tanarok.Where(x => x.Vezeteknev==result.Vezeteknev).FirstOrDefault() != null)
                {
                    throw new Exceptions.TanarMarLetezikError();
                }
                

                    dbMngr.Tanarok.Add(result);
                    dbMngr.SaveChanges();
        }

        public void TanarTorol(Guid ID)
        {
            Tanarok res = dbMngr.Tanarok.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                dbMngr.Tanarok.Remove(res);
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TanarNemLetezikError();
            }
        }

        public void TanarFrissit(Guid ID, String Vezeteknev, String Keresztnev, String Monogram)
        {
            Tanarok res = dbMngr.Tanarok.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if(res != null)
            {
                res.Vezeteknev = Vezeteknev;
                res.Keresztnev = Keresztnev;
                res.Monogram = Monogram;
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TanarNemLetezikError();
            }

            
        }

        #endregion

        #region Tanterem

        public List<Tantermek> TanteremListaKikero()
        {
            
            return dbMngr.Tantermek.ToList();
        }

        public void TanteremHozzaad(String Tanteremnev)
        {


            Tantermek result = new Tantermek();

            result.ID = Guid.NewGuid();
            result.Tanteremnev = Tanteremnev;
            

            if (dbMngr.Tantermek.Where(x => x.Tanteremnev == result.Tanteremnev).FirstOrDefault() != null)
            {
                throw new Exceptions.TanteremMarLetezikError();
            }


            dbMngr.Tantermek.Add(result);
            dbMngr.SaveChanges();
        }

        public void TanteremTorol(Guid ID)
        {
            Tantermek res = dbMngr.Tantermek.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                dbMngr.Tantermek.Remove(res);
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TanteremNemLetezikError();
            }
        }

        public void TanteremFrissit(Guid ID, String Tanteremnev)
        {
            Tantermek res = dbMngr.Tantermek.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                res.Tanteremnev = Tanteremnev;
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TanteremNemLetezikError();
            }


        }

        #endregion

        #region Tantargyak

        public List<Tantargyak> TantargyListaKikero()
        {

            return dbMngr.Tantargyak.ToList();
        }

        public void TantargyHozzaad(String Tantargy, String TantargyRovidites)
        {


            Tantargyak result = new Tantargyak();

            result.ID = Guid.NewGuid();
            result.Tantargy = Tantargy;
            result.Tantargyroviditese = TantargyRovidites;

            if (dbMngr.Tantargyak.Where(x => x.Tantargy == result.Tantargy).FirstOrDefault() != null)
            {
                throw new Exceptions.TantargyMarLetezikError();
            }


            dbMngr.Tantargyak.Add(result);
            dbMngr.SaveChanges();
        }

        public void TantargyTorol(Guid ID)
        {
            Tantargyak res = dbMngr.Tantargyak.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                dbMngr.Tantargyak.Remove(res);
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TantargyNemLetezikError();
            }
        }

        public void TantargyFrissit(Guid ID, String Tantargy, String TantargyRovidites)
        {
            Tantargyak res = dbMngr.Tantargyak.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                res.Tantargy = Tantargy;
                res.Tantargyroviditese = TantargyRovidites;
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TantargyNemLetezikError();
            }


        }



        #endregion

        #region Osztaly

        public List<Osztalyok> OsztalyListaKikero()
        {

            return dbMngr.Osztalyok.ToList();
        }

        public void OsztalyHozzaad(String Osztaly)
        {


            Osztalyok result = new Osztalyok();

            result.ID = Guid.NewGuid();
            result.Osztaly = Osztaly;

            if (dbMngr.Osztalyok.Where(x => x.Osztaly == result.Osztaly).FirstOrDefault() != null)
            {
                throw new Exceptions.OsztalyMarLetezikError();
            }


            dbMngr.Osztalyok.Add(result);
            dbMngr.SaveChanges();
        }

        public void OsztalyTorol(Guid ID)
        {
            Osztalyok res = dbMngr.Osztalyok.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                dbMngr.Osztalyok.Remove(res);
                dbMngr.SaveChanges();
            }
            else
            {
                throw new OsztalyNemLetezikError();
            }
        }

        public void OsztalyFrissit(Guid ID, String Osztaly)
        {
            Osztalyok res = dbMngr.Osztalyok.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                res.Osztaly = Osztaly;
                dbMngr.SaveChanges();
            }
            else
            {
                throw new OsztalyNemLetezikError();
            }


        }



        #endregion

        #region Orarend

        public List<Orarendek> OrarendListaKikero()
        {
            return dbMngr.Orarendek.ToList();
        }

        public void OrarendHozzaad(Guid Osztaly, Guid Tanterem, Guid Tanar, Guid Tantargy, int Nap, int Ora)
        {

            Orarendek ujorarend = new Orarendek();
            
            if(dbMngr.Orarendek.Where(x=>(x.Nap==Nap) && (x.Ora == Ora)).FirstOrDefault() != null)
            {

                throw new OrarendMarLetezikError();

            }

            ujorarend.ID = Guid.NewGuid();
            ujorarend.Osztaly = Osztaly;
            ujorarend.Tanterem = Tanterem;
            ujorarend.Tanar = Tanar;
            ujorarend.Tantargy = Tantargy;
            ujorarend.Nap = Nap;
            ujorarend.Ora = Ora;

            dbMngr.Orarendek.Add(ujorarend);
            dbMngr.SaveChanges();
        }

        public void OrarendTorol(Guid ID)
        {
            Orarendek res = dbMngr.Orarendek.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                dbMngr.Orarendek.Remove(res);
                dbMngr.SaveChanges();
            }
            else
            {
                throw new TanarNemLetezikError();
            }
        }

        public void OrarendFrissit(Guid ID, Guid Osztaly, Guid Tanterem, Guid Tanar, Guid Tantargy, int Nap, int Ora)
        {
            Orarendek res = dbMngr.Orarendek.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            if (res != null)
            {
                
                res.Osztaly = Osztaly;
                res.Tanterem = Tanterem;
                res.Tanar = Tanar;
                res.Tantargy = Tantargy;
                res.Nap = Nap;
                res.Ora = Ora;
                dbMngr.SaveChanges();
            }
            else
            {
                throw new OrarendNemLetezikError();
            }


        }

        #endregion


    }
}