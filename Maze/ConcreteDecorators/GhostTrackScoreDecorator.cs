using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public class GhostTrackScoreDecorator : GhostDecorator<PictureBox>, IScoreCallbackable
    {
        public GhostTrackScoreDecorator(AbstractGhost<PictureBox> ghostToDecorate)
            : base(ghostToDecorate)
        {
        }

        public event EventHandler<int> PlayerScored;

        public override void Die()
        {
            _ghostToDecorate.Die();
            OnPlayerScore(500);
        }

        protected virtual void OnPlayerScore(int value)
        {
            if (PlayerScored != null)
            {
                PlayerScored(this, value);
            }
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
