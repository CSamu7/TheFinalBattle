using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;

namespace TheFinalBattle.DTO
{
    public class SlotInventoryDTO
    {
        public required string Name { get; init; }
        public required int Amount { get; init; }
    }
    public class LevelDTO
    {
        public required List<EntityDTO> Enemies { get; init; }
        public required List<SlotInventoryDTO> EnemyInventory { get; init; }
        public required List<SlotInventoryDTO> Rewards { get; init; }
        public Level Parse()
        {
            ItemsList itemList = new ItemsList();

            List<SlotInventory> items = EnemyInventory.Select(item => new SlotInventory(itemList.GetByName(item.Name), item.Amount)).ToList();
            List<SlotInventory> rewards = Rewards.Select(item => new SlotInventory(itemList.GetByName(item.Name), item.Amount)).ToList();
            List<Entity> enemies = new List<Entity>();

            foreach (EntityDTO enemyJSON in Enemies)
            {
                Entity enemy = enemyJSON.Parse();
                enemies.Add(enemy);
            }

            return new Level(enemies, new Inventory { Items = items}, rewards);
        }
    }
}