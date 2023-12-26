global using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeProject1;


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
            
            textparser parser = new textparser();
            string textfile = "C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\TestFile1.txt";
            parser.Savetolist(File.ReadAllLines(textfile));
           
            List<string> individual = new List<string>() { "drawto", "0", "100", "triangle", "0", "100"};

            //foreach(string b in File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\TestFile1.txt")) 
            //{
               
            //    individual.Add(b);
                
            //}

            //foreach (string individual in parser.commandsFile)
            Assert.AreEqual(parser.command, individual);
            
            
            
        }

        public void Testing()
        {
            Form1 form = new Form1();
            
        }
    }
}