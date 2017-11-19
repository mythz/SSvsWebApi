using System;
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
            app.UseServiceStack(new AppHost());
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base(nameof(aspnet), typeof(AppHost).Assembly) {}

        public override void Configure(Container container)
        {
            // (WSL) wrk -c 256 -t 8 -d 10 http://localhost:3000/hello?format=json

            RawHttpHandlers.Add(ctx => 
            {
                // 54480.18 - 54606.59 Req/Sec
                // return new ServiceStack.Host.Handlers.CustomActionHandlerAsync((req, res) => {
                //     res.ContentType = "application/json";
                //     return res.WriteAsync(JsonSerializer.SerializeToString(Dtos.HelloResponse));
                // });

                // 47246.21 - 47291.83 Req/Sec
                return new ServiceStack.Host.Handlers.CustomActionHandlerAsync((req, res) => {
                    return res.WriteToResponse(Dtos.HelloResponse, "application/json");
                });
            });
        }
    }
}
