using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses.Enemies;

namespace TheFinalBattle.Levels
{
    public class ScriptLevelBuilder : ILevelBuilder
    {
        public List<Level> Levels = new List<Level>()
        {
            new Level(
                Enemies: [new Pixie()],
                EnemyInventory: new Inventory{ Items=[ new( new Medicine()) ] },
                Rewards: [new(new Medicine())]
            ),
            new Level(
                Enemies: [new Mothman(), new Mothman()],
                EnemyInventory: new(),
                Rewards: [new(new Gun())]
            )
        };

        public Level GetLevel(Battles battles)
        {
            return battles.battleNumber > Levels.Count
                ? new Level([], new(), [])
                : Levels.ElementAt(battles.battleNumber - 1);
        }
    }
}
