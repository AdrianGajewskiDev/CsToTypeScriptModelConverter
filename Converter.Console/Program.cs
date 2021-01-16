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
                        public int CustomerProfileId { get; set; }

                        public string AvatarUrl { get; set; }

                        public bool LocationEnabled { get; set; }
                        public string Location { get; set; }

                        public bool PMEnabled { get; set; }

                        public bool TotalPostsEnabled { get; set; }
                        public string TotalPosts { get; set; }

                        public bool JoinDateEnabled { get; set; }
                        public string JoinDate { get; set; }

                        public bool DateOfBirthEnabled { get; set; }
                        public string DateOfBirth { get; set; }
                    }";

            var tsCode = new CTSConverter().Convert(code);

            System.Console.Write(tsCode);
            System.Console.ReadLine();
        }
    }
}
