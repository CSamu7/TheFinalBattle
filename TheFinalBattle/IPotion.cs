namespace TheFinalBattle
{
    public interface IEffect
    {
        void Consume(Entity entity);
    }
    public class Heal : IEffect
    {
        private readonly int _healHP;
        public Heal(int healHP)
        {
            _healHP = healHP;
        }
        public void Consume(Entity entity)
        {
            entity.HP += _healHP;

            if (entity.HP > entity.MaxHP) entity.HP = entity.MaxHP;
        }
    }
}
