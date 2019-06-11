using System;
using System.Drawing;
using System.Windows.Forms;

namespace FindPath
{   
    // + ходи по діагоналі + точно оптимальний шлях + лінія
    public partial class Form1 : Form
    {
        RectangleF[,] rectangles; // розміри кожного прямокутника
        Brush[,] brushes; // колір кожного прямокутника
        double[,] mapW; // карта лабіринту з "вагами"
        int[,] stepmap; // карта лабіринту з кроками 
        int[,] line; // найкращий шлях
        
        int widthInRectangles, heightInRectangles;
        double probability;

        Brush blocked_Brush = Brushes.DarkGray;
        Brush free_Brush = Brushes.LightGray; 
        Brush chosen_Brush = Brushes.Green; 
        Brush partOfPath_Brush = Brushes.LightGreen;
        Pen line_Pen = Pens.Black;

        bool startChosen = false, finishChosen = false;
        int startI, startJ, finishI, finishJ;
        double sqrtTwo = 1.414;
        
        public Form1()
        {
            InitializeComponent();         
            button_findPath.Enabled = false;
        }

        // змінити колір клітинок, що є шляхом
        private void changeBrushForPath(int i, int j)
        {
            if (stepmap[i, j] == -1) return; // щоб не "пройти" через перешкоду
            
            if (brushes[i,j] != chosen_Brush)
                brushes[i, j] = partOfPath_Brush;
            
            if (i - 1 >= 0 &&  Math.Round(mapW[i, j] - mapW[i - 1, j],3) == 1 && brushes[i - 1, j] != partOfPath_Brush)
                changeBrushForPath(i - 1, j);
            if (i - 1 >= 0 && j - 1 >= 0 && Math.Round(mapW[i, j] - mapW[i - 1, j - 1], 3) == sqrtTwo && brushes[i - 1, j - 1] != partOfPath_Brush)
                if (!(mapW[i, j - 1] == -1 && mapW[i - 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    changeBrushForPath(i - 1, j - 1);
            if (j - 1 >= 0 && Math.Round(mapW[i, j] - mapW[i, j - 1], 3) == 1 && brushes[i, j - 1] != partOfPath_Brush)
                changeBrushForPath(i, j - 1);
            if (i + 1 < heightInRectangles && j - 1 >= 0 && Math.Round(mapW[i, j] - mapW[i + 1, j - 1], 3) == sqrtTwo && brushes[i + 1, j - 1] != partOfPath_Brush)
                if (!(mapW[i, j - 1] == -1 && mapW[i + 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    changeBrushForPath(i + 1, j - 1);
            if (i + 1 < heightInRectangles && Math.Round(mapW[i, j] - mapW[i + 1, j], 3) == 1 && brushes[i + 1, j] != partOfPath_Brush)
                changeBrushForPath(i + 1, j);
            if (i + 1 < heightInRectangles && j + 1 < widthInRectangles && Math.Round(mapW[i, j] - mapW[i + 1, j + 1], 3) == sqrtTwo && brushes[i + 1, j + 1] != partOfPath_Brush)
                if (!(mapW[i, j + 1] == -1 && mapW[i + 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    changeBrushForPath(i + 1, j + 1);
            if (j + 1 < widthInRectangles && Math.Round(mapW[i, j] - mapW[i, j + 1], 3) == 1 && brushes[i, j + 1] != partOfPath_Brush)
                changeBrushForPath(i, j + 1);
            if (i - 1 >= 0 && j + 1 < widthInRectangles && Math.Round(mapW[i, j] - mapW[i - 1, j + 1], 3) == sqrtTwo && brushes[i - 1, j + 1] != partOfPath_Brush)
                if (!(mapW[i, j + 1] == -1 && mapW[i - 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    changeBrushForPath(i - 1, j + 1);
        }


        private void button_findPath_Click(object sender, EventArgs e)
        {
            if (!startChosen || !finishChosen)
            {
                MessageBox.Show(this, @"Для пошуку шляху оберіть 2 клітинки!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            findpath(startI, startJ, 0, 0);
            changeBrushForPath(finishI, finishJ);

            drawLine();

            button_findPath.Enabled = false;
            pictureBox1.Invalidate();
          
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if (button_generateBlocks.Enabled == false) //якщо прямокутники уже створені
            {
                float rectangleWidth = (float)(pictureBox1.Width - 1) / widthInRectangles - 1,
                   rectangleHeight = (float)(pictureBox1.Height - 1) / heightInRectangles - 1;

                for (int i = 0; i < heightInRectangles; i++)
                    for (int j = 0; j < widthInRectangles; j++)
                    {
                        // змінити розміри прямокутника 
                        rectangles[i, j] = new RectangleF(j * (rectangleWidth + 1) + 1,
                            i * (rectangleHeight + 1) + 1, // + 1 означає границю між фігурами в 1 піксель
                            rectangleWidth,
                            rectangleHeight);
                    }
                pictureBox1.Invalidate();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            numericUpDown_height.Value = 10;
            numericUpDown_width.Value = 15;
            numericUpDown_probability.Value = 0.4M;

            rectangles = null; 
            brushes = null;
            line = null;
            stepmap = null;
            mapW = null; 

            pictureBox1.Image = null; 
            pictureBox1.Invalidate();
            
            button_generateBlocks.Enabled = true;
            button_findPath.Enabled = false;

            startChosen = finishChosen = false;
        }

        // зробити клітинку "заблокованою" або вибрати її як початкову чи кінцеву 
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (button_generateBlocks.Enabled) return; // ще не існує масиву прямокутників 

            int rectangleI = (int)Math.Ceiling(e.Y / ((double)pictureBox1.Height / heightInRectangles));
            if (rectangleI != 0) rectangleI -= 1;
           
            int rectangleJ = (int)Math.Ceiling(e.X / ((double)pictureBox1.Width / widthInRectangles));
            if (rectangleJ != 0) rectangleJ -= 1;
            
            if (e.Button == MouseButtons.Left) // початкова чи кінцева клітинка
            {
                if (brushes[rectangleI, rectangleJ] == free_Brush)
                {
                    if (!startChosen) { startChosen = true; startI = rectangleI; startJ = rectangleJ; }
                    else
                    {
                        if (!finishChosen) { finishChosen = true; finishI = rectangleI; finishJ = rectangleJ; }
                        else return;
                    }
                    brushes[rectangleI, rectangleJ] = chosen_Brush;
                    
                }
                else 
                    if (brushes[rectangleI, rectangleJ] == chosen_Brush)
                {
                    if (startChosen && startI == rectangleI && startJ == rectangleJ)
                        startChosen = false;
                    else
                        if (finishChosen && finishI == rectangleI && finishJ == rectangleJ)
                        finishChosen = false;
                    brushes[rectangleI, rectangleJ] = free_Brush;
                    mapW[rectangleI, rectangleJ] = 0;
                    stepmap[rectangleI, rectangleJ] = 0;
                }
            }

            if (e.Button == MouseButtons.Right) // заблокована
            {
                if (brushes[rectangleI, rectangleJ] == free_Brush)
                { brushes[rectangleI, rectangleJ] = blocked_Brush; mapW[rectangleI, rectangleJ] = stepmap[rectangleI,rectangleJ]=-1; }
                else
                    if (brushes[rectangleI, rectangleJ] == blocked_Brush)
                { brushes[rectangleI, rectangleJ] = free_Brush; mapW[rectangleI, rectangleJ] = stepmap[rectangleI,rectangleJ]=0; }
            }
            pictureBox1.Invalidate();
        }

        private void button_generateBlocks_Click(object sender, EventArgs e)
        {   
            if (!int.TryParse(numericUpDown_width.Value.ToString(), out widthInRectangles) 
                || !int.TryParse(numericUpDown_height.Value.ToString(), out heightInRectangles)
                || !double.TryParse(numericUpDown_probability.Value.ToString(), out probability))
            {
                MessageBox.Show(this, @"Некоректний ввід!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            float rectangleWidth = (float)(pictureBox1.Width - 1) / widthInRectangles - 1,
                  rectangleHeight = (float)(pictureBox1.Height - 1) / heightInRectangles - 1;

            rectangles = new RectangleF[heightInRectangles, widthInRectangles];
            brushes  = new Brush[heightInRectangles, widthInRectangles];
            mapW = new double[heightInRectangles, widthInRectangles];
            stepmap = new int[heightInRectangles, widthInRectangles];

            Random random = new Random();

            for (int i = 0; i < heightInRectangles; i++)
                for (int j = 0; j < widthInRectangles; j++)
                {
                    // створити прямокутник 
                    rectangles[i,j] = new RectangleF(j * (rectangleWidth + 1) + 1,
                        i * (rectangleHeight + 1) + 1, // + 1 означає границю між фігурами в 1 піксель
                        rectangleWidth,
                        rectangleHeight);

                    // задати колір і позначити в map
                    if (random.NextDouble() <= probability)
                    {
                        brushes[i, j] = blocked_Brush; mapW[i, j] = stepmap[i, j] = -1;
                    }
                    else
                    {
                        brushes[i, j] = free_Brush; mapW[i, j] = stepmap[i, j] = 0;
                    }
                }
            pictureBox1.Invalidate(); 

            button_generateBlocks.Enabled = false;
            button_findPath.Enabled = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            // не будувати, якщо кнопка активна, бо це означає, що масиви ще не створили
            if (button_generateBlocks.Enabled == false)
            {
                Font font = new Font(this.Font.FontFamily,
                    Math.Min((float)pictureBox1.Width /widthInRectangles  * 0.6f, 
                    (float)pictureBox1.Height / heightInRectangles) * 0.4f);

                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;


                for (int i = 0; i < heightInRectangles; i++)
                    for (int j = 0; j < widthInRectangles; j++)
                    {
                        g.FillRectangle(brushes[i, j], rectangles[i, j]);
                        if (button_findPath.Enabled == false) // якщо шлях уже знайдено, тоді намалювати його
                        if (brushes[i, j] != blocked_Brush)
                            g.DrawString(stepmap[i, j].ToString(), font, Brushes.Black, rectangles[i, j], format);
                    }

                // лінія
                if (button_findPath.Enabled == false) // якщо шлях уже знайдено, тоді намалювати його
                {
                    if (stepmap[finishI, finishJ] == 0) return; // нема шляху
                    PointF[] lineP = new PointF[stepmap[finishI, finishJ] + 1];
                    float rectangleWidth = (float)(pictureBox1.Width - 1) / widthInRectangles - 1,
                      rectangleHeight = (float)(pictureBox1.Height - 1) / heightInRectangles - 1;
                    
                    for (int i = 0; i < stepmap[finishI, finishJ] + 1; i++)
                    {
                        lineP[i] = new PointF(line[i, 1] * (rectangleWidth + 1) + rectangleWidth / 2,
                                               line[i, 0] * (rectangleHeight + 1) + rectangleHeight / 2);
                    }
                    g.DrawLines(line_Pen, lineP);

                    // стрілка
                    float len = Math.Min(rectangleWidth / 2, rectangleHeight / 2) - 1;

                    if (line[0, 1] == line[1, 1] && line[0, 0] > line[1, 0])  // згори
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X - len, lineP[0].Y - len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X + len, lineP[0].Y - len);
                    }
                    if (line[0, 1] > line[1, 1] && line[0, 0] > line[1, 0])  // згори і зліва
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X, lineP[0].Y - len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X - len, lineP[0].Y);
                    }
                    if (line[0, 1] > line[1, 1] && line[0, 0] == line[1, 0])  // зліва
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X - len, lineP[0].Y - len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X - len, lineP[0].Y + len);
                    }
                    if (line[0, 1] > line[1, 1] && line[0, 0] < line[1, 0])  // знизу і зліва
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X - len, lineP[0].Y);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X, lineP[0].Y + len);
                    }
                    if (line[0, 1] == line[1, 1] && line[0, 0] < line[1, 0])  // знизу
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X - len, lineP[0].Y + len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X + len, lineP[0].Y + len);
                    }
                    if (line[0, 1] < line[1, 1] && line[0, 0] < line[1, 0])  // знизу і справа
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X, lineP[0].Y + len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X + len, lineP[0].Y);
                    }
                    if (line[0, 1] < line[1, 1] && line[0, 0] == line[1, 0])  // справа
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X + len, lineP[0].Y - len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X + len, lineP[0].Y + len);
                    }
                    if (line[0, 1] < line[1, 1] && line[0, 0] > line[1, 0])  // згори і справа
                    {
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X, lineP[0].Y - len);
                        g.DrawLine(line_Pen, lineP[0].X, lineP[0].Y, lineP[0].X + len, lineP[0].Y);
                    }
                }
            }
        }
       
