using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maze_Generator
{
    class GenerateMaze
    {

        bool[,] nodes;

        public GenerateMaze(int width, int height, int pathWidth, string path, bool perfectMaze)
        {

            nodes = new bool[width, height];
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Stack stack = new Stack();

            nodes[0, 0] = true;
            stack.Push( (rand.NextDouble() - 0.5) > 0 ?  new Node(0, 0, 1) : new Node(0, 0, 2));
            while (!stack.IsEmpty())
            {
                Node parentNode = stack.Pop();
                Node currentNode = null;
                if (parentNode.direction == 0 && parentNode.Y - 2 >= 0 && !nodes[parentNode.X, parentNode.Y - 2])
                {
                    currentNode = new Node(parentNode.X, parentNode.Y - 2);
                    nodes[currentNode.X, currentNode.Y] = true;
                    nodes[currentNode.X, currentNode.Y + 1] = true;
                }
                else if (parentNode.direction == 1 && parentNode.X + 2 < width && !nodes[parentNode.X + 2, parentNode.Y])
                {
                    currentNode = new Node(parentNode.X + 2, parentNode.Y);
                    nodes[currentNode.X, currentNode.Y] = true;
                    nodes[currentNode.X - 1, currentNode.Y] = true;
                }
                else if (parentNode.direction == 2 && parentNode.Y + 2 < height && !nodes[parentNode.X, parentNode.Y + 2])
                {
                    currentNode = new Node(parentNode.X, parentNode.Y + 2);
                    nodes[currentNode.X, currentNode.Y] = true;
                    nodes[currentNode.X, currentNode.Y - 1] = true;
                    
                    
                }
                else if (parentNode.direction == 3 && parentNode.X - 2 >= 0 && !nodes[parentNode.X - 2, parentNode.Y])
                {
                    currentNode = new Node(parentNode.X - 2, parentNode.Y);
                    nodes[currentNode.X, currentNode.Y] = true;
                    nodes[currentNode.X + 1, currentNode.Y] = true;
                }
                if(currentNode != null)
                {
                    int[] directions = new int[4];
                    for (int i = 0; i < directions.Length; i++)
                    {
                        directions[i] = i;
                    }


                    for (int i = 0; i < directions.Length - 1; i++)
                    {
                        int j = rand.Next(i, directions.Length);
                        int temp = directions[j];
                        directions[j] = directions[i];
                        directions[i] = temp;
                    }
                    for (int i = 0; i < directions.Length; i++)
                    {
                        stack.Push(new Node(currentNode.X, currentNode.Y, directions[i]));
                    }
                }
                
            }



            if (!perfectMaze)
            {
                int numWallsToRemove = (int)(height * width * (Math.Pow(height * width, 0.005) - 1));
                for (int i = 0; i < numWallsToRemove; i++)
                {
                    int x;
                    int y;
                    do
                    {
                        x = rand.Next(width - 1);
                        y = rand.Next(height - 1);

                    } while (nodes[x, y]);
                    nodes[x, y] = true;
                }
            }


            Console.WriteLine("Maze generated");

            Bitmap maze;
            if (height % 2 == 1 && width % 2 == 0)
            {
                maze = new Bitmap((width + 1) * pathWidth, (height + 2) * pathWidth);
            }
            else if (height % 2 == 0 && width % 2 == 1)
            {
                maze = new Bitmap((width + 2) * pathWidth, (height + 1) * pathWidth);
            }
            else if (height % 2 == 1 && width % 2 == 1)
            {
                maze = new Bitmap((width + 2) * pathWidth, (height + 2) * pathWidth);
            }
            else
            {
                maze = new Bitmap((width + 1) * pathWidth, (height + 1) * pathWidth);
            }
            Graphics g = Graphics.FromImage(maze);
            g.Clear(Color.Black);

            Brush white = Brushes.White;



            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (nodes[x, y])
                    {
                        g.FillRectangle(white, (x + 1) * pathWidth, (y + 1) * pathWidth, pathWidth, pathWidth);
                    }
                }
            }

            g.FillRectangle(white, pathWidth, 0, pathWidth, pathWidth);
            g.FillRectangle(white, maze.Width - 2 * pathWidth, maze.Height - pathWidth, pathWidth, pathWidth);

            maze.Save(path);
            Console.WriteLine("Maze saved");
        }




    }
}


