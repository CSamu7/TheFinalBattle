using TheFinalBattle.GameObjects.Attacks;
using TheFinalBattle.GameObjects.Entities;

namespace TheFinalBattle.PlayerCommands
{
    public record ProccessedAttack(
        Entity Attacker,
        Entity Defensor,
        //The data before the modifiers are applied
        AttackData OriginalDataAttack,
        //The data after the modifiers were applied
        AttackData NewDataAttack,
        Attack Attack,
        double RandomSuccess
    );
}
