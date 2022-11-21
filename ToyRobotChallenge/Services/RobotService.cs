using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.Interfaces;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.Services
{
    public class RobotService : IRobotService
    {
        private int _coordX = 0;
        private int _coordY = 0;
        private string _facingDirection = string.Empty;
        private bool _isInitialPlaceCommand;
        public RobotService(int coordX, int coordY, string facingDirection, bool isInitialPlaceCommand)
        {
            _coordX = coordX;
            _coordY = coordY;
            _facingDirection = facingDirection;
            _isInitialPlaceCommand = isInitialPlaceCommand;
        }
        public (int, int, string, bool) ExecuteCommand(CommandRequest request)
        {
            try
            {
                request.Command.ToUpperInvariant();

                if (request.Command == null)
                    throw new NotImplementedException();

                if (request.IsInitialPlaceCommand && !request.Command.StartsWith("PLACE", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new Exception("Please start with the PLACE command e.g PLACE 0,0,NORTH");
                }

                if (request.Command.StartsWith("PLACE", StringComparison.InvariantCultureIgnoreCase))
                {
                    var afterComm = request.Command.Substring(6);
                    Console.WriteLine(afterComm);

                    _coordX = Int32.Parse(afterComm.Substring(0, 1));
                    _coordY = Int32.Parse(afterComm.Substring(2, 1));
                    _isInitialPlaceCommand = false;

                    Helpers.ValidatePoint(_coordX, _coordY);
                    _facingDirection = afterComm.Substring(4);
                }

                if (request.Command == "MOVE")
                {
                    var (x, y) = MovePoint(_facingDirection, _coordX, _coordY);
                    Helpers.ValidatePoint(_coordX, _coordY);
                    _coordX = x;
                    _coordY = y;
                }
                if (request.Command == "LEFT" || request.Command == "RIGHT")
                {
                    _facingDirection = RotatePoint(_facingDirection, request.Command);
                }
                if (request.Command == "REPORT")
                {
                    Helpers.DisplayRobotPosition(_coordX, _coordY, _facingDirection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (_coordX, _coordY, _facingDirection, _isInitialPlaceCommand);
        }
        public string RotatePoint(string currentFaceDirection, string rotateCommand)
        {
            var resultDirection = string.Empty;
            switch (currentFaceDirection)
            {
                case "NORTH":
                    if (rotateCommand == RelativeDirections.Left) resultDirection = CardinalDirections.West;
                    if (rotateCommand == RelativeDirections.Right) resultDirection = CardinalDirections.East;
                    break;
                case "EAST":
                    if (rotateCommand == RelativeDirections.Left) resultDirection = CardinalDirections.North;
                    if (rotateCommand == RelativeDirections.Right) resultDirection = CardinalDirections.South;
                    break;
                case "SOUTH":
                    if (rotateCommand == RelativeDirections.Left) resultDirection = CardinalDirections.East;
                    if (rotateCommand == RelativeDirections.Right) resultDirection = CardinalDirections.West;
                    break;
                case "WEST":
                    if (rotateCommand == RelativeDirections.Left) resultDirection = CardinalDirections.South;
                    if (rotateCommand == RelativeDirections.Right) resultDirection = CardinalDirections.North;
                    break;
                default:
                    resultDirection = rotateCommand;
                    break;
            }
            return resultDirection;
        }
        public (int, int) MovePoint(string currentFaceDirection, int coordX, int coordY)
        {
            switch (currentFaceDirection)
            {
                case "NORTH":
                    coordY = coordY + 1;
                    break;
                case "EAST":
                    coordX = coordX + 1;
                    break;
                case "SOUTH":
                    coordY = coordY - 1;
                    break;
                case "WEST":
                    coordX = coordX - 1;
                    break;
                default:
                    break;
            }
            return (coordX, coordY);
        }
    }
}
