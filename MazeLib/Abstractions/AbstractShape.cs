using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class AbstractShape<T>
    {
        private int _sideSize;
        private Point _location;
        private T _display;

        public AbstractShape()
        {
        }

        public AbstractShape(Point location, int sideSize)
        {
            _location = location;
            _sideSize = sideSize;
        }

        public virtual Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public virtual int SideSize
        {
            get
            {
                return _sideSize;
            }
        }

        public virtual Rectangle OccupiedSpace
        {
            get
            {
                return new Rectangle(_location, new Size(_sideSize, _sideSize));
            }
        }

        public virtual T Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
            }
        }
    }
}
