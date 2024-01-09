using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using SeProject1;

namespace SETest1
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

            List<string> individual = new List<string>() { "drawto", "0", "100", "triangle", "0", "100" };

            //foreach(string b in File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\TestFile1.txt")) 
            //{

            //    individual.Add(b);

            //}

            //foreach (string individual in parser.commandsFile)
            CollectionAssert.AreEquivalent(p.command, individual);



        }


        [TestMethod]
        public void WriteToFileTest()
        {
            Form1 f = new Form1();
            string input = "drawto 0 400";
            var expectedFile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt";
            var actualFile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\TestFile1.txt";
            
            StreamWriter write = new StreamWriter(actualFile);
            write.Write(input);
            write.Close();
            f.WriteToFile(input);
            var hashExpectedFile = File.ReadAllLines(expectedFile);
            var hashActualFile = File.ReadAllLines(actualFile);
            
            
            
            Assert.AreEqual(hashExpectedFile, hashActualFile);
            
            
        }

        public void finalCommandsList()
        {
            List<string> commands = new List<string>(){"drawto", "0", "100"};
            Form1 f = new Form1();
            f.ParseProgram(commands);
            Assert.AreEqual(commands, f.finalCommands);
        }
    }
}
