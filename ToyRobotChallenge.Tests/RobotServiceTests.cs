using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToyRobotChallenge.Models;
using ToyRobotChallenge.Services;

namespace ToyRobotChallenge.Tests
{
    [TestClass]
    public class RobotServiceTests
    {
        [TestMethod]
        public void Test_ExecuteCommand_Method()
        {
            RobotService rs = new RobotService(0, 0, "NORTH", true);
            var (x,y,z,n) = rs.ExecuteCommand(new CommandRequest
            {
                CoordX = 0,
                CoordY = 0,
                FacingDirection = "NORTH",
                IsInitialPlaceCommand = true,
                Command = "PLACE 0,0,NORTH"
            });
            Assert.IsTrue(x==0);
            Assert.IsTrue(x == 0);
        }

        [TestMethod]
        public void Test_RotatePoint_Method()
        {
            RobotService rs = new RobotService(0, 0, "NORTH", true);
            var value = rs.RotatePoint("NORTH", "RIGHT");
            Assert.IsTrue(value == "EAST");
        }

        [TestMethod]
        public void Test_MovePoint_Method()
        {
            RobotService rs = new RobotService(0, 0, "NORTH", true);
            var (a, b, c, d) = rs.ExecuteCommand(new CommandRequest
            {
                CoordX = 0,
                CoordY = 0,
                FacingDirection = "NORTH",
                IsInitialPlaceCommand = true,
                Command = "PLACE 0,0,NORTH"
            });
            var value = rs.RotatePoint("NORTH", "RIGHT");
            var (x,y) = rs.MovePoint(value,0,0);
            Assert.IsTrue(x == 1);
            Assert.IsTrue(y == 0);
        }
    }
}
