using System;
using Asmens_kodas.Models;
using Xunit;
namespace Asmens_Kodas_Test
{
    public class PersonalCodeModelTest
    {
        

        [Fact]
        public void Create_ValidDataShouldCreateID()
        {
            long expected = 39809273457;

            var actually = new PersonalCodeModel(new DateTime(1998, 09, 27), GenderEnum.Male, 345).Code;

            Assert.Equal(expected, actually);
        }
    }
}
