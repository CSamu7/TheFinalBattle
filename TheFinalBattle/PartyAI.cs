namespace TheFinalBattle
{
    public class PartyAI : IPartyControl
    {
        private Random rnd = new Random();
        public void Act(Entity entity, Battle battle) {
            IEntityCommand action = SelectAction(entity, battle);

            action.Execute(entity);
        }
        public IEntityCommand SelectAction(Entity entity, Battle battle)
        {
            while (true)
            {
                Party enemies = battle.GetEnemyPartyFor(entity);

                EntityActions randomAction = SelectRandomAction();

                IEntityCommand? command = randomAction switch {
                    EntityActions.DoNothing => new DoNothing(),
                    EntityActions.Attack => new AttackSelectorAI(enemies).GetAttack(entity),
                    EntityActions.UseItem => new ItemSelectorAI(entity, battle).GetItem()
                };

                if (command is not null) return command;
            }
        }
        private EntityActions SelectRandomAction()
        {
            double probability = rnd.NextDouble();

            return probability switch
            {
                < .01 => EntityActions.DoNothing,
                < .25 => EntityActions.UseItem,
                _ => EntityActions.Attack,
            };
        }
    }
    public enum EntityActions { DoNothing, Attack, UseItem };
}
