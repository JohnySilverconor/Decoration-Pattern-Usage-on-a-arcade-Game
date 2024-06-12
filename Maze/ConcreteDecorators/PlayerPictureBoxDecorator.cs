using MazeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    internal class PlayerPictureBoxDecorator : PlayerDecorator<PictureBox>
    {
        private PictureBox _display;

        public PlayerPictureBoxDecorator(AbstractPlayer<PictureBox> playerToDecorate)
            : base(playerToDecorate)
        {
        }

        public override PictureBox Display
        {
            get
            {
                if (_display == null)
                {
                    _display = new PictureBox()
                    {
                        Location = Location,
                        BackColor = Color.Blue,
                        Size = OccupiedSpace.Size
                    };
                }

                return _display;
            }
            set
            {
                base.Display = value;
            }
        }

        public override bool TryMoveLeft(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveLeft(AvailableDirections);

            if (result)
            {
                OnGhostMoved();
            }

            return result;
        }

        public override bool TryMoveUp(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveUp(AvailableDirections);

            if (result)
            {
                OnGhostMoved();
            }

            return result;
        }

        public override bool TryMoveRight(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveRight(AvailableDirections);

            if (result)
            {
                OnGhostMoved();
            }

            return result;
        }

        public override bool TryMoveDown(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveDown(AvailableDirections);

            if (result)
            {
                OnGhostMoved();
            }

            return result;
        }

        public override DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            DIRECTION result = _playerToDecorate.MoveAutomatically(availableDirections);

            if (result != DIRECTION.NONE)
            {
                OnGhostMoved();
            }

            return result;
        }

        public override void OnGhostMoved()
        {
            base.OnGhostMoved();
            Display.Location = this.Location;
        }
    }
}