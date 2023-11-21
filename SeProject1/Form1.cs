using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;
using System.Drawing;
using System.Windows.Controls;
using System.IO;
using System.Windows.Shapes;
using static System.Windows.Forms.LinkLabel;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Management.Instrumentation;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Collections;

namespace SeProject1
{

    public partial class Form1 : Form
    {
        string textFile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt"; // Stores the file path that the commands are saved in
        Bitmap myBitmap = new Bitmap(650, 480); // creation of a bitmap to be stored anywhere in Form1.cs



        Pen myPen = new Pen(Color.Black, 5);
        Boolean mouseDown = false;
        //Parser myParser = new Parser();
        public List<string> finalCommands = new List<string>(); // Will hold a list of only the correct commands and coordinates that will be executed


        runCommands drawing;  //Creates an object of the runCommands class



        public Form1()
        {
            InitializeComponent();


            drawing = new runCommands(Graphics.FromImage(myBitmap));// saves Graphics.FromImage(myBitmap) into Graphics g. This is so Graphics will be updated with everything that is drawn onto myBitmap



        }


        /* Changes the pen color to red*/
        private void button1_Click(object sender, EventArgs e)
        {

            myPen = new Pen(Color.Red, 5);

        }
        /* Changes the pen colour to blue*/
        private void button2_Click(object sender, EventArgs e)
        {

            myPen = new Pen(Color.Blue, 5);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            StreamWriter stream = new StreamWriter(textFile);
            stream.Write(textBox1.Text); //Writes all the commands entered in the textbox to commands.txt
            stream.Close();

            textparser txt = new textparser();

            txt.Savetolist();
            for(int i = 0; i < finalCommands.Count; i++)
            {
                Console.WriteLine(finalCommands[i] +" is this the final answer?");
                if (finalCommands[i] == "drawto")
                {
                    drawing.Draw(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                else if (finalCommands[i] == "moveto")
                {
                    Cursor.Position = new Point(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                Refresh();
            }
            



        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            Pen pen = new Pen(Color.Black);
            Graphics pic = e.Graphics;
            ////Graphics graph = Graphics.FromImage(myBitmap);
            pic.DrawImageUnscaled(myBitmap, 0, 0);
            //pic.DrawLine(pen, 0, 0, 100, 300);
            //pic.DrawImage(myBitmap, 650, 480);
            //graph.DrawLine(pen, 0, 0, 100, 300);

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {


        }



        public void ParseProgram(IEnumerable<string> enumerator, List<string> command)
        {

            Console.WriteLine("Enter the parser");
            List<string> coor = new List<string>();
            command.GetEnumerator();
            //List<string>.Enumerator enumerator1 = (List<string>.Enumerator)enumerator.GetEnumerator();
            int a = 0;
            IEnumerator enumerator1 = enumerator.GetEnumerator();
            //int i = 0;
            //while (enumerator1.MoveNext())
            //{

            //    switch (enumerator1.Current)
            //    {
            //        case "moveto":
            //            finalCommands.Add((string)enumerator1.Current);

            //            Console.WriteLine((string)enumerator1.Current + " This is the current");
            //            finalCommands.Add(coor[i + 1]);
            //            finalCommands.Add(coor[i + 2]);
            //            Cursor.Position = new Point(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));


            //            break;
            //        case "drawto":

            //            finalCommands.Add((string)enumerator1.Current);
            //            finalCommands.Add(coor[i + 1]);
            //            finalCommands.Add(coor[i + 2]);

            //            drawing.Draw(int.Parse(coor[i + 1]), int.Parse(coor[i + 2]));
            //            Console.WriteLine("Should have drawn now");
            //            Refresh();
            //            break;


            //    }
            //}
            for (int i = 0; i < command.Count(); i++)
            {

                //Console.WriteLine((string)enumerator1.Current);
                switch (command[i])
                {
                    case "moveto":
                        //finalCommands.Add((string)enumerator1.Current);
                        finalCommands.Add(command[i]);
                        //Console.WriteLine((string)enumerator1.Current + " This is the current");
                        finalCommands.Add(command[i + 1]);
                        finalCommands.Add(command[i + 2]);
                        Cursor.Position = new Point(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));


                        break;
                    case "drawto":

                        finalCommands.Add(command[i]);
                        finalCommands.Add(command[i + 1]);
                        finalCommands.Add(command[i + 2]);

                        //drawing.Draw(int.Parse(command[i + 1]), int.Parse(command[i + 2]));
                        Console.WriteLine("Should have drawn now");
                        //pictureBox1.Refresh();
                        Console.WriteLine("Should have drawn now");
                        //pictureBox1.Image = myBitmap;

                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;

                }
            }
            /*pictureBox1.Invalidate();*/
            //run();
            //pictureBox1.Refresh();
        }

        public void run()
        {
            pictureBox1.Image = myBitmap;

        }

















        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void button2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void textCommand_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Show();
            if(e.KeyCode == Keys.Enter)
            {
                string paintCommand = textCommand.Text.Trim().ToLower();
                String[] paintCommandData = paintCommand.Split(' ');
                if (paintCommandData[0].ToLower() == "drawto")
                {
                    drawing.Draw(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                }
                else if (paintCommandData[0].ToLower() == "moveto")
                {
                    Cursor.Position = new Point(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                }
                textCommand.Text = "";
                Refresh();
            }

        }
    }
    
}
