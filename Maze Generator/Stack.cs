using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    class Stack
    {
        private List<Node> stack;
        public Stack()
        {
            stack = new List<Node>();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
        public void Push(Node node)
        {
            stack.Insert(0,node);
        }

        public Node Pop()
        {
            Node node = stack[0];
            stack.RemoveAt(0);
            return node;
        }
    }
}
