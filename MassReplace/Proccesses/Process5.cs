using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MassReplace
{
  public class Process5
  {
    public void Go()
    {
      var path = @"D:\CodeNet\Connect\";
      Go(path);
    }

    public string Go(string dirPath)
    {
      var dirs = Directory.GetDirectories(dirPath);
      foreach (var dir in dirs)
      {
        Go(dir);
      }
      var files = Directory.GetFiles(dirPath);

      var sb = new StringBuilder();
      foreach (var file in files)
      {
        if (!file.EndsWith(@".sln")) continue;

        var value = Go(file, @"Caselle.Aa0.Biz.Common.Tests.vbproj");
        if (value == null) continue;
        sb.AppendLine(value);
      }

      return sb.ToString();
    }

    public string Go(string filePath, string find)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      if (!Regex.IsMatch(text, find)) return null;

      return filePath;
    }
  }
}
