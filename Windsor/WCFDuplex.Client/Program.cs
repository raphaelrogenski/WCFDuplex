using System;
using System.ServiceModel;
using WCFDuplex.Server;

namespace WCFDuplex.Client
{
  class Program
  {
    static void Main()
    {
      //InstanceContext context = new InstanceContext(new ClockCallback());

      var scope = new Scope();
      scope.Execute();
    }
  }
}
