using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Reflection;

namespace AutomatedTests
{
    public class TestForLogin
    {
        static readonly HttpClient client = new HttpClient();

        [Fact]
        public async Task Login_TransitionToEndPoint_GettingToken()
        {
            //arrange
            
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            client.BaseAddress = new Uri(config.GetSection("AppSettings").GetSection("BaseAddress").Value);

            var content = new StringContent("{\"Email\" : \"admnexadel@gmail.com\", \"Password\" : \"Qwerty123!\"}", Encoding.UTF8, "application/json");

            //act
            var response = await client.PostAsync("login", content);
            var result = await response.Content.ReadAsStringAsync();

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("token", result);
        }
    }
}