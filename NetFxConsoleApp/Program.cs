using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFxConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private double TotalObjectVolume((Cylinder c, Sphere s, Pyramid p) volumeShapes)
        {
            var cylinderVol = CalculateVolume(volumeShapes.c);
            var sphereVol = CalculateVolume(volumeShapes.s);
            var pyramidVol = CalculateVolume(volumeShapes.p);

            return Math.Round(cylinderVol + sphereVol + pyramidVol, 2);

            // static local functions here
            static double CalculateVolume<T>(T volumeShape)
            {
                return volumeShape switch
                {
                    Sphere s when s.Radius == 0     => 0,
                    Cylinder c                      => Math.PI * Math.Pow(c.Radius, 2) * c.Length,
                    Sphere s                        => 4 * Math.PI * Math.Pow(s.Radius, 3) / 3,
                    Pyramid p                       => p.BaseLength * p.BaseWidth * p.Height / 3,
                    _                               => throw new ArgumentException(message: "Unrecognized object", paramName: nameof(volumeShape)),
                };
            }            
        }
    }


    #region General supporting code
    public class Cylinder
    {
        public double Length { get; }
        public double Radius { get; }

        public Cylinder(double length, double radius)
        {
            Length = length;
            Radius = radius;
        }
    }

    public class Sphere
    {
        public double Radius { get; }

        public Sphere(double radius)
        {
            Radius = radius;
        }
    }

    public class Pyramid
    {
        public double BaseLength { get; }
        public double BaseWidth { get; }
        public double Height { get; }

        public Pyramid(double baseLength, double baseWidth, double height)
        {
            BaseLength = baseLength;
            BaseWidth = baseWidth;
            Height = height;
        }
    }
    #endregion
}
