namespace TheFinalBattle
{
    public interface IDefensiveModifier
    {
        public string Message { get; init; }
        public AttackData AdjustAttack(AttackData attackData);
    }
    public class StoneArmor : IDefensiveModifier
    {
        public string Message { get; init; } = "STONE ARMOR reduced the attack by 1 point";
        public AttackData AdjustAttack(AttackData attackData)
        {
            return attackData with { Damage = 1 };
        }
    }
}
