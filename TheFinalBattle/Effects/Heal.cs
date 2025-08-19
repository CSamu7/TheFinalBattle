using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Effects
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

            if (entity.HP > entity.MaxHP) entity.HP = entity.MaxHP;
        }
    }
}
