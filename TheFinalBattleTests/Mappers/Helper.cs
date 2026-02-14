using TheFinalBattle.Levels.DTO;

namespace TheFinalBattle.Tests.Mappers
{
    public class Helper
    {
        public static EntityDTO GetValidEntityDTO(int? gear = null, int? defensiveModifier = null) =>
            new EntityDTO { Id = 1, IdDefensiveModifier = defensiveModifier, IdGear = gear };
        public static EntityDTO GetInvalidEntityDTO(int? gear = null, int? defensiveModifier = null) =>
            new EntityDTO { Id = 99999, IdDefensiveModifier = defensiveModifier, IdGear = gear };
        public static ItemAmountDTO GetValidItemAmountDTO(int amount = 1) =>
            new ItemAmountDTO { Id = 1, Amount = amount };
        public static ItemAmountDTO GetInvalidItemAmountDTO(int amount = 1) =>
            new ItemAmountDTO { Id = 9999, Amount = amount };
        public static PartyDTO GetPartyDTO(int totalEntites, int validEntities)
        {
            List<EntityDTO> entites = new List<EntityDTO>();
            int countValidEntities = validEntities;

            for (int i = 0; i < totalEntites; i++)
            {
                if (countValidEntities > 0)
                {
                    entites.Add(GetValidEntityDTO());
                    countValidEntities--;
                } else
                {
                    entites.Add(GetInvalidEntityDTO());
                }
            }

            return new PartyDTO { Enemies = entites, Inventory = [] };
        }
    }
}
