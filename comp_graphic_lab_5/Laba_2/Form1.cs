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
            ;


        }

        private void btnA_Click(object sender, EventArgs e)
        {

            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // очищаем текущую матрицу 
            Gl.glLoadIdentity();
            // устанавливаем текущий цвет - красный или выбор пользователя

            if (chbDefault.Checked) // если пользователь хочет использовать настройки по умолчанию
            {
                
                Gl.glColor3f(255, 0, 0); // устанавливаем текущий цвет - зеленый
            }
            else                    // хочет настроить сам
            {
                Gl.glColor3f(trbR.Value, trbG.Value, trbB.Value);       // смотрим настройку цвета
            }


            // активируем режим рисования линий на основе 
            // последовательного соединения всех вершин в отрезки 
            Gl.glBegin(Gl.GL_LINE_LOOP);
            // первая вершина будет находиться в начале координат 

            Gl.glVertex2d(8, 7);
            Gl.glVertex2d(15, 27);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(23, 7);
            Gl.glVertex2d(21, 7);
            Gl.glVertex2d(19, 14);
            Gl.glVertex2d(12.5, 14);
            Gl.glVertex2d(10, 7);

            // завершаем режим рисования 
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(18.5, 16);
            Gl.glVertex2d(16, 25);
            Gl.glVertex2d(13.2, 16);

            // завершаем режим рисования 
            Gl.glEnd();




            // дожидаемся конца визуализации кадра 
            Gl.glFlush();

            // посылаем сигнал перерисовки элемента AnT. 
            AnT.Invalidate();


        }

        private void btnFIO_Click(object sender, EventArgs e)
        {
            double x0, y0, h, w, sp = 1.0;
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // очищаем текущую матрицу 
            Gl.glLoadIdentity();

            // устанавливаем текущий цвет, размеры и положение
            if (chbDefault.Checked) // если пользователь хочет использовать настройки по умолчанию
            {
                x0 = 5.0; y0 = 5.0; h = 12.0; w = 8.0; // задаем переменные
                Gl.glColor3f(0, 255, 0);                // устанавливаем текущий цвет - зеленый
            }
            else                    // хочет настроить сам
            {
                x0 = trbX.Value; y0 = trbY.Value; h = trbH.Value; w = trbW.Value; // смотрим настройку переменных
                Gl.glColor3f(trbR.Value, trbG.Value, trbB.Value);       // смотрим настройку цвета
            }

            // активируем режим рисования линий на основе 
            // последовательного соединения всех вершин в отрезки 
            Gl.glBegin(Gl.GL_LINE_LOOP);    //БУКВА К
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0,               y0);
            Gl.glVertex2d(x0,               y0 + h);
            Gl.glVertex2d(x0 + 1 / 4.0 * w, y0 + h);
            Gl.glVertex2d(x0 + 1 / 4.0 * w, y0 + 2 / 3.0 * h);
            Gl.glVertex2d(x0 + w,           y0 + h);
            Gl.glVertex2d(x0 + w,           y0 + 5 / 6.0 * h);
            Gl.glVertex2d(x0 + 1 / 4.0 * w, y0 + 1 / 2.0 * h);
            Gl.glVertex2d(x0 + w,           y0);
            Gl.glVertex2d(x0 + 3 / 4.0 * w, y0);
            Gl.glVertex2d(x0 + 1 / 4.0 * w, y0 + 1 / 3.0 * h);
            Gl.glVertex2d(x0 + 1 / 4.0 * w, y0);
            // завершаем режим рисования 
            Gl.glEnd();


            Gl.glBegin(Gl.GL_LINE_LOOP);    //БУКВА А
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0 + sp + w,          y0);
            Gl.glVertex2d(x0 + sp + 3/2.0*w,    y0+ h);
            Gl.glVertex2d(x0 + sp + 2.0*w,      y0);
            Gl.glVertex2d(x0 + sp + 7/4.0*w,    y0);
            Gl.glVertex2d(x0 + sp + 13/8.0*w,   y0+ 1/4.0*h);
            Gl.glVertex2d(x0 + sp + 11/8.0*w,   y0+ 1/4.0*h);
            Gl.glVertex2d(x0 + sp + 5/4.0*w,    y0);
            Gl.glVertex2d(x0 + sp + w,          y0);
            // завершаем режим рисования 
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);    //БУКВА А(внутр.часть)
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0 + sp + 11/8.0*w,   y0+ 5/12.0*h);
            Gl.glVertex2d(x0 + sp + 3/2.0*w,    y0+ 2/3.0*h);
            Gl.glVertex2d(x0 + sp + 13/8.0*w,   y0+ 5/12.0*h);
            // завершаем режим рисования 
            Gl.glEnd();


            Gl.glBegin(Gl.GL_LINE_LOOP);    ////БУКВА В
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0 + 2*sp + 2*w,        y0);
            Gl.glVertex2d(x0 + 2*sp + 2*w,        y0+ h);
            Gl.glVertex2d(x0 + 2*sp + 23/8.0*w,   y0+ h);
            Gl.glVertex2d(x0 + 2*sp + 23/8.0*w,   y0+ 7/12.0*h);
            Gl.glVertex2d(x0 + 2*sp + 3*w,        y0+ 7/12.0*h);
            Gl.glVertex2d(x0 + 2*sp + 3*w,        y0);
            // завершаем режим рисования 
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);    ////БУКВА В(внутр.часть1)
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0 + 2*sp + 9/4.0*w,    y0+ 11/12.0*h);
            Gl.glVertex2d(x0 + 2*sp + 21/8.0*w,   y0+ 11/12.0*h);
            Gl.glVertex2d(x0 + 2*sp + 21/8.0*w,   y0+ 2/3.0*h);
            Gl.glVertex2d(x0 + 2*sp + 9/4.0*w,    y0+ 2/3.0*h);
            // завершаем режим рисования 
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);    ////БУКВА В(внутр.часть2)
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0 + 2*sp + 9/4.0*w,    y0+ 1/2.0*h);
            Gl.glVertex2d(x0 + 2*sp + 11/4.0*w,   y0+ 1/2.0*h);
            Gl.glVertex2d(x0 + 2*sp + 11/4.0*w,   y0+ 1/6.0*h);
            Gl.glVertex2d(x0 + 2*sp + 9/4.0*w,    y0+ 1/6.0*h);
            // завершаем режим рисования 
            Gl.glEnd();


            // дожидаемся конца визуализации кадра 
            Gl.glFlush();

            // посылаем сигнал перерисовки элемента AnT. 
            AnT.Invalidate();

        }

        private void btnAni_Click(object sender, EventArgs e)
        {
            double x0, y0, h, w;

            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // очищаем текущую матрицу 
            Gl.glLoadIdentity();


            // устанавливаем текущий цвет, размеры и положение
            if (chbDefault.Checked) // если пользователь хочет использовать настройки по умолчанию
            {
                x0 = 5.0; y0 = 0; h = 27.0; w = 16.5; // задаем переменные
                Gl.glColor3f(1.0f, 0.6f, 0.4f);          // устанавливаем текущий цвет - зеленый
            }
            else                    // хочет настроить сам
            {
                x0 = trbX.Value; y0 = trbY.Value; h = trbH.Value; w = trbW.Value; // смотрим настройку переменных
                Gl.glColor3f((float)(trbR.Value/255.0), (float)(trbG.Value/255.0), (float)(trbB.Value/255.0));       // смотрим настройку цвета
            }



            // активируем режим рисования линий на основе 
            // последовательного соединения всех вершин в отрезки 
            Gl.glBegin(Gl.GL_LINE_LOOP);    //рисуем животное
            // первая вершина будет находиться в начале координат 
            Gl.glVertex2d(x0, y0+ 1/18.0*h);
            Gl.glVertex2d(x0, y0+ 3/18.0*h);
            Gl.glVertex2d(x0+ 2/11.0*w, y0+ 5/18.0*h);
            Gl.glVertex2d(x0+ 1/11.0*w, y0+ 6/18.0*h);
            Gl.glVertex2d(x0+ 1/11.0*w, y0+ 7/18.0*h);
            Gl.glVertex2d(x0+ 2/11.0*w, y0+ 8/18.0*h);
            Gl.glVertex2d(x0+ 2/11.0*w, y0+ 15/18.0*h);
            Gl.glVertex2d(x0+ 1/11.0*w, y0+ 15/18.0*h);
            Gl.glVertex2d(x0, y0+ 16/18.0*h);
            Gl.glVertex2d(x0+ 1/11.0*w, y0+ 17/18.0*h);
            Gl.glVertex2d(x0+ 3/11.0*w, y0+ 17/18.0*h);
            Gl.glVertex2d(x0+ 3/11.0*w, y0+ h);
            Gl.glVertex2d(x0+ 4/11.0*w, y0+ h);
            Gl.glVertex2d(x0+ 4/11.0*w, y0+ 8/18.0*h);
            Gl.glVertex2d(x0+ 8/11.0*w, y0+ 8/18.0*h);
            Gl.glVertex2d(x0+ 10/11.0*w, y0+ 6/18.0*h);
            Gl.glVertex2d(x0+ w, y0+ 6/18.0*h);
            Gl.glVertex2d(x0+ w, y0+ 5/18.0*h);
            Gl.glVertex2d(x0+ 10/11.0*w, y0+ 5/18.0*h);
            Gl.glVertex2d(x0+ 10/11.0*w, y0+ 6/18.0*h);
            Gl.glVertex2d(x0+ 8/11.0*w, y0+ 8/18.0*h);
            Gl.glVertex2d(x0+ 8/11.0*w, y0);
            Gl.glVertex2d(x0+ 7/11.0*w, y0);
            Gl.glVertex2d(x0+ 7/11.0*w, y0+ 5/18.0*h);
            Gl.glVertex2d(x0+ 7/11.0*w, y0);
            Gl.glVertex2d(x0+ 6/11.0*w, y0);
            Gl.glVertex2d(x0+ 6/11.0*w, y0+ 5/18.0*h);
            Gl.glVertex2d(x0+ 3/11.0*w, y0+ 5/18.0*h);
            Gl.glVertex2d(x0+ 3/11.0*w, y0);
            Gl.glVertex2d(x0+ 2/11.0*w, y0);
            Gl.glVertex2d(x0+ 2/11.0*w, y0+ 4/18.0*h);
            Gl.glVertex2d(x0+ 1/11.0*w, y0+ 3/18.0*h);
            Gl.glVertex2d(x0+ 1/11.0*w, y0+ 1/18.0*h);

            // завершаем режим рисования 
            Gl.glEnd();

            // дожидаемся конца визуализации кадра 
            Gl.glFlush();

            // посылаем сигнал перерисовки элемента AnT. 
            AnT.Invalidate();

        }

        private void lblH_Click(object sender, EventArgs e)
        {

        }
    }
}
