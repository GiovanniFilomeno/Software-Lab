using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add get initia and final position
namespace obstacle_avoidance1
{
    class Pedestrian
    {
        private Position Initial;
        Position Final;
        Position Current;
        Path Route;
        double Speed;
        public double DeltaX, DeltaY;
        public double AtractiveX, AtractiveY, RepulsiveX, RepulsiveY;
        //Constructor of Pedestrian
        public Pedestrian()
        {
            Initial = new Position();
            Final = new Position();
            Current = new Position();
            Speed = 0;
        }
        public Pedestrian(Position Ini, Position Fin)
        {
            Initial = Ini;
            Final = Fin;
            Current = Ini;
            Speed = 0;

        }
        public Pedestrian(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
        {
            Initial = new Position(X1, Y1, Z1);
            Final = new Position(X2, Y2, Z2);
            Current = Initial;
            Speed = 0;

        }
        public Pedestrian(double X1, double Y1, double X2, double Y2)
        {
            Initial = new Position(X1, Y1, 0);
            Final = new Position(X2, Y2, 0);
            Current = Initial;
            Speed = 0;

        }

        public double GetX() { return Current.GetX(); }
        public double GetY() { return Current.GetY(); }
        public double GetXFinal() { return Final.GetX(); }
        public double GetYFinal() { return Final.GetY(); }
        public double GetZ() { return Current.GetZ(); }
        public Position GetPos() { return Current; }
        public void Get_Direction()
        { }
        void Check_Obstacle()
        { }
        public string Draw()
        {
            string output;
            output = "Initial=" + Initial.Draw() + "\n Final=" + Final.Draw();
            return output;
        }
        void Move()
        {
            DeltaX = RepulsiveX + AtractiveX;
            DeltaY = RepulsiveY + AtractiveY;
            Current.Move(DeltaX, DeltaY);
        }
        public void GetForce(Element[] Obstacles)
        {
            DeltaX = 0;
            DeltaY = 0;
            RepulsiveX = 0;
            RepulsiveY = 0;
            AtractiveX = 0;
            AtractiveY = 0;
            GetAttractionForce();
            GetRepulsiveForce(Obstacles);

            Move();
        }
        Boolean GetAttractionForce()// returns true if the objective is reached
        {
            double distance=Current.DistanceTo(Final);
            double radius = 0.01;
            double radius2 = 0.02;
            double alpha = .01;//constant used in the braking area
            double beta = .01;//constant used in the long distances
            double norm;
            if (distance<=radius)
            {
                return true;

            }
            else if (distance<radius2)
            {
                AtractiveX = -Current.GetX() + Final.GetX();
                AtractiveY = -Current.GetY() + Final.GetY();
                norm = Math.Sqrt(AtractiveX * AtractiveX + AtractiveY * AtractiveY);
                AtractiveX = alpha*(distance - radius2) * AtractiveX / norm;
                AtractiveY = alpha*(distance - radius2) * AtractiveY / norm;
            }
            else
            {
                AtractiveX = -Current.GetX() + Final.GetX();
                AtractiveY = -Current.GetY() + Final.GetY();
                norm = Math.Sqrt(AtractiveX * AtractiveX + AtractiveY * AtractiveY);
                AtractiveX = beta * AtractiveX / norm;
                AtractiveY = beta * AtractiveY / norm;
                
            }
            
            return false;

        }

        void GetRepulsiveForce(Element[] Obstacles)// returns true if the objective is reached
        {
            double distance ;
            double radius = 0.02;
            double radius2 = 0.15;
            double alpha = .2;//constant used in the braking area
            double beta = .1;//constant used in the long distances
            double norm;
            double Fx, Fy;
            foreach (Element Obs in Obstacles)
            {
                distance = Current.DistanceTo(Obs.GetPos());
                if (distance<radius2)
                {
                    Fx = Current.GetX() - Obs.GetX();
                    Fy = Current.GetY() - Obs.GetY();
                    norm = Math.Sqrt(Fx * Fx + Fy * Fy);
                    Fx = Fx / norm;
                    Fy = Fy / norm;
                    RepulsiveX += alpha * (radius2 - distance)*Fx;
                    RepulsiveY += alpha * (radius2 - distance)*Fy;
                }
                else
                {
                    RepulsiveX += 0;
                    RepulsiveY += 0;
                }
            }
            
           

        }



    }
    
}
