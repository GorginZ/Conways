using System;
namespace Conways
{
  public class ConsoleController : IControl
  {
    private ConsoleKey InputKey;
    public ControlCommand Command { get; set; }
    public void SetInputKey() => InputKey = Console.ReadKey(true).Key;

    public void SetCurrentCommand()
    {
      SetInputKey();
      if (InputKey == ConsoleKey.Escape)
      {
        Command = ControlCommand.End;
      }
      if (InputKey == ConsoleKey.Spacebar)
      {
        Command = Command == ControlCommand.Running ? ControlCommand.Paused : ControlCommand.Running;
      }
    }
  }
}