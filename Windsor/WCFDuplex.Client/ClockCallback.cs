using System;
using System.Threading;
using WCFDuplex.Server;

namespace WCFDuplex.Client
{
  public class ClockCallback : IClockServiceCallback
  {
    public void Update(DateTime datetime)
    {
      Console.Clear();
      Console.WriteLine(datetime.ToString("T"));
      Thread.Sleep(100);
    }
  }
}
