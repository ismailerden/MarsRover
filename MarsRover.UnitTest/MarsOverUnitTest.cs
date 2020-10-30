using MarsRover.Rover;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MarsRover.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestScanrio_12N_LMLMLMLMM()
        {
            RoverPosition roverPosition = new RoverPosition() { X = 1, Y = 2 };
            RoverPosition maxPosition = new RoverPosition() { X = 5, Y = 5 };
            RoverDirectionEnum roverDirection = RoverDirectionEnum.North;

            MarsRover.Rover.Rover rover = new Rover.Rover(roverDirection, roverPosition, maxPosition);

            foreach (var item in "LMLMLMLMM")
            {
                if (item == 'L' || item == 'R')
                    rover.ChangeDirection(item.ToString());
                else if (item == 'M')
                    rover.Move();
            }

            RoverInformation targetInformation = new RoverInformation();
            targetInformation.MaxPosition = new RoverPosition();
            targetInformation.RoverPosition = new RoverPosition();
            targetInformation.MaxPosition.X = 5;
            targetInformation.MaxPosition.Y = 5;
            targetInformation.RoverPosition.X = 1;
            targetInformation.RoverPosition.Y = 3;
            targetInformation.RoverDirection = RoverDirectionEnum.North;
            Assert.AreEqual(rover.RoverInformation.MaxPosition.X, targetInformation.MaxPosition.X);
            Assert.AreEqual(rover.RoverInformation.MaxPosition.Y, targetInformation.MaxPosition.Y);
            Assert.AreEqual(rover.RoverInformation.RoverPosition.X, targetInformation.RoverPosition.X);
            Assert.AreEqual(rover.RoverInformation.RoverPosition.Y, targetInformation.RoverPosition.Y);
            Assert.AreEqual(rover.RoverInformation.RoverDirection, targetInformation.RoverDirection);
        }

        [Test]
        public void TestScanrio_33E_MMRMMRMRRM()
        {
            RoverPosition roverPosition = new RoverPosition() { X = 3, Y = 3 };
            RoverPosition maxPosition = new RoverPosition() { X = 5, Y = 5 };
            RoverDirectionEnum roverDirection = RoverDirectionEnum.East;

            MarsRover.Rover.Rover rover = new Rover.Rover(roverDirection, roverPosition, maxPosition);

            foreach (var item in "MMRMMRMRRM")
            {
                if (item == 'L' || item == 'R')
                    rover.ChangeDirection(item.ToString());
                else if (item == 'M')
                    rover.Move();
            }

            RoverInformation targetInformation = new RoverInformation();
            targetInformation.MaxPosition = new RoverPosition();
            targetInformation.RoverPosition = new RoverPosition();
            targetInformation.MaxPosition.X = 5;
            targetInformation.MaxPosition.Y = 5;
            targetInformation.RoverPosition.X = 5;
            targetInformation.RoverPosition.Y = 1;
            targetInformation.RoverDirection = RoverDirectionEnum.East;
            Assert.AreEqual(rover.RoverInformation.MaxPosition.X, targetInformation.MaxPosition.X);
            Assert.AreEqual(rover.RoverInformation.MaxPosition.Y, targetInformation.MaxPosition.Y);
            Assert.AreEqual(rover.RoverInformation.RoverPosition.X, targetInformation.RoverPosition.X);
            Assert.AreEqual(rover.RoverInformation.RoverPosition.Y, targetInformation.RoverPosition.Y);
            Assert.AreEqual(rover.RoverInformation.RoverDirection, targetInformation.RoverDirection);
        }
        [Test]
        public void TestScanrio_WestException()
        {
            RoverPosition roverPosition = new RoverPosition() { X = 0, Y = 0 };
            RoverPosition maxPosition = new RoverPosition() { X = 5, Y = 5 };
            RoverDirectionEnum roverDirection = RoverDirectionEnum.West;

            MarsRover.Rover.Rover rover = new Rover.Rover(roverDirection, roverPosition, maxPosition);


            Assert.Throws<IndexOutOfRangeException>(()=> rover.Move());

        }
        [Test]
        public void TestScanrio_SouthException()
        {
            RoverPosition roverPosition = new RoverPosition() { X = 0, Y = 0 };
            RoverPosition maxPosition = new RoverPosition() { X = 5, Y = 5 };
            RoverDirectionEnum roverDirection = RoverDirectionEnum.South;

            MarsRover.Rover.Rover rover = new Rover.Rover(roverDirection, roverPosition, maxPosition);

            Assert.Throws<IndexOutOfRangeException>(() => rover.Move());

        }
    }
}