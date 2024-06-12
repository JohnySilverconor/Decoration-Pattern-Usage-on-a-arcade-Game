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
    public class GhostPictureBoxFacesDecorator : GhostDecorator<PictureBox>
    {
        public GhostPictureBoxFacesDecorator(AbstractGhost<PictureBox> ghostToDecorate)
            : base(ghostToDecorate)
        {
        }

        public override DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            DIRECTION result = _ghostToDecorate.MoveAutomatically(availableDirections);

            if (result == DIRECTION.LEFT)
            {
                if (_ghostToDecorate.Display.BackColor == Color.Red)
                {
                    _ghostToDecorate.Display.Image = Properties.Resources.IMG_GHOST_MOVE_LEFT;
                }

                OnGhostMoved();
            }
            else if (result == DIRECTION.UP)
            {
                if (_ghostToDecorate.Display.BackColor == Color.Red)
                {
                    _ghostToDecorate.Display.Image = Properties.Resources.IMG_GHOST_MOVE_UP;
                }

                OnGhostMoved();
            }
            else if (result == DIRECTION.RIGHT)
            {
                if (_ghostToDecorate.Display.BackColor == Color.Red)
                {
                    _ghostToDecorate.Display.Image = Properties.Resources.IMG_GHOST_MOVE_RIGHT;
                }

                OnGhostMoved();
            }
            else if (result == DIRECTION.DOWN)
            {
                if (_ghostToDecorate.Display.BackColor == Color.Red)
                {
                    _ghostToDecorate.Display.Image = Properties.Resources.IMG_GHOST_MOVE_DOWN;
                }

                OnGhostMoved();
            }

            return result;
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

        public override void OnGhostMoved()
        {
            base.OnGhostMoved();
        }
    }
}