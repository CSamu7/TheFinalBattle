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
                EnemyParty: new Party
                {
                    Members = [new Pixie()],
                    Inventory =  new Inventory{ Items=[ new (new Medicine()) ] }
                },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                EnemyParty: new Party
                {
                    Members = [new Mothman(), new Mothman()],
                },
                Rewards: [new(new Gun())]
            )
        };
        public List<Level> GetLevels() => _levels;
    }
}
