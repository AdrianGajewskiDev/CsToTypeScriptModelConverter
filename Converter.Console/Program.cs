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
	                public partial class ProfileInfoModel : BaseNopModel
                    {
                        public DateTime AvatarUrl { get; set; }
public Dictionary<DateTime,string> Values {get;set;}

                    }";

            var tsCode = new CTSConverter().Convert(code);

            System.Console.Write(tsCode);
            System.Console.ReadLine();
        }
    }
}
