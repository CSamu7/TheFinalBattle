using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.DefensiveModifiers
{
    public class DefensiveModifierList : IGameObjectList<AbstractAttackModifier>
    {
        private Dictionary<int, AbstractAttackModifier> _defensiveModifiers = new()
        {
            {1, new AtiumBead() },
            {2, new ObjectSight() },
            {3, new KingFrostCape() }
        };
        public AbstractAttackModifier? GetByID(int id)
        {
            _defensiveModifiers.TryGetValue(id, out var modifier);
            return modifier;
        }

    }
}
