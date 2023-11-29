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
            Form1 form = new Form1();
            textparser parser = new textparser();
            parser.Savetolist();
            foreach(string individual in parser.commandsFile)
            {
                Assert.AreEqual(parser.command, individual);
            }
          
            
            
            
        }

        public void Testing()
        {
            
        }
    }
}