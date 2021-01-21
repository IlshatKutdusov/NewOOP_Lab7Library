using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewOOP_Lab7Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int redcolor = 0, greencolor = 0, bluecolor = 0;

        private int i = -1, k = -1, p;

        private ArrayList<Figure> arraylist = new ArrayList<Figure>();
        private NodesList<Figure> nodeslist = new NodesList<Figure>();
        private int liststate = 0;

        private Circle circle;
        private Triangle triangle;
        private Rectangle rectangle;
        private Ellipse ellipse;
        private Parallelogram parallelogram;
        private Random randomint = new Random();

        private void UpDate()
        {
            pictureBox1.Image = null;
            if (liststate == 1)
            {
                for (int i = 0; i < arraylist.Count(); i++)
                {
                    arraylist[i].Show(pictureBox1);
                }
            }
            if (liststate == 2)
            {
                for (int i = 0; i < nodeslist.Count(); i++)
                {
                    nodeslist[i].Show(pictureBox1);
                }
            }
        }

        private void EnableFunc()
        {
            if (button2.Enabled == false)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }

        private void ListAddFigure(Figure figure)
        {
            if (liststate == 1)
                arraylist.Add(figure);
            else
                nodeslist.Add(figure);
        }

        private void ShowHide(int v)
        {
            if (liststate == 1)
            {
                for (int j = 0; j < arraylist.Count; j++)
                {
                    arraylist[j].Visibility();
                }
            }
            if (liststate == 2)
            {
                for (int j = 0; j < nodeslist.Count; j++)
                {
                    nodeslist[j].Visibility();
                }
            }
        }

        private void MoveFigure(int dx, int dy, PictureBox picBox)
        {
            if (liststate == 1)
            {
                for (int j = 0; j < arraylist.Count; j++)
                {
                    arraylist[j].MoveTo(dx, dy, picBox);
                }
            }
            if (liststate == 2)
            {
                for (int j = 0; j < nodeslist.Count; j++)
                {
                    nodeslist[j].MoveTo(dx, dy, picBox);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = randomint.Next(0, 5);
            switch (p)
            {
                case 0:
                    circle = new Circle();
                    circle.Show(pictureBox1);
                    ListAddFigure(circle);
                    break;
                case 1:
                    triangle = new Triangle();
                    triangle.Show(pictureBox1);
                    ListAddFigure(triangle);
                    break;
                case 2:
                    rectangle = new Rectangle();
                    rectangle.Show(pictureBox1);
                    ListAddFigure(rectangle);
                    break;
                case 3:
                    ellipse = new Ellipse();
                    ellipse.Show(pictureBox1);
                    ListAddFigure(ellipse);
                    break;
                case 4:
                    parallelogram = new Parallelogram();
                    parallelogram.Show(pictureBox1);
                    ListAddFigure(parallelogram);
                    break;
                default:
                    MessageBox.Show("Ошибка! Вне границ выбора фигур!");
                    break;
            }
            EnableFunc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowHide(1);
            UpDate();
            MoveFigure(Convert.ToInt16(numericUpDown1.Value), Convert.ToInt16(numericUpDown2.Value), pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowHide(2);
            UpDate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = true;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

            if (radioButton1.Checked == true)
                liststate = 1;
            else
                liststate = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;

            if (liststate == 1)
                arraylist.Clear();
            else
                nodeslist.Clear();
        }
    }
}
