using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands.Attacks;

namespace TheFinalBattle.Items
{
    //FIX: Cambiar a que sea una clase abstracta.
    public interface IDefensiveModifier
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string GetSuccessfulMessage(Entity defensor);
        public AttackData AdjustAttack(AttackData attackData);
    }
}
