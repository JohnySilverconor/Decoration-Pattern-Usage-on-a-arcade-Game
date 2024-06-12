using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class AbstractPickup<T> : AbstractShape<T>
    {
        private bool _isEaten;
        private Rectangle _occupiedSpace;
        private bool _isFruit;

        public AbstractPickup()
        {
        }

        public AbstractPickup(Point location, int sideSize)
            : base(location, sideSize)
        {
            _isEaten = false;
            _occupiedSpace = new Rectangle(location, new Size(sideSize, sideSize));
        }

        public virtual bool IsEaten
        {
            get
            {
                return _isEaten;
            }
            set
            {
                _isEaten = value;
            }
        }

        public virtual bool IsFruit
        {
            get
            {
                return _isFruit;
            }
            set
            {
                _isFruit = value;
            }
        }
    }
}