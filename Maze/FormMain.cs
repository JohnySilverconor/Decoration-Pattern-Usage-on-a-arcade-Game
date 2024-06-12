using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class FormMain : Form
    {
        private bool _keyLeftPressed;
        private bool _keyUpPressed;
        private bool _keyRightPressed;
        private bool _keyDownPressed;
        private AbstractLevel<PictureBox> _level;

        private ConfigurationOptions _configurationOptions;

        private Timer _gameLoop;
        private int _score;

        public event EventHandler<GenericEventArgs<ConfigurationOptions>> GameRestarted;

        public FormMain(AbstractLevel<PictureBox> level)
        {
            InitializeComponent();
            _level = level;
            _score = 0;
            _configurationOptions = new ConfigurationOptions()
            {
                GhostFaces = true,
                GhostTrackScore = true,
                PickupGhostTempFreeze = true,
                PickupGhostVurneability = true,
                PickupTrackScore = true,
                PlayerFaces = true
            };
            ResetPressedKeys();
        }

        public AbstractLevel<PictureBox> Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value != null)
                {
                    _level = value;
                }
            }
        }

        protected virtual void OnGameRestarted(ConfigurationOptions configurationOptions)
        {
            if (GameRestarted != null)
            {
                GameRestarted(this, new GenericEventArgs<ConfigurationOptions>(configurationOptions));
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _keyLeftPressed = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _keyUpPressed = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _keyRightPressed = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _keyDownPressed = true;
            }
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _keyLeftPressed = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _keyUpPressed = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _keyRightPressed = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _keyDownPressed = false;
            }
        }

        private void toolStripButtonOptions_Click(object sender, EventArgs e)
        {
            FormOptions frmOptions = new FormOptions(_configurationOptions);

            if (frmOptions.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _configurationOptions = frmOptions.ConfigurationOptions;
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            foreach (var ghost in _level.Ghosts)
            {
                ghost.MoveAutomatically(_level.AvailableDirections(ghost.Location));
            }

            bool hasPlayerMoved = false;

            if (_keyLeftPressed)
            {
                hasPlayerMoved = _level.Player.TryMoveLeft(_level.AvailableDirections(_level.Player.Location));
            }
            else if (_keyUpPressed)
            {
                hasPlayerMoved = _level.Player.TryMoveUp(_level.AvailableDirections(_level.Player.Location));
            }
            else if (_keyRightPressed)
            {
                hasPlayerMoved = _level.Player.TryMoveRight(_level.AvailableDirections(_level.Player.Location));
            }
            else if (_keyDownPressed)
            {
                hasPlayerMoved = _level.Player.TryMoveDown(_level.AvailableDirections(_level.Player.Location));
            }

            if (!hasPlayerMoved)
            {
                _level.Player.MoveAutomatically(_level.AvailableDirections(_level.Player.Location));
            }
        }

        private void toolStripNewGame_Click(object sender, EventArgs e)
        {
            if (_gameLoop != null && _gameLoop.Enabled)
            {
                _gameLoop.Enabled = false;
                if (MessageBox.Show("Do you want to start new game?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    _gameLoop.Enabled = true;
                    StartGame();
                }
            }
            else
            {
                StartGame();
            }
        }

        private void ResetGame()
        {
            panelMain.Controls.OfType<PictureBox>().ToList().ForEach(t =>
                    panelMain.Controls.Remove(t)
                );

            DisplayBorders();
            DisplayGhosts();
            DisplayPlayer();
            DisplayPickups();

            lblScore.Text = string.Empty;
        }

        private void ResetPressedKeys()
        {
            _keyLeftPressed = false;
            _keyUpPressed = false;
            _keyRightPressed = false;
            _keyDownPressed = false;
        }

        private void DisplayBorders()
        {
            if (_level != null && _level.Borders != null)
            {
                for (int i = 0; i < _level.Borders.Count; i++)
                {
                    panelMain.Controls.Add(_level.Borders[i].Display);
                }
            }
        }

        private void DisplayGhosts()
        {
            for (int i = 0; i < _level.Ghosts.Count; i++)
            {
                panelMain.Controls.Add(_level.Ghosts[i].Display);

                IScoreCallbackable scoreGhost = _level.Ghosts[i] as IScoreCallbackable;
                if (scoreGhost != null)
                {
                    scoreGhost.PlayerScored += (sender, e) =>
                        {
                            _score += e;
                            lblScore.Text = _score.ToString();
                        };
                }
            }
        }

        private void DisplayPlayer()
        {
            panelMain.Controls.Add(_level.Player.Display);
        }

        private void DisplayPickups()
        {
            if (_level.Pickups != null)
            {
                for (int u = 0; u < _level.Pickups.Count; u++)
                {
                    panelMain.Controls.Add(_level.Pickups[u].Display);

                    IScoreCallbackable scorePickup = _level.Pickups[u] as IScoreCallbackable;
                    if (scorePickup != null)
                    {
                        scorePickup.PlayerScored += (sender, e) =>
                            {
                                _score += e;
                                lblScore.Text = _score.ToString();
                            };
                    }
                }
            }
        }

        private void SetUpGameLoop()
        {
            if (_gameLoop == null)
            {
                _gameLoop = new Timer();
                _gameLoop.Interval = 2;
                _gameLoop.Enabled = true;
                _gameLoop.Tick += _timer_Tick;
            }

            _gameLoop.Enabled = true;
        }

        private void StartGame()
        {
            OnGameRestarted(_configurationOptions);
            ResetGame();
            SetUpGameLoop();

            _level.LevelCompleted += (sender, e) =>
                {
                    if (_gameLoop != null)
                    {
                        _gameLoop.Enabled = false;
                        _gameLoop.Dispose();
                        _gameLoop = null;
                        _level.Player.Display.Image = Properties.Resources.IMG_PLAYER_WIN;
                    }
                };
        }
    }
}