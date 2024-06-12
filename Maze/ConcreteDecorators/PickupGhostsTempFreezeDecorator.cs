using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public class PickupGhostsTempFreezeDecorator : PickupDecorator<PictureBox>
    {
        private readonly IEnumerable<AbstractGhost<PictureBox>> _ghostsAffected;
        private static Timer _freezeTimer;

        public PickupGhostsTempFreezeDecorator(AbstractPickup<PictureBox> pickupToDecorate, IEnumerable<AbstractGhost<PictureBox>> ghostsAffected)
            : base(pickupToDecorate)
        {
            if (ghostsAffected == null)
            {
                throw new ArgumentNullException("ghostsAffected");
            }

            _ghostsAffected = ghostsAffected;
        }

        public Timer FreezeTimer
        {
            get
            {
                if (_freezeTimer == null)
                {
                    _freezeTimer = new Timer();
                    _freezeTimer.Interval = 3000;
                }

                return _freezeTimer;
            }
            set
            {
                _freezeTimer = value;
            }
        }

        public override bool IsEaten
        {
            get
            {
                return _pickupToDecorate.IsEaten;
            }
            set
            {
                if (IsFruit && value)
                {
                    if (FreezeTimer != null)
                    {
                        FreezeTimer.Dispose();
                        FreezeTimer = null;
                    }

                    FreezeTimer.Tick += _freezeTimer_Tick;

                    FreezeTimer.Stop();
                    FreezeTimer.Start();
                    FreezeTimer.Enabled = true;

                    for (int i = 0; i < _ghostsAffected.Count(); i++)
                    {
                        _ghostsAffected.ElementAt(i).PauseMoving();
                    }
                }

                _pickupToDecorate.IsEaten = value;
            }
        }

        void _freezeTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _ghostsAffected.Count(); i++)
            {
                _ghostsAffected.ElementAt(i).ContinueMoving();
            }

            if (FreezeTimer != null)
            {
                FreezeTimer.Dispose();
                FreezeTimer = null;
            }
        }
    }
}
