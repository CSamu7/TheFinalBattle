using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.GameObjects.DefensiveModifiers;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.GameObjects.AttackModifiers
{
    public class MagmaStone : AbstractAttackModifier
    {
        public override string Name { get; init; } = "Magma Stone";
        public override bool IsDefensive => false;
        public override string GetSuccessfulMessage(Entity holder)
            => $"The fire has fueled you {holder.Name}!";
        public override AttackData ModifyAttack(AttackData attackData)
        {
            AttackData newData = attackData with { };

            if (attackData.DamageType.Equals(DamageType.Physical))
            {
                int newDamage = attackData.DamagePoints + 2;
                newData = newData with { DamagePoints = newDamage };
            }

            return newData;
        }
    }
}
