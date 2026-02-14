using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.GameObjects.Items;
using TheFinalBattle.PartyControl;

namespace TheFinalBattle.Tests
{
    public class PartyTests
    {
        [Fact]
        public void AddMembers_WhenTeamIsFull_ReturnFalse()
        {
            Party party = new Party(new PartyHuman());
            party.AddMembers(new Akechi(), new Akechi(), new Akechi());
            
            bool isMemberAdded = party.AddMembers(new Akechi());

            Assert.False(isMemberAdded);
            Assert.True(party.Members.Count == 3);
        }
        [Fact]
        public void CleanParty_IfAMemberIsDead_RemoveFromParty()
        {
            Party sut = new Party(new PartyHuman());
            Akechi entityDead = new Akechi { HP = 0, Gear = new Misericorde() };
            sut.AddMembers(entityDead, new Akechi(), new Akechi());
            Inventory enemyInventory = new Inventory();

            sut.CleanParty(enemyInventory);

            Assert.True(sut.Members.Count() == 2);
            Assert.Contains(enemyInventory.Items, slot => slot.Item.Id == new Misericorde().Id);
        }
    }
}