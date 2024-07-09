using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Astaberry.Models
{
    public static class Sms
    {
        public static void SendSMS(string number, string msg)
        {
            string sURL;
            StreamReader objReader;
            //give the USERNAME,PASSWORD,moblienumbers.... on URL 
            string userName = "achalarya";
            string password = "Astaberry@123";

            sURL = "https://www.txtguru.in/imobile/api.php?username=" + userName + "&password=" + password + "&source=ASTBRY&dmobile=" + number + "&dltentityid=1501421370000019160&dltheaderid=1505160585107026707&dlttempid=1507161787959905298&message=" + msg + " is your one time password (OTP) for Astaberry.ASTBRY";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
                objReader.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
