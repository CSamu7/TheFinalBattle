using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.AttackModifiers
{
    public class AttackModifiersList : IGameObjectList<AbstractAttackModifier>
    {
        private Dictionary<int, AbstractAttackModifier> _defensiveModifiers = new()
        {
            {1, new Atium() },
            {2, new ObjectSight() },
            {3, new FrostCape() },
            {4, new MagmaStone() },
        };
        public AbstractAttackModifier? GetByID(int id)
        {
            _defensiveModifiers.TryGetValue(id, out var modifier);
            return modifier;
        }
    }
}
