using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.Entities.Heroes
{
    public class Vin : Entity
    {
        public override int Id { get; init; } = 2;
        public override string Name { get; init; } = "Vin";
        public override int MaxHP { get; init; } = 15;
        public override IAttack StandardAttack { get; init; } = new Push();
        public Vin()
        {
            Gear = new KolossSword();
            AttackModifier = new Atium(); //10% de esquivar un ataque.
        }

    }
}
