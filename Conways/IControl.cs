namespace Conways
{
  public interface IControl
  {
    ControlCommand Command { get; set; }

    void SetCurrentCommand();
  }
}