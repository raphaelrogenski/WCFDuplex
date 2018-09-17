using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFDuplex.Host
{
  class Program
  {
    static void Main(string[] args)
    {
      var scope = new Scope();
      scope.Execute();

      Console.WriteLine("Running...");
      Console.ReadKey();
    }
  }
}
