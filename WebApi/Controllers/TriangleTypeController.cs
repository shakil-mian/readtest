using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebApi.Controllers
{
    public class TriangleTypeController : BaseController
    {
        // GET api/values
        public string Get([FromUri]string a = null, [FromUri]string b = null, [FromUri]string c = null)
        {
            return a;
        }

        // GET api/values/5
        public string Get(int a, int b, int c)
        {
            SendRequestToGoogleAnalytics();
            string triType = "";
            if (!isValidTriangle(a,b,c))
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
                }
            }
            return triType;
        }

        private static bool isValidTriangle(int a, int b, int c)
        {
            bool isvalid = true;
            if (a < 1 || b < 1 || c < 1)
            {
                isvalid = false;
            }

            int[] sides = new int[3];
            sides[0] = a;
            sides[1] = b;
            sides[2] = c;
            Array.Sort(sides);
            if (sides[0] + sides[1] <= sides[2])
            {
                isvalid = false;
            }

            return isvalid;
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


    }
}
