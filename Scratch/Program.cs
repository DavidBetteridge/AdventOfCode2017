using Solutions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var day22 = new Day22_Part2();
            var map = day22.LoadMap(@"..#
#..
...");
            var actual = day22.Part2(map, 10000000);
            sw.Stop();
            Console.WriteLine("Time: " + Math.Round(sw.Elapsed.TotalSeconds, 2));
            Console.ReadKey();
        }


    }
}
