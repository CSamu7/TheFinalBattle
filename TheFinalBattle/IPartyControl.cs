namespace TheFinalBattle
{
    public interface IPartyControl
    {
        public IEntityCommand SelectAction(Entity entity, Battle battle);
    }
}
