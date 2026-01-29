using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.Items;
using TheFinalBattle.PartyControl;

namespace TheFinalBattle.Tests
{
    public class PartyTests
    {
        private Party _party;
        public PartyTests()
        {
            _party = new Party(new PartyHuman());
        }

        [Fact]
        //method-name, stateundertest, expected-behavior
        public void AddMembers_WhenTeamIsFull_ReturnFalse()
        {
            //Una mejor forma de añadir miembros a una party
            _party.AddMembers(new Akechi(), new Akechi(), new Akechi());

            bool isMemberAdded = _party.AddMembers(new Akechi());

            Assert.False(isMemberAdded);
            Assert.True(_party.Members.Count == 3);
        }
        [Fact]
        public void CleanParty_IfAMemberIsDead_RemoveFromParty()
        {
            Akechi akechi = new Akechi { HP = 0, Gear = new Misericorde() };
            _party.AddMembers(akechi, new Akechi(), new Akechi());
            Inventory enemyInventory = new Inventory();

            _party.CleanParty(enemyInventory);

            Assert.True(_party.Members.Count() == 2);
            Assert.Contains(enemyInventory.Items, slot => slot.Item.Id == new Misericorde().Id);
        }
    }
}