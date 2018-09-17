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
      _callback = OperationContext.Current.GetCallbackChannel<IClockCallback>();
    }

    public void Connect()
    {
      if (_monitor != null)
        throw new FaultException(new FaultReason("Já está registrado!"));

      _monitor = new Monitor(_callback);
      _monitor.Start();
    }

    public void Disconnect()
    {
      if (_monitor == null)
        throw new FaultException(new FaultReason("Não está registrado!"));

      _monitor.Stop();
      _monitor = null;
    }

    public DateTime LifeSign()
    {
      return DateTime.Now;
    }
  }
}
