using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class DefensiveModifierList : IGameObjectList<AbstractDefensiveModifier>
    {
        private Dictionary<int, AbstractDefensiveModifier> _defensiveModifiers = new()
        {
            {1, new AtiumBead() },
            {2, new ObjectSight() },
            {3, new KingFrostCape() }
        };
        public AbstractDefensiveModifier? GetByID(int id)
        {
            _defensiveModifiers.TryGetValue(id, out var modifier);
            return modifier;
        }

    }
}
