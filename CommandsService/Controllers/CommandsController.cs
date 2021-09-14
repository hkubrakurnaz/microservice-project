using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        public CommandsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection(){
            Console.WriteLine("--> Inbound POST Command Service");
            return Ok("Inbound test of from platforms controller");
        }
    }
}