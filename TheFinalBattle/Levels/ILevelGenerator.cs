using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.Generators
{
    public record Level(
        List<Entity> Enemies,
        Inventory EnemyInventory,
        List<SlotInventory> Rewards
    );
    public interface ILevelBuilder
    {
        public Level GetLevel(Battles battles);
    }
}
