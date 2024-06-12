using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract class GhostDecorator<T> : AbstractGhost<T>
    {
        protected readonly AbstractGhost<T> _ghostToDecorate;

        public GhostDecorator(AbstractGhost<T> ghostToDecorate)
        {
            if (ghostToDecorate == null)
            {
                throw new ArgumentNullException("ghostToDecorate");
            }

            _ghostToDecorate = ghostToDecorate;
        }

        public override void ResetToStartLocation()
        {
            _ghostToDecorate.ResetToStartLocation();
        }

        public override DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            return _ghostToDecorate.MoveAutomatically(availableDirections);
        }

        public override void MoveLeft()
        {
            _ghostToDecorate.MoveLeft();
            OnGhostMoved();
        }

        public override void MoveUp()
        {
            _ghostToDecorate.MoveUp();
            OnGhostMoved();
        }

        public override void MoveRight()
        {
            _ghostToDecorate.MoveRight();
            OnGhostMoved();
        }

        public override void MoveDown()
        {
            _ghostToDecorate.MoveDown();
            OnGhostMoved();
        }

        public override void PauseMoving()
        {
            _ghostToDecorate.PauseMoving();
        }

        public override void ContinueMoving()
        {
            _ghostToDecorate.ContinueMoving();
        }

        public override void StopMoving()
        {
            _ghostToDecorate.StopMoving();
        }

        public override void Die()
        {
            _ghostToDecorate.Die();
        }

        public override Point Location
        {
            get
            {
                return _ghostToDecorate.Location;
            }
        }

        public override Point StartLocation
        {
            get
            {
                return _ghostToDecorate.StartLocation;
            }
        }

        public override DIRECTION CurrentDirection()
        {
            return _ghostToDecorate.CurrentDirection();
        }

        public override int Speed
        {
            get
            {
                return _ghostToDecorate.Speed;
            }
        }

        public override bool Vurneable
        {
            get
            {
                return _ghostToDecorate.Vurneable;
            }
            set
            {
                _ghostToDecorate.Vurneable = value;
            }
        }

        public override bool IsMoving
        {
            get
            {
                return _ghostToDecorate.IsMoving;
            }
            set
            {
                _ghostToDecorate.IsMoving = value;
            }
        }

        public override Rectangle OccupiedSpace
        {
            get
            {
                return _ghostToDecorate.OccupiedSpace;
            }
        }

        public override T Display
        {
            get
            {
                return _ghostToDecorate.Display;
            }
            set
            {
                _ghostToDecorate.Display = value;
            }
        }

        public override void OnGhostMoved()
        {
            base.OnGhostMoved();
        }
    }
}