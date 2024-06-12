using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class BorderDecorator<T> : AbstractBorder<T>
    {
        protected readonly AbstractBorder<T> _borderToDecorate;

        public BorderDecorator(AbstractBorder<T> borderToDecorate)
        {
            if (borderToDecorate == null)
            {
                throw new ArgumentNullException("borderToDecorate");
            }

            _borderToDecorate = borderToDecorate;
        }

        public override Point Location
        {
            get
            {
                return _borderToDecorate.Location;
            }
            set
            {
                _borderToDecorate.Location = value;
            }
        }

        public override Rectangle OccupiedSpace
        {
            get
            {
                return _borderToDecorate.OccupiedSpace;
            }
        }

        public override int SideSize
        {
            get
            {
                return _borderToDecorate.SideSize;
            }
        }

        public override T Display
        {
            get
            {
                return _borderToDecorate.Display;
            }
            set
            {
                _borderToDecorate.Display = value;
            }
        }
    }
}