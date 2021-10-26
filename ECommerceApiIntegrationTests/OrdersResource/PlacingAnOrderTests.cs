using ECommerceApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiIntegrationTests.OrdersResource
{
    public class PlacingAnOrderTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        public PlacingAnOrderTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Gets201StatusCode()
        {
            var response = await _client.PostAsJsonAsync("/orders", OrdersTestData.ValidOrder);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact(Skip = "Wait until after I add the other resource")]
        public async Task HasLocationHeader()
        {
            // response should have a location header with the url to the new resource.
        }
        [Fact]
        public async Task HasCorrectContentTypeOnResponse()
        {


            var response = await _client.PostAsJsonAsync("/orders", OrdersTestData.ValidOrder);

            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }
    }


    public class OrderRequest
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public Creditcardinfo creditCardInfo { get; set; }
        public List<Item> items { get; set; }
    }

    public class Creditcardinfo
    {
        public string number { get; set; }
        public string expiration { get; set; }
        public string cvv2 { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }
    }


}