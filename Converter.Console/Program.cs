using Converter.Core.Converter;

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
                        public Generic<int, Application> Values {get;set;}

                    }";

            var tsCode = new CTSConverter().Convert(code);

            System.Console.Write(tsCode);
            System.Console.ReadLine();
        }
    }
}
