﻿using System;
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



namespace SeProject1
{
    
    internal class Parser
    {

    }

    
    public class textparser
    {
        
        public List<string> command = new List<string>();
        //public string[] commandsFile;
  
        
        /// <summary>
        /// Savetolist runs through the text file and stores the output in a list called command
        /// </summary>
        public void Savetolist(string[] commandsFile)
        {

            string textFile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt";

            //commandsFile = File.ReadAllLines(textFile);

            Form1 homeClass = new Form1();
            foreach (string element in commandsFile)
            {
              
                foreach (string individual in element.Split(' '))
                {
                    command.Add(individual);
                    
                }
                
            }
            
        }
    }

}
