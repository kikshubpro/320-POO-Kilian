using Drones.Helpers;
using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private int _targetX;
        private int _targetY;
        private State _state;

        public int Charge { get => _charge; private set => _charge = value; }
        public string Name { get => _name; private set => _name = value; }
        public int X { get => _x; private set => _x = value; }
        public int Y { get => _y; private set => _y = value; }
        public State CurrentState { get => _state; private set => _state = value; }

        public enum State { CRASH, LOW_BATTERY, LOADING, ROAMING };

        // Constructeur
        public Drone(int x, int y, string name)
        {
            Charge = RandomHelper.Next(0, ConfigY.MAX_LOAD); // La charge initiale de la batterie est choisie aléatoirement
            Name = name;
            X = x;
            Y = y;
            _targetX = RandomHelper.Next(0, ConfigY.AIRSPACE_WIDTH);
            _targetY = RandomHelper.Next(0, ConfigY.AIRSPACE_HEIGHT);
            _state = State.ROAMING;
        }
    
        #region ================ Modelisation du drone et de son comportement ================

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (Charge <= 0 || (_targetX == X && _targetY == Y)) return;                                        // S'il n'a plus de charge, il ne peut plus bouger
            double deltaX = _targetX - X;
            double deltaY = _targetY - Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            double step = (double)ConfigY.SPEED * 10 * interval / 1000;          // Distance parcourue pendant l'intervalle,vitesse constante
            X += (int)Math.Ceiling(deltaX / distance * step);
            Y += (int)Math.Ceiling(deltaY / distance * step);                           // Il s'est déplacé en direction de son objectif
            Charge--;                                                       // Il a dépensé de l'énergie
        }

        #endregion

        #region  ================ Rendu graphique  ================

        private const int SIZE = 50;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Charge > 0 ? Resources.drone : Resources.boom, X-Drone.SIZE/2, Y - Drone.SIZE / 2, Drone.SIZE, Drone.SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X + 5, Y - 25);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} ({((int)((double)Charge / 1000 * 100)).ToString()}%)";
        }
        #endregion

    }
}
