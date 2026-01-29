using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class DefensiveModifierList : IGameObjectList<AbstractDefensiveModifier>
    {
        private readonly List<AbstractDefensiveModifier> _defensiveModifiers =
            [new AtiumBead(), new ObjectSight(), new KingFrostCape()];
            
        public AbstractDefensiveModifier? GetByID(int id) => 
            _defensiveModifiers.Where(modifier => modifier.Id == id).FirstOrDefault(); 
    }
}
