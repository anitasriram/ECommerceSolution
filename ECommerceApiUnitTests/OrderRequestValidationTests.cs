using ECommerceApi.Controllers;
using ECommerceApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiUnitTests
{
    public class OrderRequestValidationTests
    {
        [Fact(Skip = "Do this later")]
        public void OrderRequestHasTheCorrectValidationAttributes()
        {
            // TODO: Learn some C# Reflection!
        }

        [Fact]
        public void OrderPostValidatesModel()
        {
            var method = typeof(OrdersController).GetMethods()
                .SingleOrDefault(x => x.Name == nameof(OrdersController.PlaceOrder));

            var attribute = method?.GetCustomAttributes(typeof(ValidateModelAttribute), true)
                .Single() as ValidateModelAttribute;

            Assert.NotNull(attribute);
        }
    }
}