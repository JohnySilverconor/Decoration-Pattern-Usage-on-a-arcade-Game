using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class Ghost<T> : AbstractGhost<T>
    {
        public Ghost(int size, int speed, Point location)
            : base(size, speed, location)
        {
            Vurneable = false;
        }
    }
}