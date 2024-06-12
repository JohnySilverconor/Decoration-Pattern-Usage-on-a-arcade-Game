using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class PickupDecorator<T> : AbstractPickup<T>
    {
        protected readonly AbstractPickup<T> _pickupToDecorate;

        public PickupDecorator(AbstractPickup<T> pickupToDecorate)
        {
            if (pickupToDecorate == null)
            {
                throw new ArgumentNullException("pickupToDecorate");
            }

            _pickupToDecorate = pickupToDecorate;
        }

        public override bool IsEaten
        {
            get
            {
                return _pickupToDecorate.IsEaten;
            }
            set
            {
                _pickupToDecorate.IsEaten = value;
            }
        }

        public override System.Drawing.Point Location
        {
            get
            {
                return _pickupToDecorate.Location;
            }
            set
            {
                _pickupToDecorate.Location = value;
            }
        }

        public override System.Drawing.Rectangle OccupiedSpace
        {
            get
            {
                return _pickupToDecorate.OccupiedSpace;
            }
        }

        public override int SideSize
        {
            get
            {
                return _pickupToDecorate.SideSize;
            }
        }

        public override bool IsFruit
        {
            get
            {
                return _pickupToDecorate.IsFruit;
            }
            set
            {
                _pickupToDecorate.IsFruit = value;
            }
        }

        public override T Display
        {
            get
            {
                return _pickupToDecorate.Display;
            }
            set
            {
                _pickupToDecorate.Display = value;
            }
        }
    }
}