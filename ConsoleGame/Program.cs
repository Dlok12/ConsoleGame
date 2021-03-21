using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Threading;

namespace LessonForVlad4
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Start();
            for (int i = 0; i <= 183; i++)
            {
                //Console.WriteLine();
                Console.WriteLine(i + ": " + (char)i);
                
                Thread.Sleep(20);
                //Console.Clear();
            }
            Console.ReadKey();
        }        
    }
}
