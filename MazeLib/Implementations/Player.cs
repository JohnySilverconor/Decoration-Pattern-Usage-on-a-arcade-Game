using MazeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class Player<T> : AbstractPlayer<T>
    {
        public Player()
            : base()
        {
        }

        public Player(int size, int speed, Point location)
            : base(size, speed, location)
        {
            Vurneable = true;
        }

        public override bool TryMoveLeft(IEnumerable<DIRECTION> AvailableDirections)
        {
            if (AvailableDirections != null && AvailableDirections.Contains(DIRECTION.LEFT))
            {
                MoveLeft();
                OnGhostMoved();
                return true;
            }

            return false;
        }

        public override bool TryMoveUp(IEnumerable<DIRECTION> AvailableDirections)
        {
            if (AvailableDirections != null && AvailableDirections.Contains(DIRECTION.UP))
            {
                MoveUp();
                OnGhostMoved();
                return true;
            }

            return false;
        }

        public override bool TryMoveRight(IEnumerable<DIRECTION> AvailableDirections)
        {
            if (AvailableDirections != null && AvailableDirections.Contains(DIRECTION.RIGHT))
            {
                MoveRight();
                OnGhostMoved();
                return true;
            }

            return false;
        }

        public override bool TryMoveDown(IEnumerable<DIRECTION> AvailableDirections)
        {
            if (AvailableDirections != null && AvailableDirections.Contains(DIRECTION.DOWN))
            {
                MoveDown();
                OnGhostMoved();
                return true;
            }

            return false;
        }

        public override DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            if (CurrentDirection() == DIRECTION.LEFT)
            {
                if (TryMoveLeft(availableDirections))
                {
                    return DIRECTION.LEFT;
                }
            }
            else if (CurrentDirection() == DIRECTION.UP)
            {
                if (TryMoveUp(availableDirections))
                {
                    return DIRECTION.UP;
                }
            }
            else if (CurrentDirection() == DIRECTION.RIGHT)
            {
                if (TryMoveRight(availableDirections))
                {
                    return DIRECTION.RIGHT;
                }
            }
            else if (CurrentDirection() == DIRECTION.DOWN)
            {
                if (TryMoveDown(availableDirections))
                {
                    return DIRECTION.DOWN;
                }
            }

            return DIRECTION.NONE;
        }
    }
}