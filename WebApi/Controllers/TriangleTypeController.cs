using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApi.Controllers
{
    public class TriangleTypeController : ApiController
    {
        // GET api/values
        public string Get([FromUri]string a = null, [FromUri]string b = null, [FromUri]string c = null)
        {
            return a;
        }

        // GET api/values/5
        public string Get(int a, int b, int c)
        {
            //SendRequestToGoogleAnalytics();
            string triType = "";
            if (a == 0 || b == 0 || c == 0)
            {
                triType = "Error";
            }
            else { 
                if (a == b && b == c)
                {
                    triType = "Equilateral";
                }
                else if ((a == b && b != c) || b == c && c != a || c == a && a != b)
                {
                    triType = "Isosceles";
                }
                else if (a != b && b != c && c !=a)
                {
                    triType = "Scalene";
                    int[] sides = new int[3];
                    sides[0] = a;
                    sides[1] = b;
                    sides[2] = c;
                    Array.Sort(sides);
                    if (sides[0] + sides[1] <= sides[2])
                    {
                        triType = "Error";
                    }
                }
            }
            return triType;
        }

        private static bool rightAngle(int a, int b, int c)
        {
            double sideA = Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2));
            return sideA == a;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
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
