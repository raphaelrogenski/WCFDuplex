using System;
using System.Configuration;
using System.ServiceModel.Description;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WCFDuplex.Server;

namespace WCFDuplex.Host
{
  public class Container : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.AddFacility<WcfFacility>(r => { r.CloseTimeout = TimeSpan.Zero; });

      var endpoint = ConfigurationManager.AppSettings.Get("Endpoint_Service");

      var returnFaults = new ServiceDebugBehavior
      {
        IncludeExceptionDetailInFaults = true,
        HttpHelpPageEnabled = true
      };

      container.Register(Component.For<IServiceBehavior>().Instance(returnFaults));

      container.Register(
        Component.For<IClockService>()
        .ImplementedBy<ClockService>()
        .Named("ClockService")
        .LifestyleTransient()
        .AsWcfService(new DefaultServiceModel()
          .AddBaseAddresses(endpoint)
          .PublishMetadata(mex => { mex.EnableHttpGet(); })
          .AddEndpoints(WcfEndpoint
            .ForContract<IClockService>()
            .BoundTo(Binding.WS_DUAL_HTTP).At(endpoint)
            )
          )
        );

      
    }
  }
}
