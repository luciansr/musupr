using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Musupr.Service
{
    public class ReCaptchaService
    {
        public enum RESPONSE { INVALID = 800 }

        public bool ResponseIsCorrect(string reCaptchaResponse)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify");

            var postData = "secret=6LfunAITAAAAAHqoUDPpCraYjKNeudiLprilfixo" + "&" +
                           "response=" + reCaptchaResponse; 

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            JObject responseJSON = JObject.Parse(responseString);

            if (responseJSON["success"] != null) return (bool)responseJSON["success"];

            return false;
        }
    }
}
