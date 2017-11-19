using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) => logging.ClearProviders())               
                .UseStartup<Startup>()
                .Build();
    }

    [ServiceStack.Route("/hello")]
    public class Hello : ServiceStack.IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

    public static class Dtos
    {
        public static HelloResponse HelloResponse = new HelloResponse { Result = "Hello, World!" };
        public static string HelloResponseString = "{\"Result\":\"Hello, World!\"}";
    }
}
