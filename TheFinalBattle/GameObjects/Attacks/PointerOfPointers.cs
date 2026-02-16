namespace TheFinalBattle.GameObjects.Attacks
{
    public class PointerOfPointers : Attack
    {
        public override string Name => "Pointer of pointers";
        public override DamageType DamageType => DamageType.Decoding;
        public override AttackData CalculateAttack() => new AttackData(3, DamageType, .70);
    }
}
