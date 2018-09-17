using System;
using System.ServiceModel;

namespace WCFDuplex.Server
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
  public class ClockService : IClockService
  {
    private readonly IClockCallback _callback;
    private Monitor _monitor;

    public ClockService()
    {
      if (OperationContext.Current != null)
        _callback = OperationContext.Current.GetCallbackChannel<IClockCallback>();
    }

    public void Connect()
    {
      if (_monitor != null)
        throw new FaultException(new FaultReason("Already registered!"));

      _monitor = new Monitor(_callback);
      _monitor.Start();
    }

    public void Disconnect()
    {
      if (_monitor == null)
        throw new FaultException(new FaultReason("Isn't registered!"));

      _monitor.Stop();
      _monitor = null;
    }

    public DateTime LifeSign()
    {
      return DateTime.Now;
    }
  }
}
