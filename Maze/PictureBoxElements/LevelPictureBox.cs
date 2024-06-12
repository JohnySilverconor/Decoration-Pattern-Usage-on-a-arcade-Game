using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public class LevelPictureBox : AbstractLevel<PictureBox>
    {
        public LevelPictureBox(int stepSize, AbstractPlayer<PictureBox> pictureBox,
            List<AbstractBorder<PictureBox>> borders, List<AbstractPickup<PictureBox>> pickups, List<AbstractGhost<PictureBox>> ghosts)
            : base(stepSize, pictureBox, borders, pickups, ghosts)
        {
        }
    }
}