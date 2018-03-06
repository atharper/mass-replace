using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MassReplace
{
  public class Process
  {
    private string _test;
    public void TestGo()
    {
      Go(@"D:\CodeNet\Icecream\MasterSln\Caselle.Aad\Caselle.Aad.MVC\Caselle.Aad.MVC.csproj",
        "DevExpress.DevExpress.Data.v12.2.dll", @"DevExpress\DevExpress.Data.v12.2.dll");
    }

    public void Go()
    {
      _test = string.Empty;
      Go(@"D:\Codenet\Connect3\MasterSln");
      Clipboard.SetText(_test);
    }

    public void Go(string dirPath)
    {
      var sb = new StringBuilder();
      var dirs = Directory.GetDirectories(dirPath);
      foreach (var dir in dirs)
      {
        Go(dir);
      }
      var files = Directory.GetFiles(dirPath);
      foreach (var file in files)
      {
        if (!file.EndsWith(@".vbproj")) continue;

        {
          var reader = File.OpenText(file);

          var text = reader.ReadToEnd();
          reader.Close();

          if (!DoesFileHave(text, "895376BD-D028-49F4-8084-56468D19AD88") &&
            !DoesFileHave(text, "3849b3c4-6caf-4692-aed4-2629277ca81b"))
          {
            continue;
          }
          var needsMention = !DoesFileHave(text, "8ca4ffe8-0053-43f9-96f0-59058aaabd74");
          if (needsMention) _test += "\n" + file;
        }
      }

    }

    public
      void Go
      (string filePath, string find, string replace)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      if (!Regex.IsMatch(text, find)) return;

      text = Regex.Replace(text, find, replace);

      File.WriteAllText(filePath, text);
    }


    private bool DoesFileHave(string text, string key)
    {
      return Regex.IsMatch(text, key);
    }
  }
}