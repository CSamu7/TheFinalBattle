using System.Text;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    internal class PartyMapper : AbstractMapper<PartyDTO, Party>
    {
        //FIX. Sigue manteniendo los errores de la anterior party formateada.
        /*TODO: Crear un objeto llamado MappingResult que contenga lo siguiente:
         * El objeto parseado
         * La lista de errores
         */
        public override List<MappingError> Errors { get; protected set; } = new List<MappingError>();
        public readonly EntityMapper _entityMapper = new();
        private readonly ItemAmountMapper _itemAmountMapper = new();
        public override Party Map(PartyDTO party)
        {
            Errors = [];

            //FIX: Los errores se reinician porque la lista se elimina cada vez que se usa el metodo
            //Map, debo que buscar otra alternativa para subir los errores.
            List<Entity> enemies = party.Enemies
                .Select(raw => _entityMapper.Map(raw))
                .OfType<Entity>()
                .ToList();

            List<ItemAmount> items = party.Inventory
                .Select(raw => _itemAmountMapper.Map(raw))
                .OfType<ItemAmount>()
                .ToList();    

            Errors.AddRange(_entityMapper.Errors);

            return new Party
            {
                Inventory = new Inventory { Items = items},
                Members = enemies
            };
        }
    }
}
