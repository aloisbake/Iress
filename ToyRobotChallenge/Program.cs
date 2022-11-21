using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.Models;
using ToyRobotChallenge.Services;

namespace ToyRobotChallenge
{
    public class Program
    {
        static bool isInitialPlaceCommand = true;
        static int coordX = 0;
        static int coordY = 0;
        static string facingDirection = string.Empty;
        static void Main(string[] args)
        {
            Console.WriteLine($"*************************************************************");
            Console.WriteLine($"************* Toy Robot Challege Application ***************");
            Console.WriteLine($"*********************** ALOIS BAKE **************************");
            Console.WriteLine($"*************************************************************");
            bool RequestCommands = true;

            RobotService robotService = new RobotService(coordX, coordY, facingDirection, isInitialPlaceCommand);

            while (RequestCommands) {                
                
                Console.WriteLine("Enter command");
                var command = Console.ReadLine();

                CommandRequest request = new CommandRequest
                {
                    IsInitialPlaceCommand = isInitialPlaceCommand,
                    CoordX = coordX,
                    CoordY = coordY,
                    FacingDirection = facingDirection,
                    Command = command
                };

                var (x, y, f, isInitComm) = robotService.ExecuteCommand(request);
                coordX = x;
                coordY = y;
                facingDirection = f;
                isInitialPlaceCommand = isInitComm;                
            }           
        }
        
    }
}
