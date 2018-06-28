using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
namespace WebApi.Controllers
{
    public class ReverseWordsController : BaseController
    {

        // GET api/values
        public string Get([FromUri]string sentence = null)
        {
            SendRequestToGoogleAnalytics();
            if (sentence == null)
            {
                sentence = "";
            }
            return reverseIt(sentence);
        }

        private static string reverseIt(string val)
        {
            char[] chrArray = new char[val.Length];
            int i = 0;
            string revStr = "";
            foreach (char chr in val)
            {
                chrArray[i] = chr;
                i++;
            }

            for (int j = val.Length - 1; j >= 0; j--)
            {
                revStr = revStr + chrArray[j];
            }

            return revStr;
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


    }
}
