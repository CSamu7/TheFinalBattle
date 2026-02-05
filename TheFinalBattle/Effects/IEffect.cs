using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.Effects
{
    public interface IEffect
    {
        void Consume(Entity entity);
    }
}
