using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace drone_simple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(150, 50);
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Drone[] drones =
            {
                new Drone(50, 10, 5, 2),
                new Drone(60, 0, 10, 2),
                new Drone(30, 0, 15, 3),
                new Drone(80, 30, 20, 1)
            };

            int batteryMax = drones.Max(d => d._battery);

            int batteryMax2 = 0;

            foreach (Drone drone in drones)
            {
                if (drone._battery > batteryMax)
                {
                    batteryMax = drone._battery;
                }

                batteryMax2 = drone._battery > batteryMax ? drone._battery : batteryMax2;
            }

            while (batteryMax > 0)
            {
                Console.Clear();

                batteryMax = drones.Max(d => d._battery);

                foreach (Drone drone in drones)
                {
                    if (drone._battery > 0)
                    {
                        drone.Move();
                    }
                    drone.Draw();
                }
                Thread.Sleep(100);
            }

            Console.Read();
        }
    }
}
