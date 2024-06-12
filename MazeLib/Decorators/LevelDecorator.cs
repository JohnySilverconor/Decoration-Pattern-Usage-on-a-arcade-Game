using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class LevelDecorator<T> : AbstractLevel<T>
    {
        protected readonly AbstractLevel<T> _levelToDecorate;

        public LevelDecorator(AbstractLevel<T> levelToDecorate)
        {
            if (levelToDecorate == null)
            {
                throw new ArgumentNullException("levelToDecorate");
            }

            _levelToDecorate = levelToDecorate;
        }

        public override List<AbstractBorder<T>> Borders
        {
            get
            {
                return _levelToDecorate.Borders;
            }
        }

        public override List<AbstractPickup<T>> Pickups
        {
            get
            {
                return _levelToDecorate.Pickups;
            }
        }

        public override List<AbstractGhost<T>> Ghosts
        {
            get
            {
                return _levelToDecorate.Ghosts;
            }
        }

        public override List<DIRECTION> AvailableDirections(Point ghostLocation)
        {
            return _levelToDecorate.AvailableDirections(ghostLocation);
        }

        public override AbstractPlayer<T> Player
        {
            get
            {
                return _levelToDecorate.Player;
            }
            set
            {
                _levelToDecorate.Player = value;
            }
        }

        public override int StepSize
        {
            get
            {
                return _levelToDecorate.StepSize;
            }
        }
    }
}
