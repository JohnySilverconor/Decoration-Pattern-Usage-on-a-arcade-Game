using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    static class Program
    {
        private readonly static int _stepSize = 20;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var level = ComposeLevel();

            FormMain mainForm = new FormMain(level);
            mainForm.GameRestarted += (sender, e) =>
            {
                level = ComposeLevel(e.Value);
                mainForm.Level = level;
            };

            Application.Run(mainForm);
        }

        public static AbstractLevel<PictureBox> ComposeLevel(ConfigurationOptions configurationOptions = null)
        {
            AbstractPlayer<PictureBox> player = null;
            List<AbstractBorder<PictureBox>> borders = null;
            List<AbstractPickup<PictureBox>> pickups = null;
            List<AbstractGhost<PictureBox>> ghosts = null;

            var levelDataCreator = new LevelDataCreator<PictureBox>(_stepSize);
            levelDataCreator.LevelOneData(out player, out borders, out pickups, out ghosts);

            player = new PlayerPictureBoxDecorator(player);

            if (configurationOptions == null || (configurationOptions != null && configurationOptions.PlayerFaces))
            {
                player = new PlayerPictureBoxFacesDecorator(player);
            }

            for (int i = 0; i < borders.Count; i++)
            {
                borders[i] = new BorderPictureBoxDecorator(borders[i]);
            }

            for (int i = 0; i < ghosts.Count; i++)
            {
                AbstractGhost<PictureBox> ghost = new GhostPictureBoxDecorator(ghosts[i]);
                if (configurationOptions == null || (configurationOptions != null && configurationOptions.GhostFaces))
                {
                    ghost = new GhostPictureBoxFacesDecorator(ghost);
                }
                if (configurationOptions == null || (configurationOptions != null && configurationOptions.GhostTrackScore))
                {
                    ghost = new GhostTrackScoreDecorator(ghost);
                }

                ghosts[i] = ghost;
            }

            for (int i = 0; i < pickups.Count; i++)
            {
                AbstractPickup<PictureBox> pickup = new PickupPictureBoxDecorator(pickups[i]);
                if (configurationOptions == null || (configurationOptions != null && configurationOptions.PickupGhostVurneability))
                {
                    pickup = new PickupGhostVulnerabilityDecorator(pickup, ghosts);
                }
                if (configurationOptions == null || (configurationOptions != null && configurationOptions.PickupGhostTempFreeze))
                {
                    pickup = new PickupGhostsTempFreezeDecorator(pickup, ghosts);
                }
                if (configurationOptions == null || (configurationOptions != null && configurationOptions.PickupTrackScore))
                {
                    pickup = new PickupTrackScoreDecorator(pickup);
                }

                pickups[i] = pickup;
            }

            return new LevelPictureBox(_stepSize, player, borders, pickups, ghosts);
        }
    }
}