        private void findpath(int i, int j, double stepW, int step)
        {
            if (step != 0 && i == startI && j == startJ)
                return; // якщо знову повертаємося на старт, то не повертатися

            stepmap[i, j] = step;
            mapW[i, j] = stepW;

            if (i == finishI && j == finishJ) return;

            // проти годинникової стрілки
            if (i > 0) // вгору
                if (mapW[i - 1, j] > stepW + 1 || mapW[i - 1, j] == 0) findpath(i - 1, j, stepW + 1, step + 1);

            if (i > 0 && j > 0) // вгору і вліво
                if (!(mapW[i, j - 1] == -1 && mapW[i - 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    if (mapW[i - 1, j - 1] > stepW + sqrtTwo || mapW[i - 1, j - 1] == 0) findpath(i - 1, j - 1, stepW + sqrtTwo, step + 1);

            if (j > 0) // вліво
                if (mapW[i, j - 1] > stepW + 1 || mapW[i, j - 1] == 0) findpath(i, j - 1, stepW + 1, step + 1);

            if (j > 0 && i < heightInRectangles - 1) // вліво і вниз
                if (!(mapW[i, j - 1] == -1 && mapW[i + 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    if (mapW[i + 1, j - 1] > stepW + sqrtTwo || mapW[i + 1, j - 1] == 0) findpath(i + 1, j - 1, stepW + sqrtTwo, step + 1);

            if (i < heightInRectangles - 1) // вниз
                if (mapW[i + 1, j] > stepW + 1 || mapW[i + 1, j] == 0) findpath(i + 1, j, stepW + 1, step + 1);

            if (i < heightInRectangles - 1 && j < widthInRectangles - 1) // вправо і вниз
                if (!(mapW[i, j + 1] == -1 && mapW[i + 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    if (mapW[i + 1, j + 1] > stepW + sqrtTwo || mapW[i + 1, j + 1] == 0) findpath(i + 1, j + 1, stepW + sqrtTwo, step + 1);

            if (j < widthInRectangles - 1) // вправо
                if (mapW[i, j + 1] > stepW + 1 || mapW[i, j + 1] == 0) findpath(i, j + 1, stepW + 1, step + 1);

            if (i > 0 && j < widthInRectangles - 1) // вправо і вгору
                if (!(mapW[i, j + 1] == -1 && mapW[i - 1, j] == -1)) // не "перестрибувати" через перешкоди 
                    if (mapW[i - 1, j + 1] > stepW + sqrtTwo || mapW[i - 1, j + 1] == 0) findpath(i - 1, j + 1, stepW + sqrtTwo, step + 1);
        }

        private void drawLine()
        {
            int steps = stepmap[finishI, finishJ];
            if (steps == 0) return;

            line = new int[steps + 1, 2];
            line[0, 0] = finishI; line[0, 1] = finishJ;
            int i = finishI, j = finishJ;

            int k = 1;

            while (k < steps)
            {
                // проти годинникової стрілки
                if (i > 0 && stepmap[i - 1, j] == stepmap[i, j] - 1 && brushes[i - 1, j] == partOfPath_Brush) 
                {
                    line[k, 0] = i - 1; line[k, 1] = j; i--;
                }
                else
                    if (i > 0 && j > 0 && stepmap[i - 1, j - 1] == stepmap[i, j] - 1 && brushes[i - 1, j - 1] == partOfPath_Brush)
                {
                    line[k, 0] = i - 1; line[k, 1] = j - 1; i--; j--;
                }
                else
                 if (j > 0 && stepmap[i, j - 1] == stepmap[i, j] - 1 && brushes[i, j - 1] == partOfPath_Brush)
                {
                    line[k, 0] = i; line[k, 1] = j - 1; j--;
                }
                else
                if (j > 0 && i < heightInRectangles - 1 && stepmap[i + 1, j - 1] == stepmap[i, j] - 1 && brushes[i + 1, j - 1] == partOfPath_Brush)
                {
                    line[k, 0] = i + 1; line[k, 1] = j - 1; i++; j--;
                }
                else
                if (i < heightInRectangles - 1 && stepmap[i + 1, j] == stepmap[i, j] - 1 && brushes[i + 1, j] == partOfPath_Brush)
                {
                    line[k, 0] = i + 1; line[k, 1] = j; i++;
                }
                else
                if (i < heightInRectangles - 1 && j < widthInRectangles - 1 && stepmap[i + 1, j + 1] == stepmap[i, j] - 1 && brushes[i + 1, j + 1] == partOfPath_Brush)
                {
                    line[k, 0] = i + 1; line[k, 1] = j + 1; i++; j++;
                }
                else
                if (j < widthInRectangles - 1 && stepmap[i, j + 1] == stepmap[i, j] - 1 && brushes[i, j + 1] == partOfPath_Brush)
                {
                    line[k, 0] = i; line[k, 1] = j + 1; j++;
                }
                else
                if (i > 0 && j < widthInRectangles - 1 && stepmap[i - 1, j + 1] == stepmap[i, j] - 1 && brushes[i - 1, j + 1] == partOfPath_Brush)
                {
                    line[k, 0] = i - 1; line[k, 1] = j + 1; i--; j++;
                }
                k++;
            }
            line[k, 0] = startI; line[k, 1] = startJ;
        }

    }
}
