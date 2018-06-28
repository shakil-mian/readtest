using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApi.Controllers
{
    public class TokenController : BaseController
    {
        // GET api/values
        public Guid  Get()
        {
            SendRequestToGoogleAnalytics();
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


    }
}
