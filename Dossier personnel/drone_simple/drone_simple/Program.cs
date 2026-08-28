using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace drone_simple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char drone = '█';
            int battery = 50;
            int posX = 0;
            const int Pos_Y = 10;

            while (battery >= 0) {
                Console.Clear();

                Console.SetCursorPosition(posX, Pos_Y);
                Console.Write(drone);
                Console.SetCursorPosition(posX, Pos_Y - 1);
                Console.Write(battery + "%");

                posX++;
                battery -= 2;

                Thread.Sleep(100);
            }

            Console.Read();
        }
    }
}
