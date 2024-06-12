using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class Pickup<T> : AbstractPickup<T>
    {
        public Pickup(Point location, int size)
            : base(location, size)
        {
        }
    }
}
