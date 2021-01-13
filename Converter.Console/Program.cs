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
                        public string CarBrand { get; set; }
                        public string CarModel { get; set; }
                        public string CarType { get; set; }
                        public int NumberOfDoors { get; set; }
                        public int NumberOfSeats { get; set; }
                        public string Gearbox { get; set; }
                    }";

            var type = TypeResolver.Get(code);
        }
    }
}
