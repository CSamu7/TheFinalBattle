using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.Items
{
    public interface IUseItemCommand
    {
        public void Use(Entity entity);
    }
}
