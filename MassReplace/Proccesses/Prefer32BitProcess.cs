using System;
using System.IO;

namespace MassReplace.Proccesses
{
  public class Prefer32BitProcess : IProcess
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
        if (!file.EndsWith(@".csproj") && !file.EndsWith(@".vbproj")) continue;

        if (ProcessHelper.Go(file, @"<PlatformTarget>AnyCPU</PlatformTarget>", "<PlatformTarget>x86</PlatformTarget>")) _output?.Invoke(file);
        //if (ProcessHelper.Go(file, @"<Prefer32Bit>true</Prefer32Bit>", "<Prefer32Bit>false</Prefer32Bit>")) _output?.Invoke(file);
        if (ProcessHelper.Go(file, @"<Prefer32Bit>false</Prefer32Bit>", "")) _output?.Invoke(file);
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
