using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse._05_Abstraction.ClassWorkDrawing
{
    internal class Drawing
    {
        private static int counter = 1;

        public int Id { get; private set; }

        public Drawing() 
        {
            Id = counter++;
        }

        public virtual double Area()
        {
            return 0;
        }

    }
}
