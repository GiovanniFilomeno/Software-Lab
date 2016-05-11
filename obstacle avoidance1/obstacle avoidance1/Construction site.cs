using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//create normaized coordinates for elements and obstacles when the construction site is created
namespace obstacle_avoidance1
{
    class Construction_site
    {
        private double Width;
        private double Height;
        private double Depth;
        public Pedestrian[] Ps;//to compile in c++ use * instead of []
        public Element[] Obs;
        private int GridSize;
        public Position[,] Grid;
        public Construction_site(Pedestrian[] ps, Element[] el, double W, double H, double D, int grid)
        {
            Ps = ps;
            Obs = el;
            Width = W;
            Height = H;
            Depth = D;
            GridSize = grid;
            CreateGrid();
        }
        public string Draw()
        {
            string output;
            output = Width.ToString()+"X"+ Height.ToString() + "X"+ Depth.ToString()+ "\r\n";
            for (int i = 0; i < Ps.Length; i++)
            {
                output += "Element[" + i.ToString() + "]=" + Ps[i].Draw() + " \r\n";
            }
            for (int i = 0; i < Obs.Length; i++)
            {
                output += "Obs[" + i.ToString() + "]=" + Obs[i].Draw() + "\r\n ";
            }
            return output;
        }
        //creates the normalized grid, array of points from 0-1
        private void CreateGrid()
        {
            double delta = 1.0 / GridSize;
            Grid=new Position[GridSize+1,GridSize+1];
            for (int i = 0; i <= GridSize; i++)
            {
                for (int j = 0; j < GridSize+1; j++)
                {
                    Grid[i, j] = new Position(delta * i, delta * j,0);                 //2D   
                }
            }
            
        }
        public double GetWidth() { return Width; }
        public double GetHeight() { return Height; }
        public double GetGridSize() { return GridSize; }
    }

    class Position
    {
        private double X,Y,Z;
        private double Speed, Field;
        public Position() { X = Y = Z = Speed = Field = 0; }
        public Position(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Speed = 0;
            Field = 0;
        }
        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetZ() { return Z; }
        public void AddField() { }
        //gets the distance to an specific position P
        public double DistanceTo(Position P)
        {
            double distance;            
            distance = Math.Sqrt(Math.Pow(X - P.GetX(), 2) + Math.Pow(Y - P.GetY(), 2));
            return distance;
        }
        public string Draw()
        {
            string output;
            output = "(" + X.ToString() + "," + Y.ToString() + "," + Z.ToString()+")";
            return output;
        }
        public void Move(double deltaX,double deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

    }
    class Path
    {
        private
        Position[] Route;
        
        public void Draw() { }
    }
}
