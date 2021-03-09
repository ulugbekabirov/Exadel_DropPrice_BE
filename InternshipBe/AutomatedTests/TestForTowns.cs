using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AutomatedTests
{
    public class TestForTowns
    {

        var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

        IConfiguration config = builder.Build();

    }
}
