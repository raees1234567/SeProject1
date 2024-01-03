global using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeProject1;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace SeProject1Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        //This test is to make sure the list called command in the parser class has the correct values
        public void correctList()
        {

            //Arrange
            
            textparser p = new textparser();
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.Combine(directory, "TestFile1");
            p.Savetolist(File.ReadAllLines(path));
           
            List<string> individual = new List<string>() { "drawto", "0", "100", "triangle", "0", "100"};

            //foreach(string b in File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\TestFile1.txt")) 
            //{
               
            //    individual.Add(b);
                
            //}

            //foreach (string individual in parser.commandsFile)
            CollectionAssert.AreEquivalent(p.command, individual);
            
            
            
        }

        public void WriteToFileTest()
        {
            
            Form1 f = new Form1();
            string input = "drawto 0 400";
            string fileText = "drawto 0 400";
            f.WriteToFile(input);
            Assert.AreEqual(input, );
        }
    }
}