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
        public void Execute(Entity player)
        {
            int damage = _attack.CalculateDamage();
            _enemy.HP -= damage;

            if(_enemy.HP < 0) _enemy.HP = 0;

            Console.WriteLine($"{player.Name.ToUpper()} used {_attack.ToString().ToUpper()} on {_enemy.Name.ToUpper()}");
            Console.WriteLine($"{_attack.ToString().ToUpper()} dealt {damage} damage to {_enemy.Name.ToUpper()} ");
            Console.WriteLine($"{_enemy.Name.ToUpper()} is now at {_enemy.HP}/{_enemy.MaxHP}");
        }
    }
    public class RemoveGear : IEntityCommand
    {
        private Battle _battle;
        public RemoveGear(Battle battle)
        {
            _battle = battle;   
        }
        public void Execute(Entity entity)
        {
            Party party = _battle.GetPartyFor(entity);

            party.Inventory.AddItem(entity.Gear.ID);
            Console.WriteLine($"{entity.Name} has removed its {entity.Gear.Name}");
            entity.Gear = null;
        }
    }
}

