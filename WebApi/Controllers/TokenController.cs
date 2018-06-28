using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApi.Controllers
{
    public class TokenController : ApiController
    {
        // GET api/values
        public Guid  Get()
        {
            //SendRequestToGoogleAnalytics();
            Guid myGuid = new Guid("0db1e0a8-7306-4978-bc86-405f528ebe4d");
            return myGuid;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
