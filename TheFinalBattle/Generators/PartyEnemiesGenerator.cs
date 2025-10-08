using TheFinalBattle.Items;
using TheFinalBattle.PartyControl;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.PlayableClasses.Enemies;

namespace TheFinalBattle
{
    public interface IPartyEnemyGenerator
    {
        public Party? GetPartyEnemy(Battles battles);
    }

    //No me gusta esta clase, hace varias cosas.
    public class ScriptedEnemiesGenerator
    {
        private IPartyControl _partyControl;

        private Dictionary<int, List<Entity>> _enemies = new Dictionary<int, List<Entity>>()
        {
            {1, [new Pixie()] },
            {2, [new JackFrost(), new Mothman()] },
            {3, [new WealthHand(), new WealthHand()] },
            {4, [new Akechi()] },
            {5, [new Reaper()] }
        };

        private Dictionary<int, List<SlotInventory>> _inventory = new Dictionary<int, List<SlotInventory>>()
        {
            {1, [new SlotInventory(new Gun())] },
            {5, [new SlotInventory(new Medicine()), 
                new SlotInventory(new GlassKnife())
                ] }
        };

        public ScriptedEnemiesGenerator(IPartyControl partyControl)
        {
            _partyControl = partyControl;
        }
        public Party GetPartyEnemy(Battles battles)
        {
            List<Entity> enemies = _enemies.GetValueOrDefault(battles.battleNumber, []);
            List<SlotInventory> items = _inventory.GetValueOrDefault(battles.battleNumber, []);

            Party partyEnemy = new Party(_partyControl, enemies);

            foreach (SlotInventory slot in items)
            {
                partyEnemy.Inventory.AddItem(slot.Item, slot.Amount);
            }

            return partyEnemy;
        }

    }
}
