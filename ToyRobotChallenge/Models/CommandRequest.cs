using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge.Models
{
    public class CommandRequest
    {
        public bool IsInitialPlaceCommand { get; set; } = true;
        public int CoordX { get; set; } = 0;
        public int CoordY { get; set; } = 0;
        public string FacingDirection { get; set; }
        public string Command { get; set; }
    }
}
