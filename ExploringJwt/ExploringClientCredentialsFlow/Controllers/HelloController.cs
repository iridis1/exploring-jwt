﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExploringClientCredentialsFlow.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet(Name = "hello")]
        public string SayHello() => "Hello";
    }
}
