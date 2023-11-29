using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeProject1
{
    
    
    internal class runCommands
    {
        Graphics g;
        Pen p;
        int posX, posY;
        
        public runCommands(Graphics g) // constructor to allow me to draw on the same myBitmap from Form1.cs
        {
            this.g = g;
            posX = 0;
            posY = 0;
            p = new Pen(Color.Black, 5);
            
        }
        public void Draw(int toX, int toY)
        {
            
            
            g.DrawLine(p, posX, posY, toX, toY);// Draws a line onto myBitmap. toX and toY are the start and end position of the line and posX and posY are the current coordinates of the mouse
            
            posX = toX;
            posY = toY;
            
        }
    }
   
    
    
    

   
}