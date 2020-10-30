using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Rover;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarsOverWebApiController : ControllerBase
    {
        [Route("PostMarsOver/{way}")]
        public IActionResult Index([FromBody] RoverInformation information,string way)
        {
            MarsRover.Rover.Rover marsRover = new Rover.Rover(information.RoverDirection,information.RoverPosition,information.MaxPosition);
            foreach (var item in way)
            {
                if (item == 'L' || item == 'R')
                    marsRover.ChangeDirection(item.ToString());
                else if (item == 'M')
                    marsRover.Move();
            }

            return Ok(marsRover.RoverInformation);
        }
    }
}
