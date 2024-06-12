using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    internal partial class FormOptions : Form
    {
        private readonly ConfigurationOptions _configurationOptions;

        internal FormOptions(ConfigurationOptions configurationOptions)
        {
            if (configurationOptions == null)
            {
                throw new ArgumentNullException("configurationOptions");
            }

            InitializeComponent();

            _configurationOptions = configurationOptions;
            
            chbGhostFaces.Checked = _configurationOptions.GhostFaces;
            chbGhostTrackScore.Checked = _configurationOptions.GhostTrackScore;
            chbPickupGhostTempFreeze.Checked = _configurationOptions.PickupGhostTempFreeze;
            chbPickupGhostVurneability.Checked = _configurationOptions.PickupGhostVurneability;
            chbPickupTrackScore.Checked = _configurationOptions.PickupTrackScore;
            chbPlayerFaces.Checked = _configurationOptions.PlayerFaces;
        }

        public ConfigurationOptions ConfigurationOptions
        {
            get
            {
                return _configurationOptions;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _configurationOptions.GhostFaces = chbGhostFaces.Checked;
            _configurationOptions.GhostTrackScore = chbGhostTrackScore.Checked;
            _configurationOptions.PickupGhostTempFreeze = chbPickupGhostTempFreeze.Checked;
            _configurationOptions.PickupGhostVurneability = chbPickupGhostVurneability.Checked;
            _configurationOptions.PickupTrackScore = chbPickupTrackScore.Checked;
            _configurationOptions.PlayerFaces = chbPlayerFaces.Checked;
        }
    }
}