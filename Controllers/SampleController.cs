using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendExperimental.Controllers
{
    [ApiController]
    public class SampleController : ControllerBase {
        [HttpGet]
        [Route(Constants.API_HEADER + "ping")]
        public String getResponse() => "pong";

        [HttpGet]
        [Route(Constants.API_HEADER + "hello")]
        public String getHelloWithName(String name) => "Hello " + name;
    }
}