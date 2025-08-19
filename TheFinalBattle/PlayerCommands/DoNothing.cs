using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.PlayerCommands
{
    public class DoNothing : IEntityCommand
    {
        public void Execute(Entity entity)
        {
            Console.WriteLine($"{entity.Name} did NOTHING");
        }
        public override string ToString()
        {
            return "Do nothing";
        }
    }
}
