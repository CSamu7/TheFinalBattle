namespace TheFinalBattle.Levels.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
        public MappingResult<TDestination> Map(TSource destination);
    }
}
