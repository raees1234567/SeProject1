using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.VisualStyles;

namespace SeProject1
{
    
    
    class runCommands
    {
        Graphics g;
        Pen p;
        int posX, posY;
        bool fill = false;
        SolidBrush brushFill;
        /// <summary>
        /// This constructor saves the bitmap into a variable called g which can be used in the class to draw 
        /// onto the bitmap. Also a pen color is created and the x and y position is pre-set to 0.
        /// </summary>
        /// <param name="g">Save the bitmap so it can be used in this class</param>
        public runCommands(Graphics g) // constructor to allow me to draw on the same myBitmap from Form1.cs
        {
            this.g = g;
            posX = 0;
            posY = 0;
            p = new Pen(Color.Black, 5);
            
        }
        public void colorFill(string brushColor, string onOff)
        {
            brushFill = new SolidBrush(Color.FromName(brushColor));
            
            
            if (onOff.ToLower() ==  "on")
            {
                fill = true;
            }
            else if(onOff.ToLower() == "off")
            {
                fill = false;
            }
        }

        public void setPenColour(Color color)
        {
            p = new Pen(color, 5);
        }
        /// <summary>
        /// A method that can be used to draw a line onto the bitmap
        /// and then update the position of the cursor to where it should be
        /// </summary>
        /// <param name="toX">X coordinate of where the line will end</param>
        /// <param name="toY">Y coordinate of where the line will end</param>
        public void Draw(int toX, int toY)
        {
           
            
            g.DrawLine(p, posX, posY, toX, toY);// Draws a line onto myBitmap. toX and toY are the start and end position of the line and posX and posY are the current coordinates of the mouse
            
            posX = toX;
            posY = toY;
            
        }

        public void rectangle(int toX, int toY)
        {
            
            if (fill == true)
            {
                g.FillRectangle(brushFill, posX, posY, toX, toY);
                posX = toX;
                posY = toY;
            }
            else if(fill == false)
            {
                g.DrawRectangle(p, posX, posY, toX, toY);

                posX = toX;
                posY = toY;
            }
            
        }

        public void circle(int toX, int toY)
        {
            if(fill == true)
            {
                g.FillEllipse(brushFill, posX, posY, toX, toY);

                posX = toX;
                posY = toY;
            }
            else if(fill == false)
            {
                g.DrawEllipse(p, posX, posY, toX, toY);

                posX = toX;
                posY = toY;
            }
            
        }

        public void triangle(int width, int height)
        {
            int OriginalPosX = posX;
            int OriginalPosY = posY;
            g.DrawLine(p, posX, posY, posX + width, posY);
            posX = width;
            
            g.DrawLine(p, posX, posY, posX - (width / 2), posY + height);
            posX = posX - (width / 2);
            posY = posY + height;
            g.DrawLine(p, posX, posY, posX - (width / 2), posY - height);
            posX = OriginalPosX;
            posY = OriginalPosY;

        }

        public void clear()
        {
            g.Clear(Color.FromName("white"));
        }

        public void move(int x, int y)
        {
            posX = x;
            posY = y;
        }
    }
   
    
    
    

   
}