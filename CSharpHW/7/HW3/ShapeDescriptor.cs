using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class ShapeDescriptor
    {
        private Point[] points;
        public string ShapeType {
            get
            {
                if (points.Length == 3)
                {
                    if (points[0].X != points[1].X || points[1].X != points[2].X || points[2].X != points[0].X)
                    {
                        if (points[0].Y != points[1].Y || points[1].Y != points[2].Y || points[2].Y != points[0].Y)
                        {
                            return "Триугольник";
                        }
                        else
                        {
                            return "Линия";
                        }
                    }
                    else
                    {
                        return "Линия";
                    }
                }
                if (points.Length == 4)
                {
                    double dlAB, dlBC, dlCD, dlDA, dlAC, dlDB;
                    dlAB = Math.Sqrt( Math.Pow(points[1].X - points[0].X, 2) +  Math.Pow(points[1].Y - points[0].Y, 2));
                    dlBC = Math.Sqrt( Math.Pow(points[2].X - points[1].X, 2) +  Math.Pow(points[2].Y - points[1].Y, 2));
                    dlCD = Math.Sqrt( Math.Pow(points[3].X - points[2].X, 2) +  Math.Pow(points[3].Y - points[2].Y, 2));
                    dlDA = Math.Sqrt( Math.Pow(points[0].X - points[3].X, 2) +  Math.Pow(points[0].Y - points[3].Y, 2));
                    dlAC = Math.Sqrt( Math.Pow(points[2].X - points[0].X, 2) +  Math.Pow(points[2].Y - points[0].Y, 2));
                    dlDB = Math.Sqrt( Math.Pow(points[1].X - points[3].X, 2) +  Math.Pow(points[1].Y - points[3].Y, 2));

                    if (dlAB == dlBC && dlBC == dlCD && dlCD == dlDA && dlDA == dlAC && dlAC == dlDB)
                        return "Квадрат";
                    else if (dlAC != dlDB)
                        return "Ромб";
                    else if ((dlAC == dlDB) && (dlAB == dlCD) && (dlDA != dlAB))
                        return "прямоугольник";
                    else if (((points[1].X - points[0].X) 
                        / (points[1].Y - points[0].Y) == (points[3].X - points[2].X) 
                        / (points[3].Y - points[2].Y)) || (points[2].X - points[1].X) 
                        / (points[2].Y - points[1].Y) == (points[0].X - points[3].X) 
                        / (points[0].Y - points[3].Y))
                        return "Трапеция";
                    else return "Выпуклый четырехугольник";
                }
                return "Неопределенная фигура";
            }
        }

        public ShapeDescriptor(Point a, Point b, Point c)
        {
            points = new Point[3];
            points[0] = a;
            points[1] = b;
            points[2] = c;
        }

        public ShapeDescriptor(Point a, Point b, Point c, Point d)
        {
            points = new Point[4];
            points[0] = a;
            points[1] = b;
            points[2] = c;
            points[3] = d;
        }
    }
}
