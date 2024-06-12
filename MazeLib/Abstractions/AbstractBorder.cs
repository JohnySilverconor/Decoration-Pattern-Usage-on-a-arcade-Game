using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class AbstractBorder<T> : AbstractShape<T>
    {
        public AbstractBorder()
            : base()
        {
        }

        public AbstractBorder(Point location, int sideSize)
            : base(location, sideSize)
        {
        }

        public override Point Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                base.Location = value;
            }
        }

        public override Rectangle OccupiedSpace
        {
            get
            {
                return base.OccupiedSpace;
            }
        }

        public override int SideSize
        {
            get
            {
                return base.SideSize;
            }
        }

        public override T Display
        {
            get
            {
                return base.Display;
            }
            set
            {
                base.Display = value;
            }
        }
    }
}