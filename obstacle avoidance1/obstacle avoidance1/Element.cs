using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obstacle_avoidance1
{
    class Element
    {
        private 
        Position Pos;
        Path Route;
        double Width;
        double Length;
        double Height;
        double Speed;
        double Effect_Area;

        public Element(Position pos,Path route, double W=0.0, double L=0.0,double H=0, double S=0.0,double area=0)
        {
            Pos = pos;
            Route = route;
            Width = W;
            Height = H;
            Length = L;
            Speed = S;
            Effect_Area = area;
        }
        public Element(Position pos, double W = 0.0, double L = 0.0, double H = 0, double S = 0.0, double area = 0)
        {
            Pos = pos;            
            Width = W;
            Height = H;
            Length = L;
            Speed = S;
            Effect_Area = area;
        }
       
        ~Element() { }
        public double GetX() { return Pos.GetX(); }
        public double GetY() { return Pos.GetY(); }
        public double GetZ() { return Pos.GetZ(); }
        public Position GetPos() { return Pos; }
        void Move() { }
        public string Draw()
        {
            string output;
            output = "Pos=" + Pos.Draw() + " " + Width.ToString() + "X" + Height.ToString() + "X" + Length.ToString();
            return output;

            //cout only works for console applications!
            //cout << "Data of the Element" << endl << "Width\tLenght\tSpeed\tEffect Area"<< endl;
            //cout << Width << "\t" << Lenght << "\t" << Speed << "\t" << Effect_Area<< endl:
            //to implement
        }
        void Create_Field()
        {
            //to implement;
        }

    }

}
