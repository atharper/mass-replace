using System;
using System.IO;

namespace MassReplace.Proccesses
{
  public class UpdateIgnoreAttributesProcess : IProcess
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
        if (!file.EndsWith(@".cs")) continue;

        if (ProcessHelper.Go(file, @"[Ignore]", "[Ignore(\"\")]")) _output?.Invoke(file);
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
