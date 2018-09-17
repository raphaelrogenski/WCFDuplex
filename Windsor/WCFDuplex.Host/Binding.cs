using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WCFDuplex.Host
{
  public class Binding
  {
    private static readonly int MAX_BYTES = 2147483647;
    private static readonly TimeSpan RECEIVE_TIMEOUT = new TimeSpan(0, 10, 0);
    private static readonly TimeSpan SEND_TIMEOUT = new TimeSpan(0, 10, 0);
    private static readonly TimeSpan OPEN_TIMEOUT = new TimeSpan(0, 2, 0);
    private static readonly TimeSpan CLOSE_TIMEOUT = new TimeSpan(0, 0, 20);
    private static readonly TimeSpan INACTIVE_TIMEOUT = new TimeSpan(0, 1, 10);

    public static readonly BasicHttpBinding BASIC_HTTP = new BasicHttpBinding
    {
      ReceiveTimeout = RECEIVE_TIMEOUT,
      SendTimeout = SEND_TIMEOUT,
      OpenTimeout = OPEN_TIMEOUT,
      CloseTimeout = CLOSE_TIMEOUT,
      Security = new BasicHttpSecurity { Mode = BasicHttpSecurityMode.None },
      TransferMode = TransferMode.Buffered,
      MaxBufferPoolSize = MAX_BYTES,
      MaxBufferSize = MAX_BYTES,
      MaxReceivedMessageSize = MAX_BYTES,
      ReaderQuotas = new XmlDictionaryReaderQuotas
      {
        MaxDepth = MAX_BYTES,
        MaxArrayLength = MAX_BYTES,
        MaxStringContentLength = MAX_BYTES,
        MaxNameTableCharCount = MAX_BYTES,
        MaxBytesPerRead = MAX_BYTES
      }
    };

    public static readonly NetTcpBinding NET_TCP = new NetTcpBinding
    {
      ReceiveTimeout = RECEIVE_TIMEOUT,
      SendTimeout = SEND_TIMEOUT,
      OpenTimeout = OPEN_TIMEOUT,
      CloseTimeout = CLOSE_TIMEOUT,
      MaxConnections = 100,
      PortSharingEnabled = true,
      ListenBacklog = 100,
      ReliableSession =
        new OptionalReliableSession
        {
          Enabled = false,
          Ordered = true,
          InactivityTimeout = INACTIVE_TIMEOUT
        },
      Security = new NetTcpSecurity { Mode = SecurityMode.None },
      TransactionFlow = false,
      TransactionProtocol = TransactionProtocol.Default,
      TransferMode = TransferMode.Buffered,
      MaxBufferPoolSize = MAX_BYTES,
      MaxBufferSize = MAX_BYTES,
      MaxReceivedMessageSize = MAX_BYTES,
      ReaderQuotas = new XmlDictionaryReaderQuotas
      {
        MaxDepth = MAX_BYTES,
        MaxArrayLength = MAX_BYTES,
        MaxStringContentLength = MAX_BYTES,
        MaxNameTableCharCount = MAX_BYTES,
        MaxBytesPerRead = MAX_BYTES
      }
    };

    public static readonly WSDualHttpBinding WS_DUAL_HTTP = new WSDualHttpBinding
    {
      ReceiveTimeout = new TimeSpan(0, 0, 10),
      SendTimeout = new TimeSpan(0, 0, 10),
      OpenTimeout = new TimeSpan(0, 0, 10),
      CloseTimeout = new TimeSpan(0, 0, 10),
      Security = new WSDualHttpSecurity { Mode = WSDualHttpSecurityMode.None },
      MaxBufferPoolSize = MAX_BYTES,
      MaxReceivedMessageSize = MAX_BYTES,
      ReaderQuotas = new XmlDictionaryReaderQuotas
      {
        MaxDepth = MAX_BYTES,
        MaxArrayLength = MAX_BYTES,
        MaxStringContentLength = MAX_BYTES,
        MaxNameTableCharCount = MAX_BYTES,
        MaxBytesPerRead = MAX_BYTES
      }
    };
  }
}
