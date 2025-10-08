using TheFinalBattle.Attacks;
using TheFinalBattle.Effects;

namespace TheFinalBattle.Items
{
    public record Potion(int ID, string Name, string Description, IEffect Effect) 
        : Item(ID, Name, Description);
    public record Gear(int ID, string Name, string Description, IAttack SpecialAttack) 
        : Item(ID, Name, Description);
}
