using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class AbstractLevel<T>
    {
        protected int _stepSize;
        protected AbstractPlayer<T> _player;
        protected List<AbstractBorder<T>> _borders;
        protected List<AbstractPickup<T>> _pickups;
        protected List<AbstractGhost<T>> _ghosts;

        public event EventHandler<AbstractLevel<T>> LevelCompleted;

        internal AbstractLevel()
        {
        }

        public AbstractLevel(int stepSize, AbstractPlayer<T> player, List<AbstractBorder<T>> borders,
        List<AbstractPickup<T>> pickups, List<AbstractGhost<T>> ghosts)
        {
            _stepSize = stepSize;

            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            if (borders == null)
            {
                throw new ArgumentNullException("borders");
            }

            if (pickups == null)
            {
                throw new ArgumentNullException("pickups");
            }

            if (ghosts == null)
            {
                throw new ArgumentNullException("ghosts");
            }

            _player = player;
            _player.GhostMoved += _player_GhostMoved;

            _borders = borders;
            _pickups = pickups;
            _ghosts = ghosts;

            _ghosts.ForEach(t => t.GhostMoved += AbstractLevel_GhostMoved);
        }

        public virtual int StepSize
        {
            get
            {
                return _stepSize;
            }
        }

        public virtual AbstractPlayer<T> Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }

        public virtual List<AbstractBorder<T>> Borders
        {
            get
            {
                return _borders;
            }
        }
        public virtual List<AbstractPickup<T>> Pickups
        {
            get
            {
                return _pickups;
            }
        }

        public virtual List<AbstractGhost<T>> Ghosts
        {
            get
            {
                return _ghosts;
            }
        }

        public virtual List<DIRECTION> AvailableDirections(Point ghostLocation)
        {
            List<DIRECTION> result = new List<DIRECTION>();

            if (CanGoLeft(ghostLocation))
            {
                result.Add(DIRECTION.LEFT);
            }
            if (CanGoUp(ghostLocation))
            {
                result.Add(DIRECTION.UP);
            }
            if (CanGoRight(ghostLocation))
            {
                result.Add(DIRECTION.RIGHT);
            }
            if (CanGoDown(ghostLocation))
            {
                result.Add(DIRECTION.DOWN);
            }

            return result;
        }


        //   x,y ---------------> x + stepSize, y
        //   |
        //   |
        //   |
        //   |
        //   V x, y + stepSize   x + stepSize, y + stepSize

        // topLeft = x, y
        // topRight = x + _stepSize, y
        // bottomLeft x, y + _stepSize
        // bottomRight x + _stepSize, y + _stepSize

        // Check if full ghost can go through - check top and bottom right corner
        //   * - - X   =>
        //   |     |   =>
        //   |     |   =>
        //   * - - X   =>
        private bool CanGoRight(Point point)
        {
            Point topRight = new Point(point.X + StepSize, point.Y + 1);
            Point bottomRight = new Point(point.X + StepSize, point.Y + StepSize - 1);

            // since we check for right, we ADD 1 to x
            topRight.X++;
            bottomRight.X++;

            return !Borders.Any(t => t.OccupiedSpace.Contains(topRight) || t.OccupiedSpace.Contains(bottomRight));
        }

        // Check if full ghost can go through - check top and bottom right corner
        //  <=   X - - *
        //  <=   |     |
        //  <=   |     |
        //  <=   X - - *
        private bool CanGoLeft(Point point)
        {
            Point topLeft = new Point(point.X, point.Y + 1);
            Point bottomLeft = new Point(point.X, point.Y + StepSize - 1);

            // since we check for right, we SUBSTRACT 1 from x

            topLeft.X--;
            bottomLeft.X--;

            return !Borders.Any(t => t.OccupiedSpace.Contains(topLeft) || t.OccupiedSpace.Contains(bottomLeft));
        }

        // Check if full ghost can go through - check bottom left and right corner 
        //  * - - *
        //  |     |
        //  |     |
        //  X - - X
        //
        //  | | | |
        //  V V V V
        private bool CanGoDown(Point point)
        {
            Point bottomLeft = new Point(point.X + 1, point.Y + StepSize);
            Point bottomRight = new Point(point.X + StepSize - 1, point.Y + StepSize);

            // since we check for down, we ADD one to y

            bottomLeft.Y++;
            bottomRight.Y++;

            return !Borders.Any(t => t.OccupiedSpace.Contains(bottomLeft) || t.OccupiedSpace.Contains(bottomRight));
        }

        // Check if full ghost can go through - check top left and right corner
        //  A A A A 
        //  | | | |
        //
        //  X - - X
        //  |     |
        //  |     |
        //  * - - * 
        private bool CanGoUp(Point point)
        {
            Point topLeft = new Point(point.X + 1, point.Y);
            Point topRight = new Point(point.X + StepSize - 1, point.Y);

            // since we check for up, we SUBSTRACT 1 from y

            topLeft.Y--;
            topRight.Y--;

            return !Borders.Any(t => t.OccupiedSpace.Contains(topLeft) || t.OccupiedSpace.Contains(topRight));
        }

        protected virtual void AbstractLevel_GhostMoved(object sender, AbstractGhost<T> e)
        {
            if (e.OccupiedSpace.IntersectsWith(_player.OccupiedSpace))
            {
                if (e.Vurneable)
                {
                    e.Die();
                }
                else
                {
                    Player.Die();
                }
            }
        }

        protected virtual void onLevelCompleted()
        {
            if (Ghosts != null)
            {
                Ghosts.FindAll(t => t.IsMoving).ForEach(t => t.StopMoving());
            }

            if (_player != null)
            {
                _player.StopMoving();
            }

            if (LevelCompleted != null)
            {
                LevelCompleted(this, this);
            }
        }

        protected virtual void _player_GhostMoved(object sender, AbstractGhost<T> e)
        {
            if (Pickups != null)
            {
                AbstractPickup<T> pickup = Pickups.Find(t => !t.IsEaten && t.OccupiedSpace.IntersectsWith(e.OccupiedSpace));
                if (pickup != null)
                {
                    pickup.IsEaten = true;
                }

                int uneatenCount = Pickups.Count(t => t.IsEaten == false);

                if (uneatenCount == 0)
                {
                    onLevelCompleted();
                }
            }
        }
    }
}