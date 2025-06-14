namespace TheFinalBattle
{
    public interface IPartyControl
    {
        public void Act(Entity entity, Battle battle);
        public IEntityCommand SelectAction(Entity entity, Battle battle);
    }
}
