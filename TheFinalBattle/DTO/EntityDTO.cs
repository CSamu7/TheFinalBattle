using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.DTO
{
    public class EntityDTO
    {
        public string Name { get; init; }
        public string? Gear { get; init; }
        public string? DefensiveModifier { get; init; }
        public Entity Parse()
        {
            ItemsList itemsList = new ItemsList();
            DefensiveModifierList modifiersList = new DefensiveModifierList();

            Gear? gear = (Gear?)itemsList.GetByName(Gear ?? "");
            IDefensiveModifier? defensiveModifier = modifiersList.GetByName(DefensiveModifier ?? "");

            Entity enemy = EntitiesList.GetEntityByName(Name);
            enemy.Gear = gear;
            enemy.DefensiveModifier = defensiveModifier;

            return enemy;
        }
    }
}
