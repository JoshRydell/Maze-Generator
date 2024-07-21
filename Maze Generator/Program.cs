using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Maze_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int width;
            int height;
            int pathWidth;
            string path;
            string name;
            string perfectMaze;

            Console.WriteLine("Enter width:");
            width = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter height:");
            height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Perfect Maze y/n ? ");
            perfectMaze = Console.ReadLine();

            Console.WriteLine("Enter path size: ");
            pathWidth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            path = Directory.GetCurrentDirectory() + "\\" + name + ".bmp";
 
            GenerateMaze gm = new GenerateMaze(width,height,pathWidth,path, perfectMaze.ToLower() == "n" ? false : true);
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
