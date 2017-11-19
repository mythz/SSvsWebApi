using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Funq;

namespace aspnet
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "application/json";

                // (WSL) wrk -c 256 -t 8 -d 10 http://localhost:3000/hello?format=json
                // Run 4 times, discard 1st, pick top 2:

                // 73775.51 - 74849.31 Req/Sec
                // no response

                // 68312.02 - 69024.90 Req/Sec
                await context.Response.WriteAsync(JsonSerializer.SerializeToString(Dtos.HelloResponse));
            });
        }
    }
}
