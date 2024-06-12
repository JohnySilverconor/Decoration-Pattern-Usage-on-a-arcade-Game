using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class AbstractPlayer<T> : AbstractGhost<T>
    {
        public AbstractPlayer()
            : base()
        {
        }

        public AbstractPlayer(int size, int speed, Point location)
            : base(size, speed, location)
        {
        }

        public abstract bool TryMoveLeft(IEnumerable<DIRECTION> AvailableDirections);
        public abstract bool TryMoveUp(IEnumerable<DIRECTION> AvailableDirections);
        public abstract bool TryMoveRight(IEnumerable<DIRECTION> AvailableDirections);
        public abstract bool TryMoveDown(IEnumerable<DIRECTION> AvailableDirections);

        public override void OnGhostMoved()
        {
            base.OnGhostMoved();
        }
    }
}
