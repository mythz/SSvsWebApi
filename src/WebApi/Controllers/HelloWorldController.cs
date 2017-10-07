using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class HelloWorldController : Controller
    {
      /*[Route("/")]
      [HttpGet]
      public Task<HelloWorldResponse> Get()
      {
        return Task.FromResult(new HelloWorldResponse());
      } */

      // [Route("/")]
      // [HttpGet]
      // public HelloWorldResponse Get()
      // {
      //   return new HelloWorldResponse();
      // } 

      [Route("/hello")]
      [HttpGet]
      public Task<HelloWorldResponse> Get(HelloWorldRequest request)
      {
        return Task.FromResult(new HelloWorldResponse());
      }

      // [Route("/hello")]
      // [HttpGet]
      // public HelloWorldResponse Get(HelloWorldRequest request)
      // {
      //   return new HelloWorldResponse();
      // }   
    }
}
