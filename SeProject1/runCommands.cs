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
    
    /// <summary>
    /// runCommands class stores the functionality for the commands
    /// </summary>
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
        /// <summary>
        /// Fills the shapes with colours
        /// </summary>
        /// <param name="brushColor"> brushColor command saves what colour the user wants to enter</param>
        /// <param name="onOff">saves whether colorFill is on or off. If it is in it will turn off and vice versa</param>
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
        /// <summary>
        /// allows the user to set what colour the pen will be
        /// </summary>
        /// <param name="color">Stores what colour the user wants the pen to be</param>
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
        /// <summary>
        /// functionality for drawing a rectangle. Takes either the fill colour or line colour and draws the 
        /// rectangle using the start coordinates and the user specified coordinates which specifies the length and width of the rectangle
        /// </summary>
        /// <param name="toX">how far along the x-axis</param>
        /// <param name="toY">how far along the y-axis</param>
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
        /// <summary>
        /// draws an ellipse based on whether the user wants the shape to be filled or not.
        /// X and Y are needed because the Ellipse is drawn based of off a rectangle. Therefore X
        /// and Y are needed so the user can specify the size of the Ellipse
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
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
        /// <summary>
        /// Custom drawn triangle drawn by using straight lines. Working from the starting position of posX and posY.
        /// OriginalPosX and OriginalPosY store the coordinates of where the shape will start from.
        /// The hypotenuse is drawn by adding the width to posX.
        /// To get the next point the height is added to the Y-axis and the X-axis is halved
        /// Then next line is a return to posX and posY.
        /// 
        /// </summary>
        /// <param name="width">how long will the X-axis be</param>
        /// <param name="height">how long will the Y-axis be</param>
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
        /// <summary>
        /// delete all the drawing from the canvas
        /// </summary>
        public void clear()
        {
            g.Clear(Color.FromName("white"));
        }
        /// <summary>
        /// Move where the shapes will start drawing from
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void move(int x, int y)
        {
            posX = x;
            posY = y;
        }
    }
   
    
    
    

   
}