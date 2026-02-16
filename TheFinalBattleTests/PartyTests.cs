using TheFinalBattle.GameObjects.Entities.Enemies;
using TheFinalBattle.Parties;

namespace TheFinalBattle.Tests
{
    public class PartyTests
    {
        [Fact]
        public void AddMembers_WhenTeamIsFull_ReturnFalse()
        {
            Party party = new Party(new PartyHuman());
            party.AddMembers(new Skeleton(), new Skeleton(), new Skeleton());

            bool isMemberAdded = party.AddMembers(new Skeleton());

            Assert.False(isMemberAdded);
            Assert.True(party.Members.Count == 3);
        }
        [Fact]
        public void CleanParty_IfAMemberIsDead_RemoveFromParty()
        {
            Party sut = new Party(new PartyHuman());
            Skeleton entityDead = new Skeleton { HP = 0, Gear = new TestGear() };
            sut.AddMembers(entityDead, new Skeleton(), new Skeleton());
            Inventory enemyInventory = new Inventory();

            sut.CleanParty(enemyInventory);

            Assert.True(sut.Members.Count() == 2);
            Assert.Contains(enemyInventory.Items, slot => slot.Item.Id == new TestGear().Id);
        }
    }
}