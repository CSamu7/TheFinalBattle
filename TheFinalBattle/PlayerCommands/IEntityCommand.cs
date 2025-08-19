using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.PlayerCommands
{
    public interface IEntityCommand
    {
        void Execute(Entity entity);
    }
}

