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
    public class OrderModelTest
    {
        [Fact]
        public void OrderQuantityShouldBeInteger()
        {
            // Arrange
            Order newOrderQuantity = new Order();
            int quantity = 10;

            // Act
            newOrderQuantity.QuantitySold = quantity;

            // Assert
            Assert.Equal(quantity, newOrderQuantity.QuantitySold);
        }
    }
}
