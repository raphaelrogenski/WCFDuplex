using System;
using WCFDuplex.Client.WCF;

namespace WCFDuplex.Client
{
  public class HorarioCallback : IClockServiceCallback
  {
    public void Update(DateTime datetime)
    {
      Console.Clear();
      Console.WriteLine(datetime.ToString("T"));
    }
  }
}
