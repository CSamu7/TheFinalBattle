namespace TheFinalBattle
{
    public class EnemyFactory
    {
        private IPartyControl _partyControl;
        public EnemyFactory(IPartyControl partyControl) { 
            _partyControl = partyControl;
        }
        public List<Entity>? CreateEnemies(int battleNumber)
        {
            return battleNumber switch
            {
                1 => new List<Entity> { new Skeleton()},
                2 => new List<Entity> { new Skeleton(), new Skeleton()},
                3 => new List<Entity> { new Skeleton(), new TheUncodedOne() },
                _ => null
            };
        }
    }
}
