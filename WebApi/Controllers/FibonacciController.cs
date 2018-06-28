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
            //int myNumber = 0;
            //double myFib;
            //if (int.TryParse(n, out myNumber))
            //{
            //    return Fibonacci2(myNumber);
            //}
            //else
            //{
            //    return "Error";
            //}

            //SendRequestToGoogleAnalytics();
            int myNumber = Convert.ToInt32(n);
            

            return Fibonacci2(myNumber);
        }

        // GET api/values/5
        //public Int64 Get(int id)
        //{
        //    return Fibonacci2(id);
        //}

        // Fast doubling algorithm
        private static double Fibonacci(long n)
        {
            double a = 0;
            double b = 1; ;
            for (int i = 31; i >= 0; i--)
            {
                double d = a * (b * 2 - a);
                double e = a * a + b * b;
                a = d;
                b = e;
                if ((((uint)n >> i) & 1) != 0)
                {
                    double c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }
        private static Int64 Fibonacci2(int n)
        {
            double Phi = (1 + Math.Sqrt(5)) / 2;
            double phi = (1 - Math.Sqrt(5)) / 2;
            double fib = (Math.Pow(Phi, n) - (Math.Pow(phi, n)))/Math.Sqrt(5);
            //return fib.ToString();
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

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}




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
                "&utmvid=" + visitorId;//+
                                       //"&utmip=" + GlobalContext.Request.ServerVariables["REMOTE_ADDR"];

            //try
            //{
            WebRequest connection = WebRequest.Create(utmUrl);

                //((HttpWebRequest)connection).UserAgent = GlobalContext.Request.UserAgent;
                //connection.Headers.Add("Accepts-Language",
                    //GlobalContext.Request.Headers.Get("Accepts-Language"));

                using (WebResponse resp = connection.GetResponse())
                {
                    // Ignore response
                }
            //}
            //catch (Exception ex)
            //{
            //    if (GlobalContext.Request.QueryString.Get("utmdebug") != null)
            //    {
            //        throw new Exception("Error contacting Google Analytics", ex);
            //    }
            //}
        }

    }
}
