using System;
using TestService;

namespace HostExample
{
  public class Program
  {
    //Run it
    static void Main(string[] args)
    {
      try
      {
        var testService = new MyService();
        testService.StartService();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }
  }
}
