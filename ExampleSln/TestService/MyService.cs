using System;
using ServiceStack;
using System.Reflection;

namespace TestService
{
  public class MyService
  {
    private string _listeningOn = "http://*:1337/";

    public void StartService()
    {
      var appHost = new AppHost()
        .Init()
        .Start(_listeningOn);

      Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, _listeningOn);

      Console.ReadKey();
    }

    [Route("/hello/{Name}/{Day}")]
    public class Hello
    {
      public string Name { get; set; }
      public string Day { get; set; }

    }

    public class HelloResponse
    {
      public string Result { get; set; }
    }

    public class HelloService : Service
    {
      public object Any(Hello request)
      {
        return new HelloResponse { Result = "Hello, " + request.Name + ". Today is: " + request.Day };
      }
    }

    //define the web services apphost
    public class AppHost : AppSelfHostBase
    {
      public AppHost() : base("HttpListener Self-Host", typeof(HelloService).GetTypeInfo().Assembly) { }

      public override void Configure(Funq.Container container) { }
    }
  }
}
