using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.DTO
{
    public class EntityDTO
    {
        public required int Id { get; init; }
        public int? IdGear { get; init; }
        public int? IdDefensiveModifier { get; init; }
    }
    public static class EntityDTOExtensions
    {
        public static Entity? Map(this EntityDTO entity)
        {
            EntitiesList entities = new EntitiesList();
            ItemList itemList = new ItemList();
            DefensiveModifierList modifiersList = new DefensiveModifierList();

            Entity? enemy = entities.GetByID(entity.Id);

            if (enemy is null) return null;

            if (entity.IdGear is not null)
                enemy.Gear = (Gear)itemList.GetByID(entity.IdGear.Value);

            if (entity.IdDefensiveModifier is not null)
                enemy.DefensiveModifier = modifiersList.GetByID(entity.IdDefensiveModifier.Value);

            return enemy;
        }
    }
}
