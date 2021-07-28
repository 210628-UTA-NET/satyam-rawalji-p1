using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreAppModels;
using Xunit;

namespace StoreAppTest
{
    public class CustomerModelTest
    {
        [Theory]
        [InlineData("Rick c-137")]
        [InlineData("Pill$berry_DopeBoi")]
        [InlineData("A_aron")]
        [InlineData("l33tcoder")]
        [InlineData("80085")]
        [InlineData("PEN15")]
        public void FirstNameShouldGetValidData(string input)
        {
            //Arrange
            Customer test = new Customer();

            //Act
            Assert.Throws<Exception>(() => test.FirstName = input);
        }

        [Theory]
        [InlineData("$antana")]
        [InlineData("Rodgers-Cromartie")]
        [InlineData("@nderson")]
        [InlineData("69")]
        [InlineData("xXx__694202496_xXx")]
        public void LastNameShouldGetValidData(string input)
        {
            //Arrange
            Customer test = new Customer();

            //Act
            Assert.Throws<Exception>(() => test.LastName = input);
        }
    }
}
