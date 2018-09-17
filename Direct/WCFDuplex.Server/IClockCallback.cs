using System;
using System.ServiceModel;

namespace WCFDuplex.Server
{
  public interface IClockCallback
  {
    [OperationContract(IsOneWay = true)]
    void Update(DateTime datetime);
  }
}