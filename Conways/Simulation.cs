using System;
using System.Threading;

namespace Conways
{
  public static class Simulation
  {
    public static void Run(IControl controller, IRender renderer, World world)
    {
      var programLock = new object();

      Thread setControlCommand = new Thread(() =>
        {
          while (controller.Command != ControlCommand.End)
          {
            controller.SetCurrentCommand();
          }
        }); setControlCommand.Start();

      Thread simulation = new Thread(() =>
      {
        while (controller.Command != ControlCommand.End)
        {
          Thread.Sleep(300);
          lock (programLock)
          {
            renderer.Render(world.CloneGrid(), controller.Command);
            if (controller.Command == ControlCommand.Running)
            {
              world.Tick();
            }
          }
        }
      });
      simulation.Start();
    }
  }
}