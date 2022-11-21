using System;
using System.Linq;

namespace ToyRobotChallenge
{
    public static class Helpers
    {

        public static void DisplayRobotPosition(int coordX, int coordY, string facingDirection)
        {
            Console.WriteLine($"************* Report ***************");
            Console.WriteLine($"Robot at Point : ({coordX},{coordY})");
            Console.WriteLine($"Facing Direction : {facingDirection}");
            Console.WriteLine($"************* Report ***************");
        }

        public static bool ValidatePoint(int coordX, int coordY)
        {
            if (Enumerable.Range(0, 5).Contains(coordX) && Enumerable.Range(0, 5).Contains(coordY))
                return true;

            throw new Exception("The point is invalid, hence need to re-enter PLACE command");
        }
    }
}