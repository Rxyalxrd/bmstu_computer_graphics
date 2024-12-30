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

namespace Labb1
{
    public partial class Form1 : Form
    {
        float x_min = -15, x_max = 15, y_min = -15, y_max = 15;
        float pointR, pointG, pointB;
        float axisR, axisG, axisB;
        float graphR, graphG, graphB;
         
        // размеры окна 
        double ScreenW, ScreenH;

        // отношения сторон окна визуализации 
        // для корректного перевода координат мыши в координаты, 
        // принятые в программе 

        private float devX;
        private float devY;

        // массив, который будет хранить значения x,y точек графика 
        private float[,] GrapValuesArray;
        // количество элементов в массиве 
        private int elements_count = 0;

        // флаг, означающий, что массив с значениями координат графика пока еще не заполнен 
        private bool not_calculate = true;

        // номер ячейки массива, из которой будут взяты координаты для красной точки 
        // для визуализации текущего кадра 
        private int pointPosition = 0;

        // вспомогательные переменные для построения линий от курсора мыши к координатным осям 
        float lineX, lineY;

        // текущение координаты курсора мыши 
        float Mcoord_X = 0, Mcoord_Y = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length == 0) || (textBox1.Text == "-") || (textBox1.Text == "+"))
            {
                textBox1.Text = "5";
            }
            y_max = Convert.ToInt32(textBox1.Text); ScreenUpdate();
        }

        private void ScreenUpdate()
        {
            functionCalculation();

            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();

            // определение параметров настройки проекции в зависимости от размеров сторон элемента AnT. 
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 1.01 * (x_max - x_min);
                ScreenH = 1.01 * (y_max - y_min);
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 1.01 * (x_max - x_min);
                ScreenH = 1.01 * (y_max - y_min);
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }

            // сохранение коэффициентов, которые нам необходимы для перевода координат указателя в оконной системе в координаты, 
            // принятые в нашей OpenGL сцене 
            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // изменяем флаг, сигнализировавший о том, что координаты графика не вычислены 
            not_calculate = true;
            // старт счетчика, отвечающего за вызов функции визуализации сцены 
            PointInGrap.Start();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox3.Text.Length == 0) || (textBox3.Text == "-") || (textBox3.Text == "+"))
            {
                textBox3.Text = "-5";
            }
       
               x_min = Convert.ToInt32(textBox3.Text); ScreenUpdate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text.Length == 0) || (textBox2.Text == "-") || (textBox2.Text == "+"))
            {
                textBox2.Text = "-5";
            }

            y_min = Convert.ToInt32(textBox2.Text); ScreenUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox4.Text.Length == 0) || (textBox4.Text == "-") || (textBox4.Text == "+"))
            {
                textBox4.Text = "5";
            }
            x_max = Convert.ToInt32(textBox4.Text); 
            
                ScreenUpdate();
      
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            AnT.InitializeContexts();
        }

        private void PointInGrap_Tick(object sender, EventArgs e)
        {

            // если мы дошли до последнего элемента массива 
            if (pointPosition == elements_count - 1)
                pointPosition = 0; // переходим к начальному элементу 

            // функция визуализации 
            Draw();

            // переход к следующему элементу массива 
            pointPosition++;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // инициализация библиотеки glut 
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();

            // определение параметров настройки проекции в зависимости от размеров сторон элемента AnT. 
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 1.01 * (x_max - x_min);
                ScreenH = 1.01 * (y_max - y_min);
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 1.01 * (x_max - x_min);
                ScreenH = 1.01 * (y_max - y_min);
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }

            // сохранение коэффициентов, которые нам необходимы для перевода координат указателя в оконной системе в координаты, 
            // принятые в нашей OpenGL сцене 
            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            // старт счетчика, отвечающего за вызов функции визуализации сцены 
            PointInGrap.Start();

        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            // сохраняем координаты мыши 
            Mcoord_X = e.X;
            Mcoord_Y = e.Y;

            // вычисляем параметры для будущей дорисовки линий от указателя мыши к координатным осям. 
            lineX = devX * e.X;
            lineY = (float)(ScreenH - devY * e.Y);
        }

        // функция визуализации текста 
        private void PrintText2D(float x, float y, string text)
        {

            // устанавливаем позицию вывода растровых символов 
            // в переданных координатах x и y. 
            Gl.glRasterPos2f(x, y);

            // в цикле foreach перебираем значения из массива text, 
            // который содержит значение строки для визуализации 
            foreach (char char_for_draw in text)
            {
                // символ C визуализируем с помощью функции glutBitmapCharacter, используя шрифт GLUT_BITMAP_9_BY_15. 
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
            }

        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            functionCalculation();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    pointR = colorDialog1.Color.R;
                    pointG = colorDialog1.Color.G;
                    pointB = colorDialog1.Color.B;
                    break;
                case 1:
                    axisR = colorDialog1.Color.R;
                    axisG = colorDialog1.Color.G;
                    axisB = colorDialog1.Color.B;
                    break;
                case 2:
                    graphR = colorDialog1.Color.R;
                    graphG = colorDialog1.Color.G;
                    graphB = colorDialog1.Color.B;
                    break;
                case 3:
                    graphR = colorDialog1.Color.R;
                    graphG = colorDialog1.Color.G;
                    graphB = colorDialog1.Color.B;
                    break;

                default:
                    break;
            }
        }

        // функция, производящая вычисления координат графика 
        // и заносящая их в массив GrapValuesArray 
        private void functionCalculation()
        {

            // определение локальных переменных X и Y 
            float x = 0, y = 0;

            // инициализация массива, который будет хранить значение 300 точек, 
            // из которых будет состоять график 

            GrapValuesArray = new float[(int)(x_max - x_min) * 10 + 1, 2];

            // счетчик элементов массива 
            elements_count = 0;

            // вычисления всех значений y для x, принадлежащего промежутку от -15 до 15 с шагом в 0.01f 
            for (x = x_min; x < x_max; x += 0.1f)
            {
                // вычисление y для текущего x 
                // по формуле y = (float)Math.Sin(x)*3 + 1; 
                // эта строка задает формулу, описывающую график функции для нашего уравнения y = f(x). 
                switch(comboBox1.SelectedIndex)
                {
                    case 0:
                        y = (float)Math.Sin(x) * 3 + 1;
                        break;
                    case 1:
                        y = (float)Math.Abs(x) - 2;
                        break;
                    case 2:
                        y = (float)(1 / x) + 3;
                        break;
                    case 3:
                        y = Math.Abs(Math.Abs(x - 3) - 5) + 10 * (float)Math.Sin(x);
                        break;
                  
                    case -1:
                        y = (float)Math.Sin(x) * 3 + 1;
                        break;
                }
                //y = (float)Math.Sin(x) * 3 + 1;

                // запись координаты x 
                GrapValuesArray[elements_count, 0] = x;
                // запись координаты y 
                GrapValuesArray[elements_count, 1] = y;
                // подсчет элементов 
                elements_count++;

            }

            // изменяем флаг, сигнализировавший о том, что координаты графика не вычислены 
            not_calculate = false;
        }

        // визуализация графика 
        private void DrawDiagram()
        {

            // проверка флага, сигнализирующего о том, что координаты графика вычислены 
            if (not_calculate)
            {
                // если нет, то вызываем функцию вычисления координат графика 
                functionCalculation(); pointPosition = 0;
            }

            // стартуем отрисовку в режиме визуализации точек 
            // объединяемых в линии (GL_LINE_STRIP) 
            Gl.glBegin(Gl.GL_LINE_STRIP);

            // рисуем начальную точку 
            Gl.glVertex2d(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);

            // проходим по массиву с координатами вычисленных точек 
            for (int ax = 1; ax < elements_count; ax += 2)
            {
                // передаем в OpenGL информацию о вершине, участвующей в построении линий 
                Gl.glVertex2d(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            }

            // завершаем режим рисования 
            Gl.glEnd();

            // устанавливаем размер точек, равный 5 пикселям 
            Gl.glPointSize(5);
            // устанавливаем текущим цветом - красный цвет 
            Gl.glColor3f(pointR, pointG, pointB);
            // активируем режим вывода точек (GL_POINTS) 
            Gl.glBegin(Gl.GL_POINTS);
            // выводим красную точку, используя ту ячейку массива, до которой мы дошли (вычисляется в функции обработчике событий таймера) 
            Gl.glVertex2d(GrapValuesArray[pointPosition, 0], GrapValuesArray[pointPosition, 1]);
            // завершаем режим рисования 
            Gl.glEnd();
            // устанавливаем размер точек равный единице 
            Gl.glPointSize(1);

        }

        // функция, управляющая визуализацией сцены 
        private void Draw()
        {

            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // установка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            // выполняем перемещение в пространстве по осям X и Y 
            Gl.glTranslated(-x_min, -y_min, 0);
            float w, h; w = -x_min; h = -y_min;

            // активируем режим рисования (Указанные далее точки будут выводиться как точки GL_POINTS) 
            Gl.glBegin(Gl.GL_POINTS);

            // с помощью прохода вдумя циклами, создаем сетку из точек 
            for (int ax = (int)x_min; ax < x_max; ax++)
            {
                for (int bx = (int)y_min; bx < y_max; bx++)
                {
                    // вывод точки 
                    Gl.glVertex2d(ax, bx);
                }
            }

            // завершение режима рисования примитивов 
            Gl.glEnd();

            // активируем режим рисования, каждые 2 последовательно вызванные команды glVertex 
            // объединяются в линии 
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f((float)(axisR / 255.0), (float)(axisG / 255.0), (float)(axisB / 255.0));

            // далее мы рисуем координатные оси и стрелки на их концах 
            Gl.glVertex2d(0, y_min);
            Gl.glVertex2d(0, y_max);

            Gl.glVertex2d(x_min, 0);
            Gl.glVertex2d(x_max, 0);

            // вертикальная стрелка 
            Gl.glVertex2d(0, y_max);
            Gl.glVertex2d(0.1, y_max - 0.5);
            Gl.glVertex2d(0, y_max);
            Gl.glVertex2d(-0.1, y_max);

            // горизонтальная стрелка 
            Gl.glVertex2d(x_max, 0);
            Gl.glVertex2d(x_max - 0.5, 0.1);
            Gl.glVertex2d(x_max, 0);
            Gl.glVertex2d(x_max - 0.5, -0.1);

            // завершаем режим рисования 
            Gl.glEnd();

            // выводим подписи осей "x" и "y" 
            PrintText2D((float)(x_max + 0.5), 0, "x");
            PrintText2D(0.5f, (float)(y_max - 0.5), "y");

            Gl.glColor3f((float)(graphR / 255.0), (float)(graphG / 255.0), (float)(graphB / 255.0));
            // вызываем функцию рисования графика 
            DrawDiagram();

            // возвращаем матрицу из стека 
            Gl.glPopMatrix();

            // выводим текст со значением координат возле курсора 
            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[ x: " + (devX * Mcoord_X - w).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y - h).ToString() + "]");

            // устанавливаем красный цвет 
            Gl.glColor3f((float)(pointR / 255.0), (float)(pointG / 255.0), (float)(pointB / 255.0));

            // включаем режим рисования линий, для того чтобы нарисовать 
            // линии от курсора мыши к координатным осям 
            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex2d(lineX, h);
            Gl.glVertex2d(lineX, lineY);
            Gl.glVertex2d(w, lineY);
            Gl.glVertex2d(lineX, lineY);

            Gl.glEnd();

            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();

            // сигнал для обновление элемента реализующего визуализацию. 
            AnT.Invalidate();
        }

    }
}
