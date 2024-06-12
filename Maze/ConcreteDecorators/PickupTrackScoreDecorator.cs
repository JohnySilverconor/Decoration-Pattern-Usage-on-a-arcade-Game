using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    class PickupTrackScoreDecorator : PickupDecorator<PictureBox>, IScoreCallbackable
    {
        public PickupTrackScoreDecorator(AbstractPickup<PictureBox> pickupToDecorate)
            : base(pickupToDecorate)
        {
        }

        public override bool IsEaten
        {
            get
            {
                return _pickupToDecorate.IsEaten;
            }
            set
            {
                if (value)
                {
                    if (_pickupToDecorate.IsFruit)
                    {
                        OnPlayerScored(200);
                    }
                    else
                    {
                        OnPlayerScored(100);
                    }
                }

                _pickupToDecorate.IsEaten = value;
            }
        }

        public event EventHandler<int> PlayerScored;

        protected virtual void OnPlayerScored(int value)
        {
            if (PlayerScored != null)
            {
                PlayerScored(this, value);
            }
        }
    }
}
