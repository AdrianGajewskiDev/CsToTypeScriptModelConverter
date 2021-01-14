using Converter.Core.Reflection;
using FluentAssertions;
using System;
using Xunit;

namespace Converter.Tests
{
    public class TypeResolverTests
    {
        const string code1 = @"
	                public class Car : Vehicle
                    {
                        public Dictionary<string, int> CarBrand { get; set; }
                        public string CarModel { get; set; }
                        public string CarType { get; set; }
                        public int NumberOfDoors { get; set; }
                        public int NumberOfSeats { get; set; }
                        public string Gearbox { get; set; }
                    }";

        const string code2 = @"
	                class User 
                    {
                        public string Name { get; set; }
                        public string LastName { get; set; }
                    }";

        const string code3 = @"
	                private class Address
                    {
                        public string City { get; set; }
                    }";


        [Theory]
        [InlineData(code1, "Car")]
        [InlineData(code2, "User")]
        [InlineData(code3, "Address")]
        public void ShouldReturnCorrectClassNameFromCode(string code, string className)
        {
            var result = TypeResolver.Get(code).ClassName;

            result.Should().Be(className);
        }

        [Theory]
        [InlineData(code1, 6)]
        [InlineData(code2, 2)]
        [InlineData(code3, 1)]
        public void ShouldReturnAllPropertiesFromClass(string code, int count)
        {
            var result = TypeResolver.Get(code).GetProperties().Count;

            result.Should().Be(count);
        }

        [Fact]
        public void ShouldValidateCSharpCode()
        {
            var result = TypeResolver.Get(code1);

            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData("Some Invalid code")]
        [InlineData("export class name")]
        [InlineData("sadflasdl")]
        public void ShouldReturnNullWhenUserProvidesInvalidCSCode(string invalidCode)
        {
            var result = TypeResolver.Get(invalidCode);

            result.Should().BeNull();
        }
    }
}
