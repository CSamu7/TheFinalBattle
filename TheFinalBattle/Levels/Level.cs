using TheFinalBattle.Parties;

namespace TheFinalBattle.Levels
{
    public record Level(
        Party EnemyParty,
        List<ItemAmount> Rewards
    );
}
