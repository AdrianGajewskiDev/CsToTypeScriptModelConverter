using Converter.Core.Converter;
using Converter.Core.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using System;

namespace Converter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = @"
	                public class Car : Vehicle
                    {
                        public Dictionary<string, int> CarBrand { get; set; }
                        public string CarModel { get; set; }
                        public string CarType { get; set; }
                        public int NumberOfDoors { get; set; }
                        public int NumberOfSeats { get; set; }
                        public string Gearbox { get; set; }
                    }";

            var tsCode = new CTSConverter().Convert(code);

            System.Console.Write(tsCode);
            System.Console.ReadLine();
        }
    }
}
