using MarsRover.Rover;
using System;
using System.Linq;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input max x,y. Example:4,5");
            string maxArea = Console.ReadLine();
            while (!IsMaxAreaCorrect(maxArea))
            {
                Console.WriteLine("Please input max x,y. Example:4,5");
                maxArea = Console.ReadLine();
            }

            Console.WriteLine("Please input start position. Example:1,2,N");
            string position = Console.ReadLine();
            while (!IsPositionCorrect(position))
            {
                Console.WriteLine("Please input start position.Example:1,2,N");
                position = Console.ReadLine();
            }

            Console.WriteLine("Please input move. Example:LLMMRMRRMMM");
            string moveRover = Console.ReadLine();
            while (!IsMoveCorrect(moveRover))
            {
                Console.WriteLine("Please input move. Example:LLMMRMRRMMM");
                moveRover = Console.ReadLine();
            }
            RoverPosition roverPosition = new RoverPosition() { X = Convert.ToInt32(position.Split(',')[0]), Y = Convert.ToInt32(position.Split(',')[1]) };
            RoverPosition roverMaxPosition = new RoverPosition() { X = Convert.ToInt32(maxArea.Split(',')[0]), Y = Convert.ToInt32(maxArea.Split(',')[1]) };
            RoverDirectionEnum roverDirection = RoverDirectionEnum.North;
            switch (position.Split(',')[2])
            {
                case "N":
                    roverDirection = RoverDirectionEnum.North;
                    break;
                case "E":
                    roverDirection = RoverDirectionEnum.East;
                    break;
                case "S":
                    roverDirection = RoverDirectionEnum.South;
                    break;
                case "W":
                    roverDirection = RoverDirectionEnum.West;
                    break;
            }

            MarsRover.Rover.Rover mainRover = new MarsRover.Rover.Rover(roverDirection, roverPosition, roverMaxPosition);
            foreach (var item in moveRover)
            {
                if (item == 'L' || item == 'R')
                    mainRover.ChangeDirection(item.ToString());
                else if (item == 'M')
                    mainRover.Move();
            }
            Console.WriteLine("Rover Position: {0} {1} {2}", mainRover.RoverInformation.RoverPosition.X, mainRover.RoverInformation.RoverPosition.Y, mainRover.RoverInformation.RoverDirection.ToString());
        }
        private static bool IsMaxAreaCorrect(string input)
        {
            if (input.Split(',').Length != 2)
                return false;
            int areaValue = 0;
            int.TryParse(input.Split(',')[0], out areaValue);
            if (areaValue <= 0)
                return false;
            areaValue = 0;
            int.TryParse(input.Split(',')[1], out areaValue);
            if (areaValue <= 0)
                return false;
            return true;
        }
        private static bool IsPositionCorrect(string input)
        {
            if (input.Split(',').Length != 3)
                return false;
            int areaValue = 0;
            int.TryParse(input.Split(',')[0], out areaValue);
            if (areaValue <= 0)
                return false;
            areaValue = 0;
            int.TryParse(input.Split(',')[1], out areaValue);
            if (areaValue <= 0)
                return false;
            string[] allowedDirection = { "N", "E", "W", "S" };
            if (!allowedDirection.Contains(input.Split(',')[2]))
                return false;
            return true;
        }
        private static bool IsMoveCorrect(string input)
        {
            string[] allowedDirection = { "L", "R", "M" };
            if (input.ToList().Count(f => !allowedDirection.Contains(f.ToString())) > 0)
                return false;
            return true;
        }
    }
}
