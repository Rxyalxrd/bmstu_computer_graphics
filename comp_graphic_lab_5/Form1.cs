using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;


namespace Laba_2
{
    public partial class Form1 : Form
    {
        private float OA, AB, AM;
        private float ScreenH = 475, ScreenW = 620;
        private float xA, yA, xM, yM, xB;
        private float angle;
        private float[,] GraphValuesArray;
        private int elements_count = 0;
        private bool not_calculate;
        private int check = 0;
        
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);

            // очистка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            // в зависимости от того, какая сторона больше 
            // мы немного варьируем то, как будет сконфигурированный настройки проекции 
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Height / (float)AnT.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();


        }

        private void new_parametrs()
        {
            OA = trackBar1.Value;
            AB = trackBar2.Value;
            AM = trackBar3.Value;
            ScreenW = (OA + AB) * 2.2f * (float)AnT.Width / (float)AnT.Height;
            ScreenH = (OA + AB) * 2.2f;
        }


        private void Graph()
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(-ScreenW / 2, 0);
            Gl.glVertex2d(ScreenW / 2, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(0, -ScreenH / 2);
            Gl.glVertex2d(0, ScreenH / 2);
            Gl.glEnd();

            Gl.glPointSize(5);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3f(255, 0, 0);
            Gl.glVertex2d(0, 0);
            Gl.glVertex2d(xA, yA);
            Gl.glVertex2d(xB, 0);
            Gl.glVertex2d(xM, yM);
            Gl.glColor3f(0, 0, 0);
            Gl.glEnd();
            Gl.glPointSize(1);

            PrintText2D((OA + AB) / 20, (OA + AB) / 20, "O");
            PrintText2D(xA, yA + (OA + AB) / 20, "A");
            PrintText2D(xM, yM - (OA + AB) / 15, "M");
            PrintText2D(xB, (OA + AB) / 20, "B");

            Gl.glLineWidth(2);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(0, 0);
            Gl.glVertex2d(xA, yA);
            Gl.glVertex2d(xB, 0);
            Gl.glEnd();
            Gl.glLineWidth(1);
        }


        private void Move_var1()
        {
            xM = (float)((OA + AM) * Math.Cos(Radian(angle)));
            yM = (float)((OA - AM) * Math.Sin(Radian(angle)));
            if (angle <= 360)
                angle += 0.5f;
            else
                angle = 0.5f;
            xA = (float)((OA) * Math.Cos(Radian(angle)));
            yA = (float)((OA) * Math.Sin(Radian(angle)));
            xB = (float)((OA + AB) * Math.Cos(Radian(angle)));
        }

        private void Move_var2()
        {
            switch (check)
            {
                case 0:
                    {
                        if (yA < AB)
                        {
                            xA = (float)(OA * Math.Cos(Radian(angle)));
                            yA = (float)((OA) * Math.Sin(Radian(angle)));
                            if (angle <= Math.Asin(AB / OA) * 180 / Math.PI)
                            {
                                xB = (float)(OA * Math.Cos(Radian(angle)) + Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))));
                                xM = (float)(xB - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB * (AB - AM));
                                yM = (float)((AB - AM) * Math.Sqrt(1 - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB
                                    * Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB));
                            }
                            else
                            {
                                xB = (float)(xA);
                                xM = xB;
                                yM = yA - AM;
                            }
                            angle += 0.5f;
                        }
                        else
                            check = 1;
                        break;
                    }
                case 1:
                    {
                        if (-yA <= AB)
                        {
                            angle -= 0.5f;
                            if (angle >= Math.Asin(AB / OA) * 180 / Math.PI)
                                angle -= 0.5f;
                            xB = (float)(xA - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))));
                            xA = (float)(OA * Math.Cos(Radian(angle)));
                            yA = (float)((OA) * Math.Sin(Radian(angle)));
                            if (angle >= 0)
                            {
                                yM = (float)((AB - AM) * Math.Sqrt(1 - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB
                                     * Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB));
                            }
                            else
                            {
                                yM = (float)(-(AB - AM) * Math.Sqrt(1 - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB
                                     * Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB));

                            }
                            xM = (float)(xB + Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB * (AB - AM));
                            if (angle <= -Math.Asin(AB / OA) * 180 / Math.PI)
                            {
                                xB = xA;
                                xM = xA;
                                yM = yA + AM;
                            }
                        }
                        else
                        {
                            check = 3;
                        }
                        break;
                    }
                case 3:
                    {
                        if (angle < 0)
                        {
                            angle += 0.5f;
                            xA = (float)(OA * Math.Cos(Radian(angle)));
                            yA = (float)((OA) * Math.Sin(Radian(angle)));
                            xB = (float)(xA + Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))));
                            xM = (float)(xB - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB * (AB - AM));
                            yM = (float)(-(AB - AM) * Math.Sqrt(1 - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB
                                 * Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB));
                        }
                        else
                        {
                            check = 0;
                        }
                        break;
                    }
            }
        }

        
        private void Move_var3()
        {
            xA = (float)(OA * Math.Cos(Radian(angle)));
            yA = (float)((OA) * Math.Sin(Radian(angle)));
            xB = (float)(xA + Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))));
            xM = (float)(xB - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB * (AB - AM));
            if (angle <= 180)
                yM = (float)((AB - AM) * Math.Sqrt(1 - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB
                      * Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB));
            else
                yM = (float)(-(AB - AM) * Math.Sqrt(1 - Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB
                      * Math.Sqrt(AB * AB - (OA * OA) * Math.Sin(Radian(angle)) * Math.Sin(Radian(angle))) / AB));
            if (angle < 360)
                angle += 0.5f;
            else
                angle = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Пауза")
            {
                timer1.Enabled = false;
                button2.Text = "Продолжить";
            }
            else
            {
                timer1.Enabled = true;
                button2.Text = "Пауза";
            }
        }

        private void Draw_Way()
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glColor3f(255, 0, 0);
            for (int ax = 0; ax < elements_count; ax += 1)
            {
                Gl.glVertex2d(GraphValuesArray[ax, 0], GraphValuesArray[ax, 1]);
            }
            Gl.glColor3f(0, 0, 0);
            Gl.glEnd();
        }

        private void trackBar4_Scroll(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);
            Gl.glPushMatrix();
            Gl.glTranslated(ScreenW / 2, ScreenH / 2, 0);

            Graph();

            if (OA == AB)
                Move_var1();
            else if (OA > AB)
                Move_var2();
            else
                Move_var3();
            Way();

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GraphValuesArray = new float[100000, 2];
            if (trackBar3.Value > trackBar2.Value)
            {
                trackBar3.Value = trackBar2.Value;
            }
            elements_count = 0;
            Init(AnT);
            new_parametrs();
            ScreenW = (OA + AB) * 2.2f * (float)AnT.Width / (float)AnT.Height;
            ScreenH = (OA + AB) * 2.2f;
            xA = OA; yA = 0;
            xM = OA + AM; yM = 0;
            xB = OA + AB;
            angle = 0;
            check = 0;
            not_calculate = true;
            elements_count = 0;
            Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            timer1.Enabled = true;

        }

        private float Radian(float angle) { 
            return (float)((Math.PI / 180.0) * angle); 
        }

        private void Init(SimpleOpenGlControl x)
        {
            Gl.glViewport(0, 0, x.Width, x.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);
        }

        private void PrintText2D(float x, float y, string text)
        {
            Gl.glRasterPos2f(x, y);
            foreach (char char_for_draw in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
            }
        }

        private void Way()
        {
            if (not_calculate && angle < 360)
            {
                GraphValuesArray[elements_count, 0] = xM;
                GraphValuesArray[elements_count, 1] = yM;
                elements_count++;
            }
            else
                not_calculate = false;
            if (checkBox1.Checked)
                Draw_Way();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            timer1.Interval = trackBar4.Value;
        }

    }
}
