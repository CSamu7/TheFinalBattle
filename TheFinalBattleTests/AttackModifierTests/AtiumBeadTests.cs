using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.Tests.AttackModifierTests
{
    public class AtiumBeadTests
    {
        [Fact]
        public void Reduce_attack_success()
        {
            AtiumBead modifier = new AtiumBead();
            TestWeapon testWeapon = new TestWeapon(DamageType.Decoding);
            AttackData attackData = testWeapon.CalculateAttack();

            AttackData newData = modifier.ModifyAttack(attackData);

            Assert.Equal(.9, newData.Success);
        }
    }
}
