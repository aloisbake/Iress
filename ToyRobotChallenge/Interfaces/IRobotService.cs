using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.Interfaces
{
    public interface IRobotService
    {
        (int, int, string, bool) ExecuteCommand(CommandRequest request);
        string RotatePoint(string currentFaceDirection, string rotateCommand);
        (int, int) MovePoint(string currentFaceDirection, int coordX, int coordY);
    }
}
