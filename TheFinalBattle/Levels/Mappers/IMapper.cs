using TheFinalBattle.Levels.Mappers;

namespace TheFinalBattle.Levels.Parser
{
    public interface IMapper<TSource, TDestination>
    {
        public MappingResult<TDestination> Map(TSource destination);
    }
}
