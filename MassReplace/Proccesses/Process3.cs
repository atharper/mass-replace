using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MassReplace
{
  public class Process3
  {
    public void TestGo()
    {
      Go(@"D:\CodeNet\Icecream\MasterSln\Caselle.Aad\Caselle.Aad.MVC\Caselle.Aad.MVC.csproj", "DevExpress.DevExpress.Data.v12.2.dll", @"DevExpress\DevExpress.Data.v12.2.dll");
    }

    public void Go()
    {
      var path = @"D:\CodeNet\Connect\";
      Go(path);
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
        if (!file.EndsWith(@".csproj")) continue;
        Go(file, @"<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>", "<TargetFrameworkVersion>v4.5</TargetFrameworkVersion>");
      }
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
