using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassReplace.Proccesses
{
  public interface IProcess
  {
    void Go(string path);
    Action<string> UpdatePath { set; }
    Action<string> Output { set; }
  }
}
