using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace aspnet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }

    // (WSL) wrk -c 256 -t 8 -d 10 http://localhost:3000/hello?format=json

    // 38742.63 - 39142.07 Req/Sec
    public class HelloWorldController : Controller
    {
        [Route("/hello")]
        [HttpGet]
        public HelloResponse Get(Hello request) => Dtos.HelloResponse;
    }

}