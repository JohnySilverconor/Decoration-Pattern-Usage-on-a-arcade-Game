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
    internal class PickupPictureBoxDecorator : PickupDecorator<PictureBox>
    {
        private PictureBox _display;

        public PickupPictureBoxDecorator(AbstractPickup<PictureBox> pickupToDecorate)
            : base(pickupToDecorate)
        {
        }

        public override PictureBox Display
        {
            get
            {
                if (_display == null)
                {
                    if (IsFruit)
                    {
                        _display = new PictureBox()
                        {
                            Location = Location,
                            Size = new Size(SideSize, SideSize),
                            BackColor = Color.CornflowerBlue
                        };
                    }
                    else
                    {
                        _display = new PictureBox()
                        {
                            Location = Location,
                            Size = new Size(SideSize, SideSize),
                            BackColor = Color.Gold
                        };
                    }
                }

                return _display;
            }
            set
            {
                base.Display = value;
            }
        }

        public override bool IsEaten
        {
            get
            {
                return base.IsEaten;
            }
            set
            {
                if (value)
                {
                    if (Display != null)
                    {
                        Display.Visible = false;
                    }
                }
                _pickupToDecorate.IsEaten = value;
            }
        }
    }
}