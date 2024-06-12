using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public abstract partial class AbstractGhost<T> : AbstractShape<T>
    {
        private int _speed;
        private int _speedX;
        private int _speedY;
        private bool _vurneable;
        private Point _startLocation;
        private bool _isMoving;
        private List<Action> _movementActions;

        private int _speedBeforeStop;
        private int _speedXBeforeStop;
        private int _speedYBeforeStop;

        public event EventHandler<AbstractGhost<T>> GhostMoved;

        public AbstractGhost()
            : base()
        {
        }

        public AbstractGhost(int sideSize, int speed, Point location)
            : base(location, sideSize)
        {
            _speed = speed;
            _speedX = 0;
            _speedY = 0;

            _startLocation = location;
            _movementActions = new List<Action>();

            _isMoving = true;
        }

        public virtual Point StartLocation
        {
            get
            {
                return _startLocation;
            }
        }

        public virtual int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public virtual bool Vurneable
        {
            get
            {
                return _vurneable;
            }
            set
            {
                _vurneable = value;
            }
        }

        public virtual bool IsMoving
        {
            get
            {
                return _isMoving;
            }
            set
            {
                _isMoving = value;
            }
        }

        public virtual void MoveRight()
        {
            _speedX = _speed;
            _speedY = 0;
            UpdateCurrentPoint();
            OnGhostMoved();
        }

        public virtual void MoveLeft()
        {
            _speedX = -_speed;
            _speedY = 0;
            UpdateCurrentPoint();
            OnGhostMoved();
        }

        public virtual void MoveDown()
        {
            _speedX = 0;
            _speedY = _speed;
            UpdateCurrentPoint();
            OnGhostMoved();
        }

        public virtual void MoveUp()
        {
            _speedX = 0;
            _speedY = -_speed;
            UpdateCurrentPoint();
            OnGhostMoved();
        }

        public virtual void PauseMoving()
        {
            if (_isMoving)
            {
                _speedBeforeStop = _speed;
                _speedXBeforeStop = _speedX;
                _speedYBeforeStop = _speedY;

                _speed = 0;
                _speedX = 0;
                _speedY = 0;
            }

            IsMoving = false;
        }

        public virtual void ContinueMoving()
        {
            _speed = _speedBeforeStop;
            _speedX = _speedXBeforeStop;
            _speedY = _speedYBeforeStop;

            IsMoving = true;
        }

        public virtual void StopMoving()
        {
            _speed = 0;
            _speedX = 0;
            _speedY = 0;

            _speedBeforeStop = 0;
            _speedXBeforeStop = 0;
            _speedYBeforeStop = 0;

            IsMoving = false;
        }

        public virtual DIRECTION CurrentDirection()
        {
            if (_speedX == _speed && _speedY == 0)
            {
                return DIRECTION.RIGHT;
            }

            if (_speedX == -_speed && _speedY == 0)
            {
                return DIRECTION.LEFT;
            }

            if (_speedY == _speed && _speedX == 0)
            {
                return DIRECTION.DOWN;
            }

            if (_speedY == -_speed && _speedX == 0)
            {
                return DIRECTION.UP;
            }

            return DIRECTION.NONE;
        }

        public virtual void Die()
        {
            ResetToStartLocation();
        }

        public virtual void ResetToStartLocation()
        {
            Location = _startLocation;
        }

        public virtual DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            _movementActions.Clear();

            foreach (var direction in availableDirections)
            {
                if (direction == DIRECTION.LEFT && CurrentDirection() != DIRECTION.RIGHT)
                    _movementActions.Add(MoveLeft);
                if (direction == DIRECTION.UP && CurrentDirection() != DIRECTION.DOWN)
                    _movementActions.Add(MoveUp);
                if (direction == DIRECTION.RIGHT && CurrentDirection() != DIRECTION.LEFT)
                    _movementActions.Add(MoveRight);
                if (direction == DIRECTION.DOWN && CurrentDirection() != DIRECTION.UP)
                    _movementActions.Add(MoveDown);
            }

            Random rand = new Random();
            if (_movementActions.Count != 0)
            {
                int index = rand.Next(0, _movementActions.Count);
                _movementActions[index]();

                if (_movementActions[index] == MoveLeft)
                {
                    return DIRECTION.LEFT;
                }
                else if (_movementActions[index] == MoveUp)
                {
                    return DIRECTION.UP;
                }
                else if (_movementActions[index] == MoveRight)
                {
                    return DIRECTION.RIGHT;
                }
                else if (_movementActions[index] == MoveDown)
                {
                    return DIRECTION.DOWN;
                }
            }

            return DIRECTION.NONE;
        }

        public virtual void OnGhostMoved()
        {
            this.Raise(this, ref GhostMoved);
        }

        private void UpdateCurrentPoint()
        {
            Location = new Point(Location.X + _speedX, Location.Y + _speedY);
        }
    }
}