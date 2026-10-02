using Drones.Helpers;
using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    internal class Charger
    {
        private int _x;
        private int _y;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        public Charger(int x, int y)
        {
            _x = x;
            _y = y;
        }

        private const int SIZE = 20;

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.circle, X - Charger.SIZE / 2, Y - Charger.SIZE / 2, Charger.SIZE, Charger.SIZE);
        }
    }
}
