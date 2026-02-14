using TheFinalBattle.GameObjects.Entities;
using TheFinalBattle.PlayerCommands;

namespace TheFinalBattle.Parties
{
    public interface IPartyControl
    {
        public IEntityCommand SelectAction(Entity entity, Battle battle);
    }
}
