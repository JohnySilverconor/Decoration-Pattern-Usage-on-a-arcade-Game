using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public class PlayerPictureBoxFacesDecorator : PlayerDecorator<PictureBox>
    {
        public PlayerPictureBoxFacesDecorator(AbstractPlayer<PictureBox> playerToDecorate)
            : base(playerToDecorate)
        {
        }

        public override bool TryMoveLeft(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveLeft(AvailableDirections);

            if (result)
            {
                Display.Image = Properties.Resources.IMG_PLAYER_LEFT;
                OnGhostMoved();
            }

            return result;
        }

        public override bool TryMoveUp(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveUp(AvailableDirections);

            if (result)
            {
                Display.Image = Properties.Resources.IMG_PLAYER_UP;
                OnGhostMoved();
            }

            return result;
        }

        public override bool TryMoveRight(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveRight(AvailableDirections);

            if (result)
            {
                Display.Image = Properties.Resources.IMG_PLAYER_RIGHT;
                OnGhostMoved();
            }

            return result;
        }

        public override bool TryMoveDown(IEnumerable<DIRECTION> AvailableDirections)
        {
            bool result = _playerToDecorate.TryMoveDown(AvailableDirections);

            if (result)
            {
                Display.Image = Properties.Resources.IMG_PLAYER_DOWN;
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
        }
    }
}