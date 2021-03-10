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
    public class TestForTowns
    {
        static readonly HttpClient client = new HttpClient();

        [Fact]
        public async Task Towns_TransitionToEndPoint_GettingListOfTowns()
        {
            //arrange
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var baseAdrress = config.GetSection("AppSettings").GetSection("BaseAddress").Value;

            var requestForLogin = new HttpRequestMessage();
            var requestContent = requestForLogin.Content = new StringContent("{\"Email\" : \"admnexadel@gmail.com\", \"Password\" : \"Qwerty123!\"}", Encoding.UTF8, "application/json");

            var responseFromlogin = await client.PostAsync(baseAdrress + "login", requestContent);
            string token = responseFromlogin.Content.ReadAsStringAsync().Result;

            token = token.Substring(0, token.Length - 2).Remove(0, 10);

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseAdrress + "towns"),
                Headers = {
                    { HttpRequestHeader.Authorization.ToString(), "bearer " + token },
                },
            };

            //act
            var response = await client.SendAsync(httpRequestMessage);
            string result = response.Content.ReadAsStringAsync().Result;

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("townName", result);
        }
    }
}