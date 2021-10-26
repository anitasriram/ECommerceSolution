using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApiIntegrationTests.OrdersResource
{
    public static class OrdersTestData
    {
        public static OrderRequest ValidOrder = new OrderRequest
        {
            name = "Bob Smith",
            address = "1212 Orange St",
            city = "Akron",
            state = "OH",
            zip = "44319",
            creditCardInfo = new Creditcardinfo
            {
                number = "555-55-5555",
                expiration = "06/22",
                cvv2 = "973"
            },
            items = new List<Item>
                {
                    new Item { id="1", name="Beer", price=6.99M, qty=1}
                }


        };
    }
}