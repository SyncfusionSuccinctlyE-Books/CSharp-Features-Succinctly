using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp7Features
{
    public class Demo
    {
        public Demo()
        {
            #region out variables
            //GetNumberOfCopies(out var numberOfCopies);

            //if (int.TryParse("3", out var factor))
            //{

            //} 
            #endregion

            #region discard variable (In extension method)
            //var stringInt = "10s";
            //if (stringInt.ToInt())
            //{
            //    Console.WriteLine("Valid Integer");
            //}
            //else
            //    Console.WriteLine("Invalid Integer");
            #endregion

            #region tuples
            ////var foundedDates = (Microsoft: 1975, Apple: 1976, Amazon: 1994);

            //(int Microsoft, int Apple, int Amazon) foundedDates = (1975, 1976, 1994);

            //Console.WriteLine($"Microsoft founded in {foundedDates.Microsoft}");
            //Console.WriteLine($"Apple founded in {foundedDates.Apple}");
            //Console.WriteLine($"Amazon founded in {foundedDates.Amazon}");

            //var distanceToEarth = 384400;
            //var radius = 1737.1;
            //var moon = (distanceToEarth, radius);

            //Console.WriteLine($"The moon is {moon.distanceToEarth} km from Earth.");
            //Console.WriteLine($"The moon has a radius of {moon.radius} km.");

            //// Equality and tuples
            //var teamOne = (JohnScore: 15, MikeScore: 27);
            //var teamTwo = (SallyScore: 15, MelissaScore: 27);

            //Console.WriteLine(teamOne == teamTwo); // Equates to true

            //var person = ReadPersonInfo();
            //Console.WriteLine($"{person.Fullname} was born on {person.BirthDate:dd MMMM yyyy} and is {person.Age} years old.");

            ////(int age, DateTime DOB, string fullName) = ReadPersonInfo();
            ////Console.WriteLine($"{fullName} was born on {DOB:dd MMMM yyyy} and is {age} years old.");

            //var (age, DOB, fullName) = ReadPersonInfo();
            //Console.WriteLine($"{fullName} was born on {DOB:dd MMMM yyyy} and is {age} years old."); 
            #endregion

            #region pattern matching
            //var cylinder = new Cylinder(20, 2.5);
            //var sphere = new Sphere(2.5);
            //var pyramid = new Pyramid(2.5, 3, 16);

            //var cylinderVol = CalculateVolume(cylinder);
            //var sphereVol = CalculateVolume(sphere);
            //var pyramidVol = CalculateVolume(pyramid);

            //Console.WriteLine($"The volume of the Cylinder is {Math.Round(cylinderVol,2)}");
            //Console.WriteLine($"The volume of the Sphere is {Math.Round(sphereVol, 2)}");
            //Console.WriteLine($"The volume of the Pyramid is {Math.Round(pyramidVol,2)}"); 
            #endregion

            #region local fucntions
            //Console.WriteLine(MethodOne());

            //var cylinder = new Cylinder(20, 2.5);
            //var sphere = new Sphere(2.5);
            //var pyramid = new Pyramid(2.5, 3, 16);

            //var vShapes = (cylinder, sphere, pyramid);
            //Console.WriteLine(TotalObjectVolume(vShapes)); 
            #endregion
                        
            _ = Console.ReadLine();
        }


        #region out variables
        private void GetNumberOfCopies(out int numCopies)
        {
            numCopies = 20;
        }
        #endregion

        #region tuples
        private (int Age, DateTime BirthDate, string Fullname) ReadPersonInfo()
        {
            var personData = (age: 0, birthday: DateTime.MinValue, fullName: "");
            // Read data from somewhere
            personData.fullName = "Joe Soap";

            var today = DateTime.Now;
            personData.birthday = today.AddYears(-44);
            personData.age = today.Year - personData.birthday.Year;

            return personData;
        }
        #endregion

        #region pattern matching
        //private double CalculateVolume<T>(T volumeShape) 
        //{
        //    if (volumeShape is Cylinder c)            
        //        return Math.PI * Math.Pow(c.Radius, 2) * c.Length;
        //    else if (volumeShape is Sphere s)
        //        return 4 * Math.PI * Math.Pow(s.Radius, 3) / 3;
        //    else if (volumeShape is Pyramid p)
        //        return p.BaseLength * p.BaseWidth * p.Height / 3;

        //    throw new ArgumentException(message: "Unrecognized object", paramName: nameof(volumeShape));
        //}

        //private double CalculateVolume<T>(T volumeShape)
        //{
        //    switch (volumeShape)
        //    {
        //        case Sphere s when s.Radius == 0:
        //            return 0;
        //        case Cylinder c:
        //            return Math.PI * Math.Pow(c.Radius, 2) * c.Length;
        //        case Sphere s:
        //            return 4 * Math.PI * Math.Pow(s.Radius, 3) / 3;
        //        case Pyramid p:
        //            return p.BaseLength * p.BaseWidth * p.Height / 3;
        //        default:
        //            throw new ArgumentException(message: "Unrecognized object", paramName: nameof(volumeShape));
        //    }
        //} 
        #endregion

        #region local fucntions
        private double TotalObjectVolume((Cylinder c, Sphere s, Pyramid p) volumeShapes)
        {
            var cylinderVol = CalculateVolume(volumeShapes.c);
            var sphereVol = CalculateVolume(volumeShapes.s);
            var pyramidVol = CalculateVolume(volumeShapes.p);

            return Math.Round(cylinderVol + sphereVol + pyramidVol, 2);

            // Local functions here
            double CalculateVolume<T>(T volumeShape)
            {
                switch (volumeShape)
                {
                    case Sphere s when s.Radius == 0:
                        return 0;
                    case Cylinder c:
                        return Math.PI * Math.Pow(c.Radius, 2) * c.Length;
                    case Sphere s:
                        return 4 * Math.PI * Math.Pow(s.Radius, 3) / 3;
                    case Pyramid p:
                        return p.BaseLength * p.BaseWidth * p.Height / 3;
                    default:
                        throw new ArgumentException(message: "Unrecognized object", paramName: nameof(volumeShape));
                }
            }
        }

        private string MethodOne()
        {
            string MethodTwo()
            {
                return "I am local function two";
            }

            var getText = MethodTwo();
            return getText;
        }

        private string MethodTwo()
        {
            return "I am method two";
        } 
        #endregion
                
    }

    

    #region pattern matching
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

    #region expression-bodied members
    public class Circle
    {
        public double Radius { get; }
        public double RadiusSquared
        {
            get => Math.Pow(Radius, 2);
        }

        public Circle(double radius) => Radius = radius;

        ~Circle() => Console.WriteLine("Run cleanup statements");
    }
    #endregion

    #region adding logic to interface breaks implementations
    //// This introduces a breaking change in C# 7 and below versions of .NET
    //// See C# 8 default Interface methods in CSharp8Features project
    //public class SalesOrder : IOrder
    //{
    //    public void CreateOrder(DateTime orderDate) { }
    //}

    //public interface IOrder
    //{
    //    void CreateOrder(DateTime orderDate);
    //    void CreateOrder();
    //} 
    #endregion


}
