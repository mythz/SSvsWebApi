using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        public void ConfigureServices(IServiceCollection services) 
        {
          // uncomment for WebApi
           services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          // uncomment for WebApi
           app.UseMvc();

          // uncomment for ServiceStack
           //app.UseServiceStack(new AppHost());

          // **********************************************************
          // uncomment for aspnet map router w/ newtonsoft serialization
          // app.Map("", config =>
          // {
          //   config.Run(async context =>
          //   {
          //     context.Response.ContentType = "application/json";
          //     await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { hello = "world" }));
          //   });
          // });

          // **********************************************************
          // uncomment for aspnet core raw w/ newtonsoft serialization
          /* app.Run(async (context) =>
           {
               context.Response.ContentType = "application/json";
               await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new HelloWorldResponse()));
           });
          */
          // **********************************************************
          // uncomment for aspnet core raw w/ servicestack serialization
          /*app.Run(async (context) =>
          {
              context.Response.ContentType = "application/json";
              await context.Response.WriteAsync(ServiceStack.Text.JsonSerializer.SerializeToString(new HelloWorldResponse()));
          });*/
          
        }
    }

    public class AppHost : ServiceStack.AppHostBase
    {
        public AppHost() : base("api", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Container container)
        {
          /*SetConfig(new HostConfig {
              DefaultContentType = MimeTypes.Json,
              EnableFeatures = Feature.All.Remove(Feature.Html)
          });*/

          // **********************************************************
          // uncomment for servicestack raw handler implementation
          // this.RawHttpHandlers.Add(req => {
          //   if (req.PathInfo == "/") {
          //     return new ServiceStack.Host.Handlers.CustomActionHandler((r1, res) => {
          //       res.WriteToResponse(new HelloWorldResponse(), "application/json");
          //       res.EndHttpHandlerRequest(skipHeaders: false);
          //     });;
          //   }
          //   return null;
          // });
        }
    }

    public class HelloWorldService: Service
    {
      /*public Task<HelloWorldResponse> Get(HelloWorldRequest request)
      {
        return Task.FromResult(new HelloWorldResponse());
      }*/

     public HelloWorldResponse Get(HelloWorldRequest request)
      {
        return new HelloWorldResponse();
      }
      
      //public Task<HelloWorldResponse> Any(FallbackRequest request)
      //{
      //  return Task.FromResult(new HelloWorldResponse());
      //}
      
      /*public HelloWorldResponse Any(FallbackRequest request)
      {
         return new HelloWorldResponse();
      }*/
    }

    [ServiceStack.Route("/hello")]
    public class HelloWorldRequest {}

    public class HelloWorldResponse
    {
      public string Hello => "World"; 
    }

    [FallbackRoute("/{Path*}")]
    public class FallbackRequest {
      public string Path { get; set;}
    }
}
