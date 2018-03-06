using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MassReplace
{
  public class Process7
  {
    private readonly Action<string> _appendNote;

    public Process7(Action<string> appendNote)
    {
      _appendNote = appendNote;
    }

    public void Go()
    {
      var path = @"D:\CodeNet\Connect\";
      Go(path);

      _appendNote("Done");

    }

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

        if (Find(file, "AddGlSearch"))
        {
          _appendNote(file + Environment.NewLine);
        }
      }
    }

    public bool Find(string filePath, string find)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      return Regex.IsMatch(text, find);
    }

    public void Go(string filePath, string find, string replace)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      if (!Regex.IsMatch(text, find)) return;

      text = Regex.Replace(text, find, replace);

      File.WriteAllText(filePath, text);
    }
  }
}
