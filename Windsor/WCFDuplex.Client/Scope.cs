using System;
using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;
using WCFDuplex.Server;

namespace WCFDuplex.Client
{
  public class Scope
  {
    protected IWindsorContainer Container;

    public void Execute()
    {
      Container = new WindsorContainer();
      Container.Install(FromAssembly.Instance(Assembly.GetExecutingAssembly()));

      var client = Container.Resolve<IClockService>();
      client.Connect();

      Console.Read();

      client.Disconnect();
    }
  }
}
