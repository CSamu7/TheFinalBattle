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
                    Members = [new Skeleton()],
                },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                EnemyParty: new Party
                {
                    Members = [new Archer(), new Fairy { Gear = new IceStaff() }],
                    Inventory = new Inventory{ Items=[ new (new Medicine()) ] }
                },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                EnemyParty: new Party
                {
                    Members = [new IceGolem()],
                },
                Rewards : []
                ),
            new Level(
                EnemyParty: new Party
                {
                    Members = [new FireHog(), new FireHog()],
                    Inventory = new Inventory {Items = [new(new Medicine())]}
                },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                EnemyParty: new Party
                {
                    Members = [new Undefined(), new Archer()],
                    Inventory = new Inventory {Items = [new(new Medicine()) ]}
                },
                Rewards: [new(new Debugger())]
            ),

            new Level(
                EnemyParty: new Party
                {
                    Members = [new TheUncodedOne()],
                    Inventory = new Inventory {Items = [new(new Medicine(), 2) ]}
                },
                Rewards: []
            )
        };
        public List<Level> GetLevels() => _levels;
    }
}
