using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class ConfigurationOptions
    {
        public bool GhostFaces
        {
            get;
            set;
        }

        public bool GhostTrackScore
        {
            get;
            set;
        }

        public bool PickupGhostTempFreeze
        {
            get;
            set;
        }

        public bool PickupGhostVurneability
        {
            get;
            set;
        }

        public bool PickupTrackScore
        {
            get;
            set;
        }

        public bool PlayerFaces
        {
            get;
            set;
        }
    }
}