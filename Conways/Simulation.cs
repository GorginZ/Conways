using System.Threading;

namespace Conways
{
  public static class Simulation
  {
    public static void Run(IControl controller, IRender renderer, World world)
    {
      var controllerLock = new object();

      Thread setControlCommand = new Thread(() =>
        {
          while (controller.Command != ControlCommand.End)
          {
            controller.ReadCommand();
            lock (controllerLock)
            {
              controller.SetCurrentCommand();
            }
          }
        }); setControlCommand.Start();

      Thread renderSimulation = new Thread(() =>
      {
        while (controller.Command != ControlCommand.End)
        {
          Thread.Sleep(300);
          lock (controllerLock)
          {
            renderer.Render(world.CloneGrid(), controller.Command);
            if (controller.Command == ControlCommand.Running)
            {
              world.Tick();
            }
          }
        }
      });
      renderSimulation.Start();
    }
  }
}