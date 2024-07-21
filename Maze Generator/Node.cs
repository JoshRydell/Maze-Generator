using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    class Node
    {
        public int direction { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Node(int X, int Y, int direction)
        {
            this.X = X;
            this.Y = Y;
            this.direction = direction;

        }
        public Node(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }


    }
}
