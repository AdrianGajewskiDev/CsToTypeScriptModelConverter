using Xunit;
using Converter.Core.Reflection;
using FluentAssertions;

namespace Converter.Tests
{
    public class CSharpClassPropertiesTests
    {
        const string code1 = @"
	                public class Car : Vehicle
                    {
                        public Dictionary<string, int> CarBrand { get; set; }
                        public List<string> CarModel { get; set; }
                        public Func<string, int, int> CarType { get; set; }
                        public int NumberOfDoors { get; set; }
                        public int NumberOfSeats { get; set; }
                        public string Gearbox { get; set; }
                    }";


        const string code2 = @"
	                public class Car
                    {
                        public Dictionary<string, int> CarBrand { get; set; }
                        public List<string> CarModel { get; set; }
                        public Func<string, int, int> CarType { get; set; }
                        public int NumberOfDoors { get; set; }
                        public int NumberOfSeats { get; set; }
                        public string Gearbox { get; set; }
                    }";

        [Theory]
        [InlineData(0, "Dictionary<string,number>")]
        [InlineData(1, "List<string>")]
        [InlineData(2, "Func<string,number,number>")]
        public void ShouldParseTheGenericType(int index, string expected)
        {
            var result = TypeResolver.Get(code1);

            var prop = result.GetProperties()[index];

            prop.Type.Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnTrueIfClassIsInheritingFromBaseClass()
        {
            var result = TypeResolver.Get(code1).HasBaseType;

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnFalseIfClassIsNotInheritingFromBaseClass()
        {
            var result = TypeResolver.Get(code2).HasBaseType;

            result.Should().BeFalse();
        }
    }
}
