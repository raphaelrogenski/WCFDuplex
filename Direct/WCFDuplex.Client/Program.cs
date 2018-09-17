using System;
using System.ServiceModel;
using WCFDuplex.Client.WCF;

namespace WCFDuplex.Client
{
  class Program
  {
    static void Main()
    {
      InstanceContext context = new InstanceContext(new ClockCallback());

      var client = new ClockServiceClient(context);
      client.Connect();

      Console.Read();

      client.Disconnect();
      client.Close();
    }
  }
}
