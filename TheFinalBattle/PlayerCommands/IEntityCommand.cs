using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.PlayerCommands
{
    public interface IEntityCommand
    {
        void Execute(Entity currentEntity);
    }
}

