using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Items;

namespace TheFinalBattle.GameObjects.Entities.Heroes
{
    public class Vin : Entity
    {
        public override string Name { get; init; } = "Vin";
        public override int MaxHP { get; init; } = 15;
        public override Attack StandardAttack { get; init; } = new PowerfulShot();
        public Vin()
        {
            AttackModifier = new Atium(); 
        }

    }
}
