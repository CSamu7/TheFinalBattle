using TheFinalBattle.DTO;
using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Validations
{
    public interface IValidator
    {
        public bool IsValid();
    }
    public class LevelsFormatter()
    {
        public List<LevelErrors> FormatErrors { get; private set; } = new List<LevelErrors>();
        private List<Level> _formattedLevels = new List<Level>();
        private void AddError(LevelError error)
        {
            FormatErrors.Last().Errors.Add(error);
        }
        public List<Level> Format(List<LevelDTO> rawLevels)
        {
            for(int i = 0; i<rawLevels.Count; i++)
            {
                FormatErrors.Add(new LevelErrors([]));

                List<SlotInventory> rewards = FormatItems(rawLevels[i].Rewards);
                Party party = FormatParty(rawLevels[i].PartyEnemy);

                if (party.Members.Count == 0)
                {
                    AddError(new("No hay suficientes enemigos", ErrorType.Error));
                    continue;
                }   
                 
                _formattedLevels.Add(new(party, rewards));
            }

            return _formattedLevels;
        }
        private Party FormatParty(PartyDTO rawParty)
        {
            Inventory enemyInventory = new Inventory { Items = FormatItems(rawParty.Inventory) };
            List<Entity> enemies = FormatEntities(rawParty.Enemies);

            return new Party
            {
                Inventory = enemyInventory,
                Members = enemies
            };
        }
        private List<Entity> FormatEntities(List<EntityDTO> rawEntities)
        {
            List<Entity> enemies = new List<Entity>();

            foreach (var rawEntity in rawEntities)
            {
                Entity? entity = FormatObject(rawEntity.Id, new EntitiesList(), $"La {rawEntity.Id}");

                if (entity is not null) enemies.Add(entity);
            }

            return enemies;
        }
        private T? FormatObject<T>(int id, IObjectList<T> list, string messageError)
        {
            T? obj = list.GetByID(id);

            if (obj is null)
            {
                AddError(new(messageError, ErrorType.Warn));
                return default;
            }

            return obj;
        }
        private List<SlotInventory> FormatItems(List<SlotInventoryDTO> rawItems)
        {
            List<SlotInventory> items = new List<SlotInventory>();

            foreach (var rawItem in rawItems)
            {
                Item? slot = FormatObject(rawItem.Id, new ItemList(), $"Item con id {rawItem.Id} no existe");

                if (slot is not null)
                    items.Add(new(slot, rawItem.Amount));
            }

            return items;
        }
    }
}
