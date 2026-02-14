using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.GameObjects.Effects
{
    public class Heal : IEffect
    {
        private readonly int _healing;
        public Heal(int healing)
        {
            _healing = healing;
        }
        public void Consume(Entity entity)
        {
            entity.HP += _healing;
        }
    }
}
