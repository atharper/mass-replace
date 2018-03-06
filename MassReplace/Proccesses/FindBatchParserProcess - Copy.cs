using System;
using System.IO;

namespace MassReplace.Proccesses
{
  public class FindBatchParserProcess : IProcess
  {
    private Action<string> _updatePath;
    private Action<string> _output;

    public void Go(string dirPath)
    {
      var dirs = Directory.GetDirectories(dirPath);
      foreach (var dir in dirs)
      {
        Go(dir);
      }
      var files = Directory.GetFiles(dirPath);
      foreach (var file in files)
      {
        _updatePath?.Invoke(file);
        if (file.EndsWith(@".dll")) continue;
        if (file.EndsWith(@".exe")) continue;

        if (ProcessHelper.Find(file, "batchparser")) _output?.Invoke(file);
      }

      _updatePath?.Invoke("Done");
    }

    Action<string> IProcess.UpdatePath
    {
      set { _updatePath = value; }
    }

    Action<string> IProcess.Output
    {
      set { _output = value; }
    }
  }
}
