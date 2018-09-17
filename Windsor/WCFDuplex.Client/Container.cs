using System;
using System.Configuration;
using System.ServiceModel.Description;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WCFDuplex.Server;

namespace WCFDuplex.Client
{
  public class Container : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.AddFacility<WcfFacility>(f => { f.CloseTimeout = TimeSpan.Zero; });

      var returnFaults = new ServiceDebugBehavior
      {
        IncludeExceptionDetailInFaults = true,
        HttpHelpPageEnabled = true
      };

      container.Register(Component.For<IServiceBehavior>().Instance(returnFaults));

      var endpoint = ConfigurationManager.AppSettings.Get("Endpoint_Service");

      container.Register(Component.For<IClockServiceCallback>()
        .ImplementedBy<ClockCallback>()
        .LifestyleTransient());

      container.Register(Component.For<IClockService>()
        //.AsWcfClient(new DefaultClientModel
        //{
        //  Endpoint = WcfEndpoint.BoundTo(Binding.WS_DUAL_HTTP).At(endpoint)
        //})
        .AsWcfClient(new DuplexClientModel
        {
          Endpoint = WcfEndpoint.BoundTo(Binding.WS_DUAL_HTTP).At(endpoint)
        }.Callback(container.Resolve<IClockServiceCallback>()))
        .LifestyleTransient());
    }
  }
}
