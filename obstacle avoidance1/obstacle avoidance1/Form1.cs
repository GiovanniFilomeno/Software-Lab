using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obstacle_avoidance1
{
    public partial class Form1 : Form
    {
        static Image CsImage;//creates an image, to be asociated with the picture box
        static Graphics GpContructionSite;//creates a canvas to draw

        SolidBrush BsAqua = new SolidBrush(Color.Aqua);
        SolidBrush BsGreen = new SolidBrush(Color.Green);
        SolidBrush BsBlue = new SolidBrush(Color.Blue);
        SolidBrush BsRed = new SolidBrush(Color.Red);
        Pen PnAqua = new Pen(Color.Aqua);
        Pen PnGreen = new Pen(Color.DarkGreen);
        Pen PnGreen2 = new Pen(Color.Green);
        Pen PnRed = new Pen(Color.Red);
        Pen PnBlue = new Pen(Color.Blue);

        //elements, pedestrian and construction site

        static Position A = new Position(0.11, 0.1, 0.1);
        static Position B = new Position(0.5, 0.2, 0.5);
        static Position C = new Position(0.8, 0.6, 0.1);
        static Position D = new Position(0.5, 0.5, 0.5);
        //creates a vector of pedestrians
        static Pedestrian[] Pedestrians = new Pedestrian[3];
        
        //cretes a vector of elements
        Element[] Els = new Element[2];

        Construction_site Site;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CsImage = new Bitmap(PbGrid.Width, PbGrid.Height);//sets the size of the image
            GpContructionSite = Graphics.FromImage(CsImage);//start the canvas with a given image
            PbGrid.Image = CsImage; 

        }

        private void btnPed_Click(object sender, EventArgs e)
        {            
            Position In, Fi;
            In = new Position(0, 0, 0);
            Fi = new Position(2, 4, 8);
            Pedestrian Person = new Pedestrian(In, Fi);
            TBTest.Text = Person.Draw();            
        }

        private void btnElement_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnCons_Click(object sender, EventArgs e)
        {

            Position E = new Position(.8, .8,0);
            Pedestrians[0] = new Pedestrian(A, E);
            Pedestrians[1] = new Pedestrian(B, E);
            Pedestrians[2] = new Pedestrian(0,0.0,.8,.8);
            Els[0] = new Element(C);
            Els[1] = new Element(D);
            timer1.Start();
            //creates a contruction site
            Site = new Construction_site(Pedestrians, Els, 60, 40, 30, 30);
            TBTest.Text = Site.Draw();
            DrawGrid(Site);
            DrawPedestrian(Pedestrians);
            DrawElement(Els);
            DrawRepulsiveField(Site);
            DrawGoalField(Site);
            PbGrid.Refresh();
            
        }

        //function to draw the field
        private void DrawRepulsiveField(Construction_site site)
        {
            double Dist,size=.2;
            float X1,Y1,X2,Y2, radius = 3;
            foreach (Position Pos in site.Grid)
	        {
                foreach (Element El in site.Obs)
                {
                    Dist=Pos.DistanceTo(El.GetPos());
                    if (Dist < 0.15)
                    { 
                        X1=(float)Pos.GetX()*PbGrid.Width;
                        Y1=(float)Pos.GetY()*PbGrid.Height;
                        X2 = (float)(( El.GetX() - Pos.GetX()) * size) ;
                        X2 = X2 * PbGrid.Width;
                        X2 = X1 + X2 ;
                        Y2= (float)((El.GetY() - Pos.GetY()) * size) ;
                        Y2 = Y2 * PbGrid.Height;
                        Y2 = Y1 + Y2;
                        GpContructionSite.DrawLine(PnRed, X1, Y1, X2, Y2);
                        
                        GpContructionSite.FillEllipse(BsRed, X1 - radius / 2, Y1 - radius / 2, radius, radius);

                    }
                }
		 
    	    }
            
        }

        //function to draw the field
        private void DrawGoalField(Construction_site site)
        {
            double Dist, size = .5;
            Position goal = new Position(0.8, 0.8, 0);
            float X1, Y1, X2, Y2,radius=3;
            foreach (Position Pos in site.Grid)
            {
                   Dist = Pos.DistanceTo(goal);
                    if (Dist < 0.1)
                    {
                        X1 = (float)Pos.GetX() * PbGrid.Width;
                        Y1 = (float)Pos.GetY() * PbGrid.Height;
                        X2 = (float)((goal.GetX() - Pos.GetX()) * size);
                        X2 = X2 * PbGrid.Width;
                        X2 = X1 + X2;
                        Y2 = (float)((goal.GetY() - Pos.GetY()) * size);
                        Y2 = Y2 * PbGrid.Height;
                        Y2 = Y1 + Y2;
                        GpContructionSite.DrawLine(PnBlue, X1, Y1, X2, Y2);
                        GpContructionSite.FillEllipse(BsBlue, X2 - radius/2, Y2 - radius/2, radius, radius);


                    }
                

            }

        }
        //function to draw the elements
        private void DrawElement(Element[] Els)
        {
            double X, Y;
            int size = 20;
            double size2 = 0.3*PbGrid.Width;
            double size3 = 0.3 * PbGrid.Height;
            foreach (Element E in Els)
            {
                X = E.GetX() * PbGrid.Width;
                Y = E.GetY() * PbGrid.Height;
                //GpContructionSite.DrawRectangle(PnRed, (float)X - size / 2, (float)Y - size / 2, size, size);
                GpContructionSite.FillEllipse(BsRed, (float)X - size / 2, (float)Y - size / 2, size, size);
                GpContructionSite.DrawEllipse(PnRed, (float)(X - size2 / 2), (float)(Y - size3 / 2), (float)size2, (float)size3);
            }

        }

        private void DrawGoal(Pedestrian[] Ps)
        {
            double X, Y;
            int size = 3;
            double size2 = 0.04 * PbGrid.Width;
            double size3 = 0.04 * PbGrid.Height;
            foreach (Pedestrian P in Ps)
            {
                X = P.GetXFinal() * PbGrid.Width;
                Y = P.GetYFinal() * PbGrid.Height;
                //GpContructionSite.DrawRectangle(PnRed, (float)X - size / 2, (float)Y - size / 2, size, size);
                GpContructionSite.FillEllipse(BsBlue, (float)X - size / 2, (float)Y - size / 2, size, size);
                GpContructionSite.DrawEllipse(PnBlue, (float)(X - size2 / 2), (float)(Y - size3 / 2), (float)size2, (float)size3);
            }

        }

        //function to draw the pedestrians
        private void DrawPedestrian(Pedestrian[] Peds)
        {
            double X, Y;
            int size = 10;
            double scale = 10;
            foreach (Pedestrian P in Peds)
            {
                X = P.GetX() * PbGrid.Width;
                Y = P.GetY() * PbGrid.Height;
                GpContructionSite.FillEllipse(BsGreen, (float)X - size / 2, (float)Y - size / 2, size, size);
                
                GpContructionSite.DrawLine(PnRed, (float)X, (float)Y, (float)(X + P.RepulsiveX * PbGrid.Width*scale), (float)(Y + (P.RepulsiveY * PbGrid.Height)*scale));
                GpContructionSite.DrawLine(PnBlue, (float)X, (float)Y, (float)(X + P.AtractiveX * PbGrid.Width * scale), (float)(Y + (P.AtractiveY * PbGrid.Height) * scale));
                GpContructionSite.DrawLine(PnGreen, (float)X, (float)Y, (float)(X + P.DeltaX * PbGrid.Width * scale), (float)(Y + (P.DeltaY * PbGrid.Height) * scale));
            }           

        }

        //function to draw the grid
        private void DrawGrid(Construction_site Csite)
        {
            double deltaX, deltaY;
            deltaX = Csite.GetHeight() / Csite.GetGridSize() ;
            deltaY = Csite.GetWidth() / Csite.GetGridSize();

            double PbdeltaX, PbdeltaY;
            PbdeltaX=PbGrid.Width/ Csite.GetGridSize();
            PbdeltaY = PbGrid.Height / Csite.GetGridSize();

            for (int i = 0; i < Csite.GetGridSize(); i++)
            {
                GpContructionSite.DrawLine(PnAqua, i * (float)PbdeltaX, 0, i * (float)PbdeltaX, PbGrid.Height);
                GpContructionSite.DrawLine(PnAqua,0, i * (float)PbdeltaY, PbGrid.Width, i * (float)PbdeltaY);
            }
            GpContructionSite.DrawLine(PnAqua, PbGrid.Width-1, 0, PbGrid.Width-1, PbGrid.Height);
            GpContructionSite.DrawLine(PnAqua, 0, PbGrid.Height-1, PbGrid.Width, PbGrid.Height-1);
            
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GpContructionSite.Clear(Color.White);
            TBTest.Text = "";
            double vel;
            foreach (Pedestrian P in Pedestrians)
            {
                P.GetForce(Els);
                vel = Math.Sqrt(P.DeltaX * P.DeltaX + P.DeltaY * P.DeltaY);
                TBTest.Text+=vel.ToString()+"\r\n";
            }
            
            DrawGrid(Site);
            DrawElement(Els);
            DrawRepulsiveField(Site);
            DrawGoal(Pedestrians);

            DrawPedestrian(Pedestrians);
            PbGrid.Refresh();
        }
    }
}
