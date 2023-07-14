using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Policy;

namespace NBAGraphs.Controllers
{
    public class PlayerController : ControllerBase
    {
        // GET: PlayerController
        public static HttpWebResponse GetPlayer(string id)
        {
            HttpWebRequest httpRequest = HttpWebRequest.Create(id);
            httpRequest.Method = "GET";

            return httpRequest.GetResponse();
        }

        // POST: PlayerController
       
    }
}
