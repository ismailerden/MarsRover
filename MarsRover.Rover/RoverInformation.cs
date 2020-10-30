using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Rover
{
    public class RoverInformation
    {
        public RoverDirectionEnum RoverDirection { get; set; }
        public RoverPosition RoverPosition { get; set; }
        public RoverPosition MaxPosition { get; set; }
    }
}
