using TheFinalBattle.Items;

namespace TheFinalBattle.Generators
{
    public record Level(
        Party Enemies,
        List<SlotInventory> Rewards
    );
    public interface ILevelGenerator
    {
        public Level GenerateLevel(Battles battles);
    }
    public class ScriptedLevelGenerator : ILevelGenerator
    {
        public Dictionary<int, List<SlotInventory>> Rewards { get; init; } = new Dictionary<int, List<SlotInventory>>()
        {
            {1, [new SlotInventory(new Medicine())] },
            {3, [new SlotInventory(new LuminaSaber())]},
            {5, [new SlotInventory(new KolossSword())]},
            {6, [new SlotInventory(new Medicine(), 2)] }
        };

        public Level GenerateLevel(Battles battles)
        {
            ScriptedEnemiesGenerator enemiesGenerator = new ScriptedEnemiesGenerator(battles.EnemyControl);
            Party enemy = enemiesGenerator.GetPartyEnemy(battles);

            List<SlotInventory> rewards = Rewards.GetValueOrDefault(battles.battleNumber, []);

            return new Level(enemy, rewards);
        }
    }
}
