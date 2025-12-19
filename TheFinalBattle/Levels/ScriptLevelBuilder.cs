using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses.Enemies;

namespace TheFinalBattle.Levels
{
    public class ScriptLevelBuilder : ILevelBuilder
    {
        private readonly List<Level> _levels = new List<Level>()
        {
            new Level(
                Enemies: [new Pixie()],
                EnemyInventory: new Inventory{ Items=[ new (new Medicine()) ] },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                Enemies: [new Mothman(), new Mothman()],
                EnemyInventory: new(),
                Rewards: [new(new Gun())]
            )
        };
        public List<Level> GetLevels() => _levels;
    }
}
