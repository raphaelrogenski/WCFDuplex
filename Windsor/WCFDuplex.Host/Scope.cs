using System.Reflection;
using Castle.Windsor;
using Castle.Windsor.Installer;
using WCFDuplex.Server;

namespace WCFDuplex.Host
{
  public class Scope
  {
    protected IWindsorContainer Container;

    public void Execute()
    {
      Container = new WindsorContainer();
      Container.Install(FromAssembly.Instance(Assembly.GetExecutingAssembly()));
    }
  }
}
