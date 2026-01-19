namespace TheFinalBattle.Levels.Parser
{
    public class Result<T, TError>
    {
        private T? _value;
        private TError? _error;
        public bool IsSuccess { get; init; }
        public T Value { 
            get => _value is not null ? _value : throw new InvalidOperationException();
            private set => _value = value;
        }
        public TError Error
        {
            get => _error is not null ? _error : throw new InvalidOperationException();
            private set => _error = value;
        }
        private Result(bool isSuccess, T? value, TError? error)
        {
            _error = error;
            _value = value;
            IsSuccess = isSuccess;
        }
        public static Result<T, TError> Success(T value) =>
            new Result<T, TError>(true, value, default);

        public static Result<T, TError> Failure(TError error) =>
            new Result<T, TError>(false, default, error);

    }
}
