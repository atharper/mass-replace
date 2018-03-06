using System;
using System.IO;

namespace MassReplace.Proccesses
{
  public class UpdateYearProcess : IProcess
  {
    private Action<string> _updatePath;
    private Action<string> _output;

    public void Go(string dirPath)
    {
      GoInternal(dirPath);
      _updatePath?.Invoke("Done");
    }

    private void GoInternal(string dirPath)
    {
      var dirs = Directory.GetDirectories(dirPath);
      foreach (var dir in dirs)
      {
        if (dir.Contains("[")) continue;
        GoInternal(dir);
      }
      var files = Directory.GetFiles(dirPath);
      foreach (var file in files)
      {
        if (file.Contains("[")) continue;
        if (file.Contains("Script")) continue;
        if (file.EndsWith(@".dll")) continue;
        if (file.EndsWith(@".exe")) continue;
        if (file.EndsWith(@".png")) continue;
        if (file.EndsWith(@".7z")) continue;
        if (file.Contains(@"\\Log\\")) continue;
        if (file.Contains(@"\\Logs\\")) continue;
        _updatePath?.Invoke(file);

        var found = false;
        for (int i = 0; i < 10; i++)
        {
          var yearToFind = 2020 - i;
          var newYear = 2021 - i;
          if (!ProcessHelper.Find(file, "/" + yearToFind)) continue;
          ProcessHelper.Go(file, "/" + yearToFind, "/" + newYear);

          if (!found)
          {
            found = true;
            _output?.Invoke(file);
          }
          _output?.Invoke($"{yearToFind} => {newYear}");
        }
      }
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
