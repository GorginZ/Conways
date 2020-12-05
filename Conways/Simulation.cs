using System.Threading;

namespace Conways
{
  public class Simulation
  {
    public static void Run(IRender renderer, World world)
    {
      var programLock = new object();
      Thread simulation = new Thread(() =>
                {
                  while (true)
                  {
                    Thread.Sleep(300);
                    lock (programLock)
                    {
                      renderer.Render(world.GridClone());
                      world.Tick();
                    }
                  }
                }); simulation.Start();
    }
  }
}