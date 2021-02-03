using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Console;

namespace CSharp8Features
{
    public class Demo
    {
        
        #region switch expressions
        public enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        } 
        #endregion


        public Demo()
        {
            #region Indices and ranges
            /*
                string[] months =
                {                   // From Start       From End
                    "January",      // 0                ^12
                    "February",     // 1                ^11
                    "March",        // 2                ^10
                    "April",        // 3                ^9
                    "May",          // 4                ^8
                    "June",         // 5                ^7
                    "July",         // 6                ^6
                    "August",       // 7                ^5
                    "September",    // 8                ^4
                    "October",      // 9                ^3
                    "November",     // 10               ^2
                    "December"      // 11               ^1
                };

                WriteLine(months[3]);   // From array start
                WriteLine(months[^12]); // From array end

                var slice = months[^4..^0];
                foreach (var s in slice) WriteLine(s);

                WriteLine(months[months.Length - 1]);
                WriteLine(months[^1]);

                var year = months[..];
                foreach (var s in year) WriteLine(s); // January to December

                var quarter = months[..3];
                foreach (var s in quarter) WriteLine(s); // Quarter 1 - January to March

                var restOfYear = months[3..];
                foreach (var s in restOfYear) WriteLine(s); // April to December


                WriteLine(months[^5]);
                WriteLine(months[months.Length - 5]);

                var yr = months[0..^0];
                foreach (var s in yr) WriteLine(s);

                var july = ^6;
                WriteLine(months[july]); // July

                var firstSemester = 0..6;
                var semester = months[firstSemester];
                foreach (var s in semester) WriteLine(s); // January to June

                var lstmonths = new List<string>
                {
                    "January", "February", "March", "April",
                    "May", "June", "July", "August",
                    "September", "October", "November", "December"
                };

                WriteLine(lstmonths[^2]);
                */
            #endregion

            #region switch expressions
            //WriteLine(GetBirthstone(Months.January));
            //WriteLine(GetBirthstone(Months.February)); 
            #endregion

            #region readonly members
            //var d = new DaysSince() { GivenDate = DateTime.Now.AddMonths(-13) };
            //WriteLine(d); 
            #endregion

            #region static local functions
            //var cylinder = new Cylinder(20, 2.5);
            //var sphere = new Sphere(2.5);
            //var pyramid = new Pyramid(2.5, 3, 16);

            //var vShapes = (cylinder, sphere, pyramid);
            //WriteLine(TotalObjectVolume(vShapes)); 
            #endregion

            #region disposable ref structs
            //using var scores = new StudentScores(); 
            #endregion

            #region null-coalescing assignment
            //List<int> lstSc = null;
            //AddUpdateScores(lstSc); 
            #endregion

            #region unmanaged constructed types
            //var mystruct = new MyStruct<int> { One = 1, Two = 2 };
            //var props = mystruct.GetProps();

            //var mystruct2 = new MyStruct<string> { One = "One", Two = "Two" }; 
            #endregion
         }

        

        #region nullable reference types
        private void ListStudents(IEnumerable<Student?> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student.FirstName);
            }
        }

        #region null-forgiving operator
        private void GetStudentName(Student? student)
        {
            if (student.IsValid())
            {
                Console.WriteLine(student!.FirstName);
            }
        }
        #endregion

        #endregion

        #region switch expressions
        //private string GetBirthstone(Months month)
        //{
        //    switch (month)
        //    {
        //        case Months.January:
        //            return "Ruby or Rose Quartz";
        //        case Months.March:
        //            return "Bloodstone and Aquamarine";
        //        case Months.April:
        //            return "Diamond";
        //        case Months.May:
        //            return "Emerald";
        //        case Months.June:
        //            return "Pearl, Alexandrite, and Moonstone";
        //        case Months.July:
        //            return "Ruby";
        //        case Months.August:
        //            return "Sardonyx and Peridot";
        //        case Months.September:
        //            return "Sapphire";
        //        case Months.October:
        //            return "Opal and The Tourmaline";
        //        case Months.November:
        //            return "Topaz";
        //        case Months.December:
        //            return "Turquoise and Zircon";
        //        default:
        //            return $"Did not find a birth stone for {month}";
        //    }
        //}

        private string GetBirthstone(Months month) =>
            month switch
            {
                Months.January => "Ruby or Rose Quartz",
                Months.March => "Bloodstone and Aquamarine",
                Months.April => "Diamond",
                Months.May => "Emerald",
                Months.June => "Pearl, Alexandrite, and Moonstone",
                Months.July => "Ruby",
                Months.August => "Sardonyx and Peridot",
                Months.September => "Sapphire",
                Months.October => "Opal and The Tourmaline",
                Months.November => "Topaz",
                Months.December => "Turquoise and Zircon",
                _ => $"Did not find a birth stone for {month}",
            };
        #endregion

        #region using declarations
        private void ReadFile()
        {
            //using (var reader = new System.IO.StreamReader("C:\\temp\\TextDocument.txt"))
            //{
            //    var lines = reader.ReadToEnd();
            //}

            using var reader = new System.IO.StreamReader("C:\\temp\\TextDocument.txt");
            var lines = reader.ReadToEnd();
        }
        #endregion

        #region static local functions
        private double TotalObjectVolume((Cylinder c, Sphere s, Pyramid p) volumeShapes)
        {
            var cylinderVol = CalculateVolume(volumeShapes.c);
            var sphereVol = CalculateVolume(volumeShapes.s);
            var pyramidVol = CalculateVolume(volumeShapes.p);

            //var rad = GetCylinderRadius();

            return Math.Round(cylinderVol + sphereVol + pyramidVol, 2);

            // static local functions here
            static double CalculateVolume<T>(T volumeShape)
            {
                return volumeShape switch
                {
                    Sphere s when s.Radius == 0 => 0,
                    Cylinder c => Math.PI * Math.Pow(c.Radius, 2) * c.Length,
                    Sphere s => 4 * Math.PI * Math.Pow(s.Radius, 3) / 3,
                    Pyramid p => p.BaseLength * p.BaseWidth * p.Height / 3,
                    _ => throw new ArgumentException(message: "Unrecognized object", paramName: nameof(volumeShape)),
                };
            }

            //static double GetCylinderRadius()
            //{
            //    var cylinder = volumeShapes.c; // Compiler error
            //    return cylinder.Radius;
            //}
        }
        #endregion

        #region null-coalescing assignment
        private void AddUpdateScores(List<int> lstScores)
        {
            //if (lstScores == null)
            //{
            //    lstScores = new List<int>();
            //}

            lstScores ??= new List<int>();

            // Add/Update scores
        } 
        #endregion
    }


    #region default interface methods
    public class SalesOrder : IOrder
    {
        public void CreateOrder(DateTime orderDate) { }
    }

    public interface IOrder
    {
        void CreateOrder(DateTime orderDate);
        void CreateOrder() => CreateOrder(DateTime.Now);
    }
    #endregion

    #region nullable reference types
    public class Student
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    #endregion

    #region readonly members
    //public struct DaysSince
    //{
    //    public DateTime GivenDate { get; set; }
    //    public double Number => Math.Round((DateTime.Now - GivenDate).TotalDays, 0);

    //    public override string ToString() => $"Days since {GivenDate} = {Number} days";
    //}


    public struct DaysSince
    {
        public DateTime GivenDate { get; set; }
        public readonly double Number => Math.Round((DateTime.Now - GivenDate).TotalDays, 0);

        public readonly override string ToString() => $"Days since {GivenDate} = {Number} days";
    }
    #endregion

    #region disposable ref structs
    ref struct StudentScores
    {
        public void Dispose()
        {
            // perform clean up
        }
    }
    #endregion

    #region unmanaged constructed types
    public struct MyStruct<T> where T : unmanaged
    {
        public T One;
        public T Two;
    } 
    #endregion



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
