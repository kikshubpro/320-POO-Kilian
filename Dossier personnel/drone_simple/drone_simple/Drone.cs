using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace drone_simple
{
    internal class Drone
    {
        public int _battery;
        private int _posX;
        private int _posY;
        private int _speed;
        private string _drone;

        public Drone(int battery, int posX, int posY, int speed)
        {
            _battery = battery;
            _posX = posX;
            _posY = posY;
            _speed = speed;
            _drone = "x-O-x";
        }

        public void Move()
        {
            _posX += _speed;
            _battery--;
        }

        public void Draw()
        {
            if (_battery <= 0)
            {
                _drone = "____";
                _battery = 0;
            }

            Console.SetCursorPosition(_posX, _posY);
            Console.Write(_drone);
            Console.SetCursorPosition(_posX + 1, _posY - 1);
            Console.Write(_battery + "%");
        }
    }
}