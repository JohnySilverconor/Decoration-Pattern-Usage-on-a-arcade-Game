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
    internal class GhostPictureBoxDecorator : GhostDecorator<PictureBox>
    {
        private PictureBox _display;

        public GhostPictureBoxDecorator(AbstractGhost<PictureBox> ghostToDecorate)
            : base(ghostToDecorate)
        {
            ghostToDecorate.GhostMoved += (sender, e) =>
            {
                Display.Location = e.Location;
            };
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
                        Size = OccupiedSpace.Size,
                        BackColor = Color.Red
                    };
                }

                return _display;
            }
            set
            {
                base.Display = value;
            }
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

        public override DIRECTION MoveAutomatically(IEnumerable<DIRECTION> availableDirections)
        {
            DIRECTION result = _ghostToDecorate.MoveAutomatically(availableDirections);

            if (result != DIRECTION.NONE)
            {
                OnGhostMoved();
            }

            return result;
        }

        public override void OnGhostMoved()
        {
            base.OnGhostMoved();
        }
    }
}