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
using System.Windows.Controls;
using System.IO;
using System.Windows.Shapes;
//using static System.Windows.Forms.LinkLabel;
using System.Security.Cryptography;
//using static System.Net.Mime.MediaTypeNames;
using System.Management.Instrumentation;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Collections;
using System.Windows.Documents;

namespace SeProject1
{
    
    public partial class Form1 : Form
    {
        /// <summary>
        /// Store File path of the text file commands.txt . This is where the commands entered by the user will be saved.
        /// A bitmap is created to draw on.
        /// a list of the correct commands is created.
        /// An object of the runCommands class is created
        /// </summary>
        string textFile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt"; // Stores the file path that the commands are saved in
        Bitmap myBitmap = new Bitmap(650, 480); // creation of a bitmap to be stored anywhere in Form1.cs
        
        Boolean mouseDown = false;
        public List<string> finalCommands = new List<string>();// Will hold a list of only the correct commands and coordinates that will be executed


        runCommands drawing;  //Creates an object of the runCommands class

        /// <summary>
        /// data is entered into runcommands
        /// </summary>
        /// <parameter name="g">Allows the bitmap to be drawn on in runCommands</parameter>
        public Form1()
        {
            InitializeComponent();


            drawing = new runCommands(Graphics.FromImage(myBitmap));// saves Graphics.FromImage(myBitmap) into Graphics g. This is so Graphics will be updated with everything that is drawn onto myBitmap

        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        /// <summary>
        /// When the button on the form is pressed the text from the multi-line
        /// text box is entered into textFile and then Savetolist is ran,
        /// then ParseProgram is ran, then run is ran.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            
            
            WriteToFile(textBox1.Text);// save the data to a text file
            textparser txt = new textparser();//create object of textparser class which is inside Parser.cs

            txt.Savetolist(File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt"));//save the commands from the file into a list called command
            ParseProgram(txt.command);// Look through the saved commands and enter only the needed commands into a second list called finalCommands

            run();//loop through finalCommands and call the methods to run only the needed commands
            


        }

        public void WriteToFile(string textForFile)
        {
            
            Console.WriteLine(textForFile);
            string[] textFileData = textForFile.Split(' ');
            
            StreamWriter stream = new StreamWriter(textFile);
            for(int i = 0;i < textFileData.Length; i++)
            {
                stream.Write(textFileData[i]);
            }
            
            stream.Close();

        }
        /// <summary>
        /// The for loop runs through the list containing only the necessary commands. If an element of
        /// finalCommands == drawto then the draw method is ran, if moveto is the element then the cursor is moved.
        /// Refresh makes the form redraw itself to include the update version of the bitmap which is displayed on a picturebox.
        /// </summary>
        public void run()
        {
            for (int i = 0; i < finalCommands.Count; i++)
            {

                if (finalCommands[i] == "drawto")
                {
                    drawing.Draw(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                else if (finalCommands[i] == "moveto")
                {
                    drawing.move(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                else if (finalCommands[i] == "rectangle")
                {
                    drawing.rectangle(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                else if (finalCommands[i] == "circle")
                {
                    drawing.circle(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                else if (finalCommands[i] == "triangle")
                {
                    drawing.triangle(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                }
                else if (finalCommands[i] == "pen")
                {
                    drawing.setPenColour(Color.FromName(finalCommands[i + 1]));
                }
                else if (finalCommands[i] == "fill")
                {
                    drawing.colorFill(finalCommands[i + 1], finalCommands[i + 2]);
                }
                else if (finalCommands[i] == "clear")
                {
                    drawing.clear();
                }



            }
            Refresh();
            textBox1.Text = "";
            File.WriteAllText(textFile, String.Empty);
        }
        private void canvas_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// PictureBox1_Paint draws the bitmap onto the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            Pen pen = new Pen(Color.Black);
            Graphics pic = e.Graphics;
           
            pic.DrawImageUnscaled(myBitmap, 0, 0);
        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {


        }


        /// <summary>
        /// ParseProgram loops through the list command and only enters the important elements into finalCommands
        /// </summary>
        /// <param name="command"></param>
        public void ParseProgram(List<string> command)
        {

            bool error = false;
            for (int i = 0; i < command.Count(); i = i + 0)
            {
                if(error == false)
                {
                    try
                    {
                        if (command[i] != "clear")
                        {
                            int param1 = Convert.ToInt32(command[i + 1]);
                            int param2 = Convert.ToInt32(command[i + 2]);
                        }
                        

                        switch (command[i])
                        {
                            
                            case "moveto":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                               
                               
                                i += 3;

                                break;
                            case "drawto":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                
                                

                                i += 3;

                                break;
                            case "rectangle":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);

                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);

                                i += 3;

                                break;
                            case "circle":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                i += 3;

                                break;
                            case "triangle":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                i += 3;

                                break;
                            case "pen":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                i += 2;

                                break;
                            case "fill":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                i += 3;

                                break;
                            case "clear":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                i += 1;
                                break;
                           
                        }
                    }
                    catch(Exception e)
                    {
                        error = true;
                        Console.WriteLine("Input command or parameter was incorrect." + e.ToString());
                    }
                }
                else
                {
                    
                    break;
                }
                
            }

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
        /// <summary>
        /// when the cursor is in the single line command line and the enter key is presses then 
        /// everything inside the if statement is run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCommand_KeyDown(object sender, KeyEventArgs e)
        {
            textparser txt = new textparser();
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
                    //Cursor.Position = new Point(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                    drawing.move(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                }
                else if (paintCommandData[0].ToLower() == "run")
                {
                    StreamWriter stream = new StreamWriter(textFile);
                    stream.Write(textBox1.Text); //Writes all the commands entered in the textbox to commands.txt
                    stream.Close();

                    
                    txt.Savetolist(File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt"));
                    
                    ParseProgram(txt.command);
                    run();
                }
                else if (paintCommandData[0].ToLower() == "rectangle")
                {
                    drawing.rectangle(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                }
                else if (paintCommandData[0].ToLower() == "circle")
                {
                    drawing.circle(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                }
                else if (paintCommandData[0].ToLower() == "triangle")
                {
                    drawing.triangle(int.Parse(paintCommandData[1]), int.Parse(paintCommandData[2]));
                }
                else if (paintCommandData[0].ToLower() == "pen")
                {
                  drawing.setPenColour(Color.FromName(paintCommandData[1]));
                }
                else if (paintCommandData[0].ToLower() == "clear")
                {
                    drawing.clear();
                }
                


                textCommand.Text = "";
                Refresh();
            }

        }
    }
    
}
