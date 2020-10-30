using System;

namespace MarsRover.Rover
{
    public class Rover
    {
        private RoverInformation _roverInformation { get; set; }
        public Rover(RoverDirectionEnum initDirection, RoverPosition initPosition, RoverPosition maxPosition)
        {
            _roverInformation = new RoverInformation();
            _roverInformation.RoverDirection = initDirection;
            _roverInformation.RoverPosition = initPosition;
            _roverInformation.MaxPosition = maxPosition;
        }
        public void ChangeDirection(string way)
        {
            int intDirection = (int)this._roverInformation.RoverDirection;
            if (way == "L")
            {
                intDirection = intDirection -1;
                if (intDirection == 0)
                    intDirection = 4;
            }
            else if (way == "R")
            {
                intDirection = intDirection + 1;
                if (intDirection == 5)
                    intDirection = 1;
            }
            this._roverInformation.RoverDirection = (RoverDirectionEnum)intDirection;
        }
        public void Move()
        {
            switch (_roverInformation.RoverDirection)
            {
                case RoverDirectionEnum.North:
                    _roverInformation.RoverPosition.Y += 1;
                    break;
                case RoverDirectionEnum.East:
                    _roverInformation.RoverPosition.X += 1;
                    break;
                case RoverDirectionEnum.South:
                    _roverInformation.RoverPosition.Y -= 1;
                    break;
                case RoverDirectionEnum.West:
                    _roverInformation.RoverPosition.X -= 1;
                    break;
            }

            if (_roverInformation.RoverPosition.X < 0 || _roverInformation.RoverPosition.Y < 0)
                throw new IndexOutOfRangeException("Out of area");

            if (_roverInformation.RoverPosition.X > _roverInformation.MaxPosition.X || _roverInformation.RoverPosition.Y > _roverInformation.MaxPosition.Y)
                throw new IndexOutOfRangeException("Out of area");

        }
        public RoverInformation RoverInformation { get { return _roverInformation; } }
    }
}
