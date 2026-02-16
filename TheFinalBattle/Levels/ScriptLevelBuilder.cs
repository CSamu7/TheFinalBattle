using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.Parties;

namespace TheFinalBattle.Levels
{
    public class ScriptLevelBuilder : ILevelBuilder
    {
        private readonly List<Level> _levels = new List<Level>()
        {
            new Level(
                EnemyParty: new Party
                {
                    Members = [new Fairy()],
                    Inventory = new Inventory{ Items=[ new (new Medicine()) ] }
                },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                EnemyParty: new Party
                {
                    Members = [new FireHog(), new FireHog()],
                },
                Rewards: [new(new Gun())]
            )
        };
        public List<Level> GetLevels() => _levels;
    }
}
