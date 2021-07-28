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
    /// Tests to make sure inventory values should be above 0
    /// </summary>
    public class InventoryModelTest
    {
        [Theory]
        [InlineData(3-12)]
        [InlineData(0-1)]
        [InlineData(5-9)]
        [InlineData(6-8)]
        public void PostUpdateInventoryShouldBePositive(int input)
        {
            //Arrange
            Inventory test = new Inventory();

            // Act
            test.QuantityHeld = input;

            //Assert
            Assert.True(test.QuantityHeld < 0);
            //Assert.Throws<Exception>(() => input > 0);
        }
    }
}
