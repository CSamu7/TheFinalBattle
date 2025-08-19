using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.PartyControl
{
    public interface IPartyControl
    {
        public IEntityCommand SelectAction(Entity entity, Battle battle);
    }
}
