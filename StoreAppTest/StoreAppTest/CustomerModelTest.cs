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
    /// <summary>
    /// Multiple tests to make sure customer form takes correct input types for first and last names
    /// </summary>
    public class CustomerModelTest
    {
        [Theory]
        [InlineData("Rick c-137")]
        [InlineData("Pill$berry_DoeBoi")]
        [InlineData("A_aron")]
        [InlineData("l33tcoder")]
        [InlineData("Shoney's")]
        [InlineData("!xobile")]
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
        [InlineData("Tekashi69")]
        [InlineData("xXx___xXx")]
        public void LastNameShouldGetValidData(string input)
        {
            //Arrange
            Customer test = new Customer();

            //Act
            Assert.Throws<Exception>(() => test.LastName = input);
        }
    }
}
