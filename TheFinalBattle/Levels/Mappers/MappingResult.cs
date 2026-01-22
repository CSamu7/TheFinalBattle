using TheFinalBattle.UI;

namespace TheFinalBattle.Levels.Mappers
{
    public record MappingResult<T>
    {
        private T? _result;
        public List<MappingAlert> Alerts { get; init; } = [];
        public T Result
        {
            get => IsValid ? _result! : throw new InvalidOperationException();
            private set => _result = value;
        }
        public bool IsValid { get; init; }
        private MappingResult(T? result, List<MappingAlert> alerts, bool isValid)
        {
            _result = result;
            Alerts = alerts;
            IsValid = isValid;
        }
        public static MappingResult<T> Success(T result, List<MappingAlert> alerts)
            => new MappingResult<T>(result, alerts, true);

        public static MappingResult<T> Failure(List<MappingAlert> alerts)
            => new MappingResult<T>(default(T), alerts, false);
    }
}
