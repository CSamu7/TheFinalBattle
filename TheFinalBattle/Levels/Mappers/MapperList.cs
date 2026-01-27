using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Mappers
{
    public class MapperList
    {
   
        public (List<TDestination> items, List<MappingAlert> errors) 
            MapItems<TSource, TDestination>(List<TSource> dtoItems, IMapper<TSource, TDestination> mapper)
        {
            List<MappingResult<TDestination>> mappingItems =
                dtoItems.Select(item => mapper.Map(item)).ToList();

            List<MappingAlert> itemsErrors = mappingItems
                .Where(map => !map.IsValid)
                .Select(item => item.Alerts)
                .SelectMany(item => item)
                .ToList();

            List<TDestination> items = mappingItems
                .Where(map => map.IsValid)
                .Select(item => item.Result)
                .ToList();

            return (items, itemsErrors);      
        }
    }
}
