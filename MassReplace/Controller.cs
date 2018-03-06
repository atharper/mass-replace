using MassReplace.Proccesses;
using System;
using System.Threading;

namespace MassReplace
{
  public class Controller
  {
    public const string Folder = @"\\caselle2\DATA2\QA\TestComplete Projects";
    public IProcess Process = new UpdateYearProcess();

    public static Controller Create()
    {
      return new Controller();
    }

    public Controller SetOutput(Action<string> output)
    {
      Process.Output = output;
      return this;
    }

    public Controller SetUpdatePath(Action<string> output)
    {
      Process.UpdatePath = output;
      return this;
    }

    public void Go()
    {
      new Thread(() => Process.Go(Folder)).Start();
    }
  }
}
