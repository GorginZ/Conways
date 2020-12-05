namespace Conways
{
  public class Simulation
  {
    private IRender _renderer;
    private World _world;
    public Simulation(IRender renderer, World world)
    {
      _world = world;
      _renderer = renderer;

    }
    public static void Run(IRender renderer, World world)
    {
      Thread render = new Thread(() =>
                {
                  // while (userInput.Command != CurrentCommand.Stop)
                  while (true)
                  {
                    Thread.Sleep(300);
                    lock (programLock)
                    {
                      renderer.Render(world.Tick());
                      world.Tick();

                    }
                  }
                }); render.Start();

    }
  }
}