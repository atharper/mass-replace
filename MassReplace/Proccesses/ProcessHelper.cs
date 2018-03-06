using System.IO;
using System.Text.RegularExpressions;

namespace MassReplace.Proccesses
{
  public static class ProcessHelper
  {
    public static bool Find(string filePath, string find)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      return Regex.IsMatch(text, find);
    }

    public static bool Go(string filePath, string find, string replace)
    {
      var reader = File.OpenText(filePath);

      var text = reader.ReadToEnd();
      reader.Close();
      if (!text.Contains(find)) return false;

      text = text.Replace(find, replace);

      File.WriteAllText(filePath, text);

      return true;
    }
  }
}
