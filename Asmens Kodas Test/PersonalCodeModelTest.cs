using System;
using Asmens_kodas.Models;
using Xunit;
namespace Asmens_Kodas_Test
{
    public class PersonalCodeModelTest
    {
        public static long staticID { get; set; } = 39809273457;
        public static DateTime date;
        public PersonalCodeModelTest()
        {
            date = new DateTime(1998,09,27);
        }

        [Fact]
        public void Create_ValidDataShouldCreateID()
        {
            long expected = 39809273457;

            var actually = new PersonalCodeModel(date, GenderEnum.Male, 345).Code;

            Assert.Equal(expected, actually);
        }

        [Theory]
        [InlineData(GenderEnum.Male, 99)]
        [InlineData(GenderEnum.Male, 1000)]
        [InlineData(GenderEnum.Female, int.MaxValue)]
        [InlineData(GenderEnum.Female, int.MinValue)]
        public void Create_InvalidDataShouldFail(GenderEnum gender, int line)
        {
            Assert.Throws<Exception>(() =>
            {
                var actual = new PersonalCodeModel(date, gender, line);
            });
        }

        [Theory]
        [InlineData(long.MinValue)]
        [InlineData(long.MaxValue)]
        [InlineData(100000000000)]
        public void Create_InvalidCodeShouldFail(long code)
        {
            Assert.Throws<Exception>(() =>
            {
                var actual = new PersonalCodeModel(code);
            });
        }

        [Fact]
        public void getDate_CorrectDataShouldPass()
        {
            var expected = date;
            var actual = new PersonalCodeModel(staticID).getDate();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getYear_CorrectDataShouldPass()
        {
            var expected = date.Year;
            var actual = new PersonalCodeModel(staticID).getYear();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void getMonth_CorrectDataShouldPass()
        {
            var expected = date.Month;
            var actual = new PersonalCodeModel(staticID).getMonth();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getDay_CorrectDataShouldPass()
        {
            var expected = date.Day;
            var actual = new PersonalCodeModel(staticID).getDay();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getSex_CorrectDataShouldPass()
        {
            var expected = GenderEnum.Male;
            var actual = new PersonalCodeModel(staticID).getSex();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getNumber_CorrectDataShouldPass()
        {
            var expected = 345;
            var actual = new PersonalCodeModel(staticID).getNumber();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void getCheckSum_CorrectDataShouldPass()
        {
            var expected = 7;
            var actual = new PersonalCodeModel(staticID).getCheckSum();

            Assert.Equal(expected, actual);
        }
    }
}
