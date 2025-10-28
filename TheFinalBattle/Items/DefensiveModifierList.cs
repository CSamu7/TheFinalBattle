namespace TheFinalBattle.Items
{
    public class DefensiveModifierList
    {
        private readonly List<IDefensiveModifier> _defensiveModifiers = new List<IDefensiveModifier>
        {
            new AtiumBead(), new ObjectSight(), new KingFrostCape()
        };

        public IDefensiveModifier? GetByName(string name) => 
            _defensiveModifiers.Where(modifier => modifier.Name == name).FirstOrDefault(); 
    }
}
