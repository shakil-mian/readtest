using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApi.Controllers
{
    public class FibonacciController : ApiController
    {
        // GET api/values
        public Int64 Get([FromUri]string n)
        {
            SendRequestToGoogleAnalytics();
            int myNumber = Convert.ToInt32(n);
            
            return Fibonacci2(myNumber);
        }

        private static Int64 Fibonacci2(int n)
        {
            double Phi = (1 + Math.Sqrt(5)) / 2;
            double phi = (1 - Math.Sqrt(5)) / 2;
            double fib = (Math.Pow(Phi, n) - (Math.Pow(phi, n)))/Math.Sqrt(5);
            return Convert.ToInt64(fib);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        private void SendRequestToGoogleAnalytics()
        {

            string utmGifLocation = "http://www.google-analytics.com/__utm.gif";
            var context = Request.GetRequestContext();

            string RandomNumber = "";
            string domainName = "";
            string documentReferer = "";
            string documentPath = context.Url.Request.RequestUri.ToString();
            string account = "UA-121538198-1";
            string visitorId = "";

            string utmUrl = utmGifLocation + "?" +
                "utmwv=" + "version" +
                "&utmn=" + RandomNumber +
                "&utmhn=" + HttpUtility.UrlEncode(domainName) +
                "&utmr=" + HttpUtility.UrlEncode(documentReferer) +
                "&utmp=" + HttpUtility.UrlEncode(documentPath) +
                "&utmac=" + account +
                "&utmcc=__utma%3D999.999.999.999.999.1%3B" +
                "&utmvid=" + visitorId;

            WebRequest connection = WebRequest.Create(utmUrl);

            using (WebResponse resp = connection.GetResponse())
            {
                // Ignore response
            }

        }

    }
}
