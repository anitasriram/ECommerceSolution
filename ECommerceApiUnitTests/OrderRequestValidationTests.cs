using ECommerceApi.Controllers;
using ECommerceApi.CustomValidators;
using ECommerceApi.Filters;
using ECommerceApi.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiUnitTests
{
    public class OrderRequestValidationTests
    {
        [Fact]
        public void OrderRequestHasTheCorrectValidationAttributes()
        {
            var maxLengthOnName = Helpers.GetPropertyAttributeValue<OrderPostRequest, string, MaxLengthAttribute, int>(p => p.Name, attr => attr.Length);

            Assert.Equal(120, maxLengthOnName);
            Assert.True(Helpers.HasAttribute<OrderPostRequest, RequiredAttribute>(c => c.Name));
            Assert.True(Helpers.HasAttribute<Creditcardinfo, CreditCardLuhnCheckAttribute>(c => c.Number));
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