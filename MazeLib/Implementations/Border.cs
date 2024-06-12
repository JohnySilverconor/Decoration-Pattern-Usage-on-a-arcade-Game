using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class Border<T> : AbstractBorder<T>
    {
        private Size? _size;

        public Border(Point location, int sideSize, Size? size = null)
            : base(location, sideSize)
        {
            _size = size;
        }

        public override Rectangle OccupiedSpace
        {
            get
            {
                if (_size.HasValue)
                {
                    return new Rectangle(Location, _size.Value);
                }

                return base.OccupiedSpace;
            }
        }
    }
}
