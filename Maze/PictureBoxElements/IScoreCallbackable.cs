using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public interface IScoreCallbackable
    {
        event EventHandler<int> PlayerScored;
    }
}