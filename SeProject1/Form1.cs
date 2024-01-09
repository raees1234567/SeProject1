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
using System.Data.Common;

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
        public Dictionary<string, string> variable = new Dictionary<string, string>();
        string result;
        public List<KeyValuePair<string, string>> operators = new List<KeyValuePair<string, string>>();
        public List<string> drawCommands = new List<string>();
        public Dictionary<string, List<string>> methodCommands = new Dictionary<string, List<string>>();
        runCommands drawing;  //Creates an object of the runCommands class
        public int[][] array1 = new int[5][];
        

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

            textparser txt = new textparser();// create object of textparser class which is inside Parser.cs
            txt.Savetolist(File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt"));//save the commands from the file into a list called command

            ParseProgram(txt.command);// Look through the saved commands and enter only the needed commands into a second list called finalCommands

            run();// loop through finalCommands and call the methods to run only the needed commands



        }

        public void WriteToFile(string textForFile)
        {

            StreamWriter stream = new StreamWriter(textFile);

            stream.Write(textForFile);

            stream.Close();

        }
        /// <summary>
        /// The for loop runs through the list containing only the necessary commands. If an element of
        /// finalCommands == drawto then the draw method is ran, if moveto is the element then the cursor is moved.
        /// Refresh makes the form redraw itself to include the update version of the bitmap which is displayed on a picturebox.
        /// </summary>
        public void run()
        {
            string index1;
            string index2;
            int count = 0;
            for (int i = 0; i < finalCommands.Count; i++)
            {
                
                if (finalCommands[i] == "drawto")
                {


                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        if (variable.ContainsKey(finalCommands[i + 2]) == true)
                        {
                            index2 = variable[finalCommands[i + 2]];
                            
                            drawing.Draw(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {  
                            drawing.Draw(int.Parse(index1), int.Parse(finalCommands[i + 2]));
                        }
                        
                    }
                    else
                    {
                        drawing.Draw(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                    }

                    
                    
                }
                else if (finalCommands[i] == "moveto")
                {
                    

                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        if (variable.ContainsKey(finalCommands[i + 2]) == true)
                        {
                            index2 = variable[finalCommands[i + 2]];

                            drawing.move(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.move(int.Parse(index1), int.Parse(finalCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.move(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                    }
                    
                }
                else if (finalCommands[i] == "rectangle")
                {
                    

                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        if (variable.ContainsKey(finalCommands[i + 2]) == true)
                        {
                            index2 = variable[finalCommands[i + 2]];

                            drawing.rectangle(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.rectangle(int.Parse(index1), int.Parse(finalCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.rectangle(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                    }
                    
                }
                else if (finalCommands[i] == "circle")
                {

                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        if (variable.ContainsKey(finalCommands[i + 2]) == true)
                        {
                            index2 = variable[finalCommands[i + 2]];

                            drawing.circle(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.circle(int.Parse(index1), int.Parse(finalCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.circle(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                    }
                    
                }
                else if (finalCommands[i] == "triangle")
                {
                    

                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        if (variable.ContainsKey(finalCommands[i + 2]) == true)
                        {
                            index2 = variable[finalCommands[i + 2]];

                            drawing.triangle(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.triangle(int.Parse(index1), int.Parse(finalCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.triangle(int.Parse(finalCommands[i + 1]), int.Parse(finalCommands[i + 2]));
                    }
                    
                }
                else if (finalCommands[i] == "pen")
                {
                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        drawing.setPenColour(Color.FromName(finalCommands[i + 1]));
                    }
                    else
                    {
                        drawing.setPenColour(Color.FromName(finalCommands[i + 1]));
                    }
                    
                }
                else if (finalCommands[i] == "fill")
                {
                    

                    if (variable.ContainsKey(finalCommands[i + 1]) == true)
                    {
                        index1 = variable[finalCommands[i + 1]];
                        if (variable.ContainsKey(finalCommands[i + 2]) == true)
                        {
                            index2 = variable[finalCommands[i + 2]];

                            drawing.colorFill(index1, index2);
                        }
                        else
                        {
                            drawing.colorFill(index1, finalCommands[i + 2]);
                        }

                    }
                    else
                    {
                        drawing.colorFill(finalCommands[i + 1], finalCommands[i + 2]);
                    }
                    
                }
                else if (finalCommands[i] == "startloop")
                {
                    int index = int.Parse(finalCommands[i + 3]);
                    string operation = finalCommands[i + 5];
                    int conditionOperator = int.Parse(finalCommands[i + 6]);
                    string changeValue = finalCommands[i + 8]; // operator for increment or decrement
                    int value = int.Parse(finalCommands[i + 9]); // Value which will be incremented or decremented by
                    int indexStartPos = finalCommands.IndexOf("{");
                    int indexEndPos = finalCommands.IndexOf("}");
                    operators.Insert(0, new KeyValuePair<string, string>("less_than", "<"));
                    operators.Insert(1, new KeyValuePair<string, string>("greater_than", ">"));
                    operators.Insert(2, new KeyValuePair<string, string>("less_than_equal_to", "<="));
                    operators.Insert(3, new KeyValuePair<string, string>("greater_than_equal_to", ">="));
                    operators.Insert(4, new KeyValuePair<string, string>("plus", "+"));
                    operators.Insert(5, new KeyValuePair<string, string>("minus", "-"));
                    operators.Insert(6, new KeyValuePair<string, string>("divide", "/"));
                    operators.Insert(7, new KeyValuePair<string, string>("multiply", "*"));
                    loopThroughCommands(index, operation, conditionOperator, changeValue, value, indexStartPos, indexEndPos);
                    
                    


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

        public void commandFilter(List<string> runList, int indexStartPos, int indexEndPos)
        {
            for(int i = 0;i < drawCommands.Count; i++)
            {
                string index1;
                string index2;
                int count = 0;
                if (drawCommands[i] == "drawto")
                {



                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        if (variable.ContainsKey(drawCommands[i + 2]) == true)
                        {
                            index2 = variable[drawCommands[i + 2]];

                            drawing.Draw(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.Draw(int.Parse(index1), int.Parse(drawCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.Draw(int.Parse(drawCommands[i + 1]), int.Parse(drawCommands[i + 2]));
                    }



                }
                else if (drawCommands[i] == "moveto")
                {


                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        if (variable.ContainsKey(drawCommands[i + 2]) == true)
                        {
                            index2 = variable[drawCommands[i + 2]];

                            drawing.move(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.move(int.Parse(index1), int.Parse(drawCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.move(int.Parse(drawCommands[i + 1]), int.Parse(drawCommands[i + 2]));
                    }

                }
                else if (drawCommands[i] == "rectangle")
                {


                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        if (variable.ContainsKey(drawCommands[i + 2]) == true)
                        {
                            index2 = variable[drawCommands[i + 2]];

                            drawing.rectangle(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.rectangle(int.Parse(index1), int.Parse(drawCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.rectangle(int.Parse(drawCommands[i + 1]), int.Parse(drawCommands[i + 2]));
                    }

                }
                else if (drawCommands[i] == "circle")
                {

                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        if (variable.ContainsKey(drawCommands[i + 2]) == true)
                        {
                            index2 = variable[drawCommands[i + 2]];

                            drawing.circle(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.circle(int.Parse(index1), int.Parse(drawCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.circle(int.Parse(drawCommands[i + 1]), int.Parse(drawCommands[i + 2]));
                    }

                }
                else if (drawCommands[i] == "triangle")
                {


                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        if (variable.ContainsKey(drawCommands[i + 2]) == true)
                        {
                            index2 = variable[drawCommands[i + 2]];

                            drawing.triangle(int.Parse(index1), int.Parse(index2));
                        }
                        else
                        {
                            drawing.triangle(int.Parse(index1), int.Parse(drawCommands[i + 2]));
                        }

                    }
                    else
                    {
                        drawing.triangle(int.Parse(drawCommands[i + 1]), int.Parse(drawCommands[i + 2]));
                    }

                }
                else if (drawCommands[i] == "pen")
                {
                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        drawing.setPenColour(Color.FromName(drawCommands[i + 1]));
                    }
                    else
                    {
                        drawing.setPenColour(Color.FromName(drawCommands[i + 1]));
                    }

                }
                else if (finalCommands[i] == "fill")
                {


                    if (variable.ContainsKey(drawCommands[i + 1]) == true)
                    {
                        index1 = variable[drawCommands[i + 1]];
                        if (variable.ContainsKey(drawCommands[i + 2]) == true)
                        {
                            index2 = variable[drawCommands[i + 2]];

                            drawing.colorFill(index1, index2);
                        }
                        else
                        {
                            drawing.colorFill(index1, drawCommands[i + 2]);
                        }

                    }
                    else
                    {
                        drawing.colorFill(drawCommands[i + 1], drawCommands[i + 2]);
                    }

                }
                else if (drawCommands[i] == "startloop")
                {
                    //int index = int.Parse(drawCommands[i + 3]);
                    //string operation = drawCommands[i + 5];
                    //int conditionOperator = int.Parse(drawCommands[i + 6]);
                    //string changeValue = drawCommands[i + 8]; // operator for increment or decrement
                    //int value = int.Parse(drawCommands[i + 9]); // Value which will be incremented or decremented by

                    operators.Insert(0, new KeyValuePair<string, string>("less_than", "<"));
                    operators.Insert(1, new KeyValuePair<string, string>("greater_than", ">"));
                    operators.Insert(2, new KeyValuePair<string, string>("less_than_equal_to", "<="));
                    operators.Insert(3, new KeyValuePair<string, string>("greater_than_equal_to", ">="));
                    operators.Insert(4, new KeyValuePair<string, string>("plus", "+"));
                    operators.Insert(5, new KeyValuePair<string, string>("minus", "-"));
                    operators.Insert(6, new KeyValuePair<string, string>("divide", "/"));
                    operators.Insert(7, new KeyValuePair<string, string>("multiply", "*"));
                    //loopThroughCommands(index, operation, conditionOperator, changeValue, value, indexStartPos, indexEndPos);




                }
                else if (drawCommands[i] == "clear")
                {
                    drawing.clear();
                }
            }

            Refresh();
            textBox1.Text = "";
            File.WriteAllText(textFile, String.Empty);

        }

        public void loopThroughCommands(int index, string operation, int conditionOperator, string changeValue, int value, int indexStartPos, int indexEndPos)
        {
            string less = "<";
            string plus = "+";
            for (int i = indexStartPos; i < indexEndPos; i++)
            {
                drawCommands.Add(finalCommands[i]);
            }
            if(operation == "<" && changeValue == "+")
            {
                for (int start = index; start < conditionOperator; start = start + value)
                {
                    commandFilter(drawCommands, indexStartPos, indexEndPos);
                }

            }
            else if(operation == ">" && changeValue == "-")
            {
                for (int start = index; start > conditionOperator; start = start - value)
                {
                    commandFilter(drawCommands, indexStartPos, indexEndPos);
                }
            }
            else if(operation == "<=" && changeValue == "*")
            {
                for (int start = index; start <= conditionOperator; start = start * value)
                {
                    commandFilter(drawCommands, indexStartPos, indexEndPos);
                }
            }
            //switch (operation, changeValue)
            //{
                
            //    case operation == less && changeValue == plus:
            //        for (int start = index; start < conditionOperator; start = start + value)
            //        {
            //            commandFilter(drawCommands, indexStartPos, indexEndPos);
            //        }
            //        break;
            //    case "<" == :
            //        break;
            //}
            

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
            int varCount = 0;
            for (int i = 0; i < command.Count(); i = i + 1)
            {
                if (error == false)
                {
                    try
                    {
                        Console.WriteLine("This is the current command: " + command[i]);
                        //if (command[i] != "clear" && command[i] != "=")
                        //{
                            //int param1 = Convert.ToInt32(command[i + 1]);
                            //int param2 = Convert.ToInt32(command[i + 2]);
                        //}
                        



                        switch (command[i])
                        {

                            case "moveto":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);


                                i += 2;

                                break;
                            case "drawto":
                                Console.WriteLine("Command Valid");
                                
                                finalCommands.Add(command[i]);

                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);



                                i += 2;

                                break;
                            case "rectangle":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);

                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);

                                i += 2;

                                break;
                            case "circle":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                i += 2;

                                break;
                            case "triangle":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                i += 2;

                                break;
                            case "pen":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                i += 1;

                                break;
                            case "fill":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                finalCommands.Add(command[i + 2]);
                                i += 2;
                                break;

                            case "=":
                                Console.WriteLine("Command Valid");
                                Console.WriteLine(command[i - 1]);
                                finalCommands.Add(command[i - 1]);
                                finalCommands.Add(command[i + 1]);
                                //finalCommands.Add(command[i + 2]);
                                variable.Add(command[i - 1] , command[i + 1]);
                                //variable.Add(command[i + 1], varCount + 1);
                                varCount += 1;
                                
                                
                                
                                i += 1;
                                break;

                            case "startloop":
                                Console.WriteLine("Command valid");
                                finalCommands.Add(command[i]);
                                finalCommands.Add(command[i + 1]);
                                for (int b = 2; b <= command.IndexOf("}"); b++)
                                {
                                    finalCommands.Add(command[i + b]);
                                }
                                i += command.IndexOf("}") - 1;
                                

                                break;
                            case "method":
                                methodCommands.Add(command[i], new List<string> { command[i + 1]});
                                if (command[i + 2] == "(")
                                {
                                    for(int c = 0; i < command.IndexOf(")");c ++)
                                    { 
                                        methodCommands.Add(command[i], new List<string> { command[i + c] });
                                    }
                                }
                                break;
                            case "clear":
                                Console.WriteLine("Command Valid");
                                finalCommands.Add(command[i]);
                                
                                break;
                                                        



                        }
                    }
                    catch (Exception e)
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






        //public enum Forloop
        //{
        //    lessThan = '<',
        //    greaterThan = '>',
        //    lessEqual = <,


        //}
        




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
