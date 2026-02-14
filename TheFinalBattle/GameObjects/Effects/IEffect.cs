using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.Effects
{
    public interface IEffect
    {
        void Consume(Entity entity);
    }
}
