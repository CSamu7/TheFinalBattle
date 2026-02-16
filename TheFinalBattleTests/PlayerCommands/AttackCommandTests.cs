using TheFinalBattle.GameObjects.AttackModifiers;
using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.GameObjects.Entities.Heroes;
using TheFinalBattle.PlayerCommands;
using TheFinalBattle.Tests.AttackModifierTests;

namespace TheFinalBattle.Tests.PlayerCommands
{
    public class AttackCommandTests
    {
        [Fact]
        public void If_attacker_has_defensive_modifier_then_dont_modify_attack()
        {
            TestWeapon testWeapon = new TestWeapon(DamageType.Ice);
            Entity attacker = new Vin { AttackModifier = new FrostCape() };
            Entity defensor = new Pixie { MaxHP = 10, HP = 10 };
            AttackCommand sut = new AttackCommand(testWeapon, defensor);

            sut.Execute(attacker);

            Assert.Equal(5, defensor.HP);
        }

        [Fact]
        public void If_defensor_has_ofensive_modifier_then_dont_modify_attack()
        {
            TestWeapon testWeapon = new TestWeapon(DamageType.Physical);
            Entity attacker = new Vin();
            Entity defensor = new Pixie { MaxHP = 10, HP = 10, AttackModifier = new MagmaStone() };
            AttackCommand sut = new AttackCommand(testWeapon, defensor);

            sut.Execute(attacker);

            Assert.Equal(5, defensor.HP);
        }
    }
}
