using TheFinalBattle.Items;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.PlayableClasses.Heroes
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
            DefensiveModifier = new AtiumBead(); //10% de esquivar un ataque.
        }

    }
}
