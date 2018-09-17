using System;
using System.ServiceModel;

namespace WCFDuplex.Server
{
  [ServiceContract(CallbackContract = typeof(IClockCallback))]
  public interface IClockService
  {
    [OperationContract(IsOneWay = true)]
    void Connect();

    [OperationContract(IsOneWay = true)]
    void Disconnect();

    [OperationContract]
    DateTime LifeSign();
  }
}
