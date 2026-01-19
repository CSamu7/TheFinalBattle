using TheFinalBattle.Items;
using TheFinalBattle.Levels.DTO;
using TheFinalBattle.PlayableClasses;
using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Parser
{
    public abstract class AbstractMapper<TSource, TDestination>
    {
        public abstract List<MappingError> Errors { get; protected set; }
        public abstract TDestination Map(TSource destination);
    }

}
