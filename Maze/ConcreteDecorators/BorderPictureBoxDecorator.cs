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
    internal class BorderPictureBoxDecorator : BorderDecorator<PictureBox>
    {
        private PictureBox _display;

        public BorderPictureBoxDecorator(AbstractBorder<PictureBox> borderToDecorate)
            : base(borderToDecorate)
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
                        Size = OccupiedSpace.Size,
                        BackColor = Color.Green
                    };
                }

                return _display;
            }
            set
            {
                base.Display = value;
            }
        }
    }
}