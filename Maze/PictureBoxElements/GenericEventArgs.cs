using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class GenericEventArgs<T> : EventArgs
    {
        private readonly T _value;

        public GenericEventArgs(T value)
        {
            _value = value;
        }

        public T Value
        {
            get
            {
                return _value;
            }
        }
    }
}