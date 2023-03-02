using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Drawer
{
    class Square
    {
        public int width;
        public int height;
        public Tuple<int, int> originPoint;

        public Square()
        {
            width = 0;
            height = 0;
            originPoint = Tuple.Create(0, 0);
        }
    }
    class Circle
    {
        int radius = 0;
        public Tuple<int, int> originPoint;
        public Circle()
        {
            radius = 0;
            originPoint = Tuple.Create(0, 0);
        }

    }
    class Triangle
    {
        public Tuple<int, int> pointTop;
        public Tuple<int, int> pointTwo;
        public Tuple<int, int> originPoint;
        public Triangle()
        {
            pointTop = Tuple.Create(0, 0);
            pointTwo = Tuple.Create(0, 0);
            originPoint = Tuple.Create(0, 0);
        }
    }
}
