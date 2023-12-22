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
           
            parser.Savetolist(File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt"));
           
            List<string> individual = new List<string>();
            foreach(string b in File.ReadAllLines("C:\\Users\\raees\\source\\repos\\SeProject1\\SeProject1\\commands.txt")) 
            {
               
                individual.Add(b);
                
            }

            //foreach (string individual in parser.commandsFile)
            Assert.AreEqual(parser.command, individual);
            
            
            
        }

        public void Testing()
        {
            
        }
    }
}