namespace TheFinalBattle.Items
{
    public class DefensiveModifierList : IObjectList<IDefensiveModifier>
    {
        private readonly List<IDefensiveModifier> _defensiveModifiers = new List<IDefensiveModifier>
        {
            new AtiumBead(), new ObjectSight(), new KingFrostCape()
        };
        public IDefensiveModifier? GetByID(int id) => 
            _defensiveModifiers.Where(modifier => modifier.Id == id).FirstOrDefault(); 
    }
}
