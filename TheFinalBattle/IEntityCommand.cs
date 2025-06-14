using Utils;
namespace TheFinalBattle
{
    public interface IEntityCommand
    {
        void Execute(Entity entity);
    }
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
    public class AttackCommand : IEntityCommand
    {
        private IAttack _attack;
        private Entity _enemy;
        public AttackCommand(IAttack attack, Entity enemy)
        {
            _attack = attack;
            _enemy = enemy;
        }
        public void Execute(Entity entity)
        {
            int damage = _attack.CalculateDamage();
            _enemy.HP -= damage;

            Console.WriteLine($"{entity.Name.ToUpper()} used {_attack.ToString().ToUpper()} on {_enemy.Name.ToUpper()}");
            Console.WriteLine($"{_attack.ToString().ToUpper()} dealt {damage} damage to {_enemy.Name.ToUpper()} ");
            Console.WriteLine($"{_enemy.Name.ToUpper()} is now at {_enemy.HP}/{_enemy.MaxHP}");
        }
    }
    public class UseItem : IEntityCommand
    {
        public Item Item;
        private Battle _battle;
        public override string ToString()
        {
            return "Use item";
        }
        public UseItem(Item item, Battle battle)
        {
            Item = item;
            _battle = battle;
        }
        public void Execute(Entity entity)
        {
            Console.WriteLine($"{entity.Name} has used {Item.Name}");
            Item.Effect.Use(entity);
            DisplayItemMessage(entity.Name);
            Party party = _battle.GetPartyFor(entity);
            party.Items.Remove(Item);
        }
        private void DisplayItemMessage(string name)
        {
            string message = Item.Type switch
            {
                Type.Health => $"{name} feels more healthy!"
            };

            ConsoleUtils.WriteLine(message, ConsoleColor.Green);
        }
    }
}

