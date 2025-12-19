using TheFinalBattle.DTO;
using TheFinalBattle.Generators;
using TheFinalBattle.Items;
using TheFinalBattle.PlayableClasses;
using Utils;

namespace TheFinalBattle.UI
{
    public enum ErrorType { Warn, Error}
    public record LevelError(string Message, ErrorType ErrorType);
    public record LevelErrors(int LevelNumber, List<LevelError> Errors);
    public class LevelFormatter(LevelConfiguration levelConfiguration)
    {
        private readonly LevelConfiguration _levelConfiguration = levelConfiguration;
        private List<string> Errors = new List<string>();
        public bool TryFormat(LevelDTO rawLevel, out Level level)
        {
            Inventory rewards = FormatInventory(rawLevel.Rewards);
            Party party = FormatParty(rawLevel.PartyEnemy);
        }
        private Party FormatParty(PartyDTO rawParty)
        {
            Inventory enemyInventory = FormatInventory(rawParty.Inventory);
            List<Entity> enemies = FormatEntities(rawParty.Enemies);    
        }
        private List<Entity> FormatEntities(List<EntityDTO> rawEntities)
        {
            foreach (var rawEntity in rawEntities) {
                Entity? entity = CreateObject(rawEntity.Id, new EntitiesList(), $"La {rawEntity.Id}");

                if (entity is null) continue;
            }
        }
        private T? CreateObject<T>(int id, IObjectList<T> list, string messageError) where T : IGameObject
        {
            T? obj = list.GetByID(id);
            
            if(obj is null)
            {
                Errors.Add(messageError);
                return default(T);
            }
        
            return obj;
        }
        private Inventory FormatInventory(IEnumerable<SlotInventoryDTO> rawItems)
        {
            Inventory inventory = new Inventory();

            foreach (var rawItem in rawItems)
            {
                Item? slot = CreateObject(rawItem.Id, new ItemList(), $"Item con id {rawItem.Id} no existe");

                if (slot is not null)
                    inventory.Items.Add(new(slot, rawItem.Amount));
            }

            return inventory;
        }
    }
    public class FileValidationUI
    {
        private readonly LevelErrors _errors;
        private string _title = "Validación de Niveles";
        public FileValidationUI(LevelErrors errors)
        {
            _errors = errors;
        }
        public void Display()
        {
            Console.WriteLine(_title);

            foreach (var error in _errors.Errors)
            {
                if (error.ErrorType.Equals(ErrorType.Error))
                {
                    ConsoleUtils.Error(error.Message);
                } else
                {
                    ConsoleUtils.Warn(error.Message);
                }
            }
        }
    }
}
