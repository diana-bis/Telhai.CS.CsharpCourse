using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse._05_Abstraction.ClassWorkDrawing
{
    internal class Rectangle : Drawing
    {
        
        public double Height { get; set; }
        public double Width { get; set; }
        public Rectangle() 
        {
            Height = 5.3;
            Width = 3.4;
        }

        public override double Area()
        {
            return Height * Width;
        }

        public override string ToString()
        {
            return $"Rectangle: {Id} with area {Area()}";
        }


    }
}
