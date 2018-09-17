using System;
using System.Threading;

namespace WCFDuplex.Server
{
  public class Monitor
  {
    private readonly IClockCallback _callback;
    private readonly Thread _thread;
    private bool status = false;

    public Monitor(IClockCallback callback)
    {
      _callback = callback;
      _thread = new Thread(Loop);
    }

    public void Start()
    {
      status = true;
      _thread.Start();
    }

    public void Stop()
    {
      status = false;
      _thread.Interrupt();
    }

    private void Loop()
    {
      while (status)
      {
        Execute();
        Thread.Sleep(1000);
      }
    }

    private void Execute()
    {
      try
      {
        _callback.Update(datetime);
      }
      catch (Exception e)
      {
        status = false;
      }
    }
  }
}