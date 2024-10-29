using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace comp_grahic_lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Height / (float)AnT.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }

            Gl.glMatrixMode((Gl.GL_MODELVIEW));
            Gl.glLoadIdentity();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(255, 0, 0);


            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(8, 7);
            Gl.glVertex2d(15, 27);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(23, 7);
            Gl.glVertex2d(21, 7);
            Gl.glVertex2d(19, 14);
            Gl.glVertex2d(12.5, 14);
            Gl.glVertex2d(10, 7);
 
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(18.5, 16);
            Gl.glVertex2d(16, 25);
            Gl.glVertex2d(13.2, 16);

            Gl.glEnd();

            Gl.glFlush();

            AnT.Invalidate();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0.0f, 0.0f);

            double W = 10.0, H = 15.0;  // Ширина и высота букв
            double X0 = 1.0, Y0 = 1.0;  // Координаты левого нижнего угла
            double d = 5.0;             // Расстояние между буквами

            DrawLetterB(X0, Y0, W, H);                              // Б
            DrawLetterM(X0 + W + d, Y0, W, H);                      // М
            DrawLetterD(X0 + (W * 2) + (2 * d), Y0, W, H);          // Д

            Gl.glFlush();
            AnT.Invalidate();
        }

        void DrawLetterB(double X0, double Y0, double W, double H)
        {
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(X0, Y0);                          
            Gl.glVertex2d(X0, Y0 + H);                      
            Gl.glVertex2d(X0 + W, Y0 + H);                  
            Gl.glVertex2d(X0 + W, Y0 + H * 3 / 4);          
            Gl.glVertex2d(X0 + W / 2, Y0 + H * 3 / 4);      
            Gl.glVertex2d(X0 + W / 2, Y0 + H / 2.5);       
            Gl.glVertex2d(X0 + W, Y0 + H / 2.5);            
            Gl.glVertex2d(X0 + W, Y0);                      
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(X0 + W / 2, (Y0 + H / 2.5) * 3 / 4);
            Gl.glVertex2d((X0 + W) - 1, (Y0 + H / 2.5) * 3 / 4);
            Gl.glVertex2d((X0 + W) - 1, Y0 + 2);
            Gl.glVertex2d(X0 + W / 2, Y0 + 2);
            Gl.glEnd();
        }

        void DrawLetterM(double X0, double Y0, double W, double H)
        {
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(X0, Y0);
            Gl.glVertex2d(X0, Y0 + H);
            Gl.glVertex2d(X0 + W / 2, Y0 + H / 2);
            Gl.glVertex2d(X0 + W, Y0 + H);
            Gl.glVertex2d(X0 + W, Y0);
            Gl.glVertex2d(X0 + W * 6 / 7, Y0);
            Gl.glVertex2d(X0 + W * 6 / 7, Y0 + H / 2);
            Gl.glVertex2d(X0 + W / 2, Y0 + H / 4);
            Gl.glVertex2d(X0 + W * 1 / 7, Y0 + H / 2);
            Gl.glVertex2d(X0 + W * 1 / 7, Y0);
            Gl.glEnd();
        }

        void DrawLetterD(double X0, double Y0, double W, double H)
        {
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(X0, Y0);
            Gl.glVertex2d(X0, Y0 + H / 5);
            Gl.glVertex2d(X0 + W / 4, Y0 + H / 5);
            Gl.glVertex2d(X0 + W / 4, Y0 + H);
            Gl.glVertex2d(X0 + W * 3 / 4, Y0 + H);
            Gl.glVertex2d(X0 + W * 3 / 4, Y0 + H / 5);
            Gl.glVertex2d(X0 + W, Y0 + H / 5);
            Gl.glVertex2d(X0 + W, Y0);
            Gl.glVertex2d(X0 + W * 8 / 10, Y0);
            Gl.glVertex2d(X0 + W * 8 / 10, Y0 + H * 0.1);
            Gl.glVertex2d(X0 + W * 2 / 10, Y0 + H * 0.1);
            Gl.glVertex2d(X0 + W * 2 / 10, Y0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(X0 + W / 3, Y0 + H / 5);
            Gl.glVertex2d(X0 + W / 3, Y0 + H * 19 / 20);
            Gl.glVertex2d(X0 + W * 2 / 3, Y0 + H * 19 / 20);
            Gl.glVertex2d(X0 + W * 2 / 3, Y0 + H / 5);
            Gl.glEnd();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double W = 30.0, H = 25.0;  // Ширина и высота букв
            double X0 = 30.0, Y0 = 5.0;  // Координаты левого нижнего угла

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0.0f, 0.0f);

            DrawBoat(X0, Y0, W, H);

            Gl.glFlush();
            AnT.Invalidate();
        }

        void DrawBoat(double X0, double Y0, double W, double H)
        {
            
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(X0, Y0);
            Gl.glVertex2d(X0 + W * 0.15, Y0);
            Gl.glVertex2d(X0 + W * 0.25, Y0 + H * 0.1);
            Gl.glVertex2d(X0 + W * 0.15, Y0 + H * 0.1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(X0 * 0.97, Y0);
            Gl.glVertex2d(X0 - W * 0.25, Y0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(X0 - W * 0.3, Y0);
            Gl.glVertex2d(X0 - W * 0.45, Y0);
            Gl.glVertex2d(X0 - W * 0.55, Y0 + H * 0.1);
            Gl.glVertex2d(X0 - W * 0.45, Y0 + H * 0.1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(X0 - W * 0.4, Y0 + H * 0.1);
            Gl.glVertex2d(X0 - W * 0.18, Y0 + H * 0.1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(X0 + W * 0.1, Y0 + H * 0.1);
            Gl.glVertex2d(X0 - W * 0.13, Y0 + H * 0.1);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(X0 - W * 0.155, Y0 + H * 0.1);
            Gl.glVertex2d(X0 - W * 0.155, Y0 + H * 0.25);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(X0 - W * 0.155, Y0 + H * 0.3);
            Gl.glVertex2d(X0 - W * 0.155, Y0 + H * 0.45);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(X0 - W * 0.155, Y0 + H * 0.45);
            Gl.glVertex2d(X0 - W * 0.05, Y0 + H * 0.35);
            Gl.glVertex2d(X0 - W * 0.05, Y0 + H * 0.2);
            Gl.glVertex2d(X0 - W * 0.155, Y0 + H * 0.1);
            Gl.glEnd();

        }

    }
}
