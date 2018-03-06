using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MassReplace
{
  public class Process2
  {
    public void TestGo()
    {
      Go(@"D:\CodeNet\Icecream\MasterSln\Caselle.Aad\Caselle.Aad.MVC\Caselle.Aad.MVC.csproj", "DevExpress.DevExpress.Data.v12.2.dll", @"DevExpress\DevExpress.Data.v12.2.dll");
    }

    public void Go()
    {
      var path = @"D:\CodeNet\Clarity.147\MasterSln";
      Go(path);
      Clipboard.SetText(_text);
    }

    private string _text = string.Empty;

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
        if (!file.EndsWith(@".sln")) continue;
        Go(file, @"Aad.MVC", string.Empty);
      }
    }

    public void Go(string filePath, string find, string replace)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      if (!Regex.IsMatch(text, find)) return;

      _text += filePath;
      _text += Environment.NewLine;
      
    }
  }
}
