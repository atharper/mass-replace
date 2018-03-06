using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MassReplace
{
  public class Process6
  {
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
        if (!file.EndsWith(@".cs")) continue;

        Go(file, "AddSearch\\((.*?), \\\"(.*?)\\\", (.*?)\\);", "AddSearch($1, $3, Properties.Resources.$2);");
        //if (!Find(file, "Prefer32Bit"))
        //{
        //  Go(file, @"<PlatformTarget>x64</PlatformTarget>", "<PlatformTarget>AnyCPU</PlatformTarget><Prefer32Bit>false</Prefer32Bit>");
        //}
        //else
        //{
        //  Go(file, @"<PlatformTarget>x64</PlatformTarget>", "<PlatformTarget>AnyCPU</PlatformTarget>");
        //  Go(file, @"<Prefer32Bit>true</Prefer32Bit>", "<Prefer32Bit>false</Prefer32Bit>");
        //}
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
