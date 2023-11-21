using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Documents;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Schema;


//using System.CommandLine.dll;

namespace SeProject1
{
    

    internal class Parser
    {

        
        

    }


    public class textparser
    {
        
        Graphics draw;
        public Point point11;
        public Point point22;
        public string[] commands;
        public List<string> command = new List<string>();
        
        public void Drawingline(PointF pointx, PointF pointy)
        {

            
            
        }


        
        
        /* Savetolist runs through the text file and stores the output in a list which is converted to Ienumerable*/
        public void Savetolist()
        {
            
            
           
            int count = 0;
            string textFile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt";
           
            List<string> list = new List<string>();
            
            string[] commandsFile = File.ReadAllLines(textFile);
            
            Form1 homeClass = new Form1();
            foreach (string element in commandsFile)
            {
              
                foreach (string individual in element.Split(' '))
                {
                    command.Add(individual);
                    Console.WriteLine(individual);
                }
                
                


                
                
            }
            int size = command.Count;
            homeClass.ParseProgram(command, command);
           
        }
    }

}
