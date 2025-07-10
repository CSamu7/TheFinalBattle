namespace TheFinalBattle
{
    public interface IPotion
    {
        void Consume(Entity entity);
    }
    public class Heal : IPotion
    {
        public void Consume(Entity entity)
        {
            entity.HP += 10;

            if (entity.HP > entity.MaxHP) entity.HP = entity.MaxHP;
        }
    }
}
