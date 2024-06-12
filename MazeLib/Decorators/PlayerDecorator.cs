using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class PlayerDecorator<T> : AbstractPlayer<T>
    {
        protected readonly AbstractPlayer<T> _playerToDecorate;

        public PlayerDecorator(AbstractPlayer<T> playerToDecorate)
        {
            if (playerToDecorate == null)
            {
                throw new ArgumentNullException("playerToDecorate");
            }

            _playerToDecorate = playerToDecorate;
        }

        public override bool TryMoveLeft(IEnumerable<DIRECTION> AvailableDirections)
        {
            return _playerToDecorate.TryMoveLeft(AvailableDirections);
        }

        public override bool TryMoveUp(IEnumerable<DIRECTION> AvailableDirections)
        {
            return _playerToDecorate.TryMoveUp(AvailableDirections);
        }

        public override bool TryMoveRight(IEnumerable<DIRECTION> AvailableDirections)
        {
            return _playerToDecorate.TryMoveRight(AvailableDirections);
        }

        public override bool TryMoveDown(IEnumerable<DIRECTION> AvailableDirections)
        {
            return _playerToDecorate.TryMoveDown(AvailableDirections);
        }

        public override void MoveLeft()
        {
            _playerToDecorate.MoveLeft();
            OnGhostMoved();
        }

        public override void MoveUp()
        {
            _playerToDecorate.MoveUp();
            OnGhostMoved();
        }

        public override void MoveRight()
        {
            _playerToDecorate.MoveRight();
            OnGhostMoved();
        }

        public override void MoveDown()
        {
            _playerToDecorate.MoveDown();
            OnGhostMoved();
        }

        public override void PauseMoving()
        {
            _playerToDecorate.PauseMoving();
        }

        public override void ContinueMoving()
        {
            _playerToDecorate.ContinueMoving();
        }

        public override void StopMoving()
        {
            _playerToDecorate.StopMoving();
        }

        public override void ResetToStartLocation()
        {
            _playerToDecorate.ResetToStartLocation();
        }

        public override void Die()
        {
            _playerToDecorate.Die();
        }

        public override DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            return _playerToDecorate.MoveAutomatically(availableDirections);
        }

        public override DIRECTION CurrentDirection()
        {
            return _playerToDecorate.CurrentDirection();
        }

        public override System.Drawing.Point Location
        {
            get
            {
                return _playerToDecorate.Location;
            }
        }

        public override int SideSize
        {
            get
            {
                return _playerToDecorate.SideSize;
            }
        }

        public override int Speed
        {
            get
            {
                return _playerToDecorate.Speed;
            }
        }

        public override System.Drawing.Rectangle OccupiedSpace
        {
            get
            {
                return _playerToDecorate.OccupiedSpace;
            }
        }

        public override bool IsMoving
        {
            get
            {
                return _playerToDecorate.IsMoving;
            }
            set
            {
                _playerToDecorate.IsMoving = value;
            }
        }

        public override T Display
        {
            get
            {
                return _playerToDecorate.Display;
            }
            set
            {
                _playerToDecorate.Display = value;
            }
        }

        public override void OnGhostMoved()
        {
            base.OnGhostMoved();
        }
    }
}