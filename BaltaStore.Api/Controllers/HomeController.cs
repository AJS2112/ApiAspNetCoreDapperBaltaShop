using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        public string Get()
        {
            return "Hello World!";
        }
    }
}
