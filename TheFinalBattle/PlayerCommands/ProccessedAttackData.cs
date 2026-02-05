using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.PlayerCommands
{
    public record ProccessedAttack(
        Entity Attacker,
        Entity Defensor,
        //The data before the modifiers are applied
        AttackData OriginalDataAttack,
        //The data after the modifiers were applied
        AttackData NewDataAttack,
        IAttack Attack,
        double RandomSuccess
    );
}
