using NullGuard;

namespace ForecastCore.Shared
{
    public class Result
        {
            public bool IsSuccess { get; }
            public string Error { get; }
            public int Count { get; set; }
            public bool Failure => !IsSuccess;

            protected Result(bool isSuccess, string error)
            {
                if (isSuccess && !string.IsNullOrWhiteSpace(error))
                {
                    throw new InvalidOperationException("Error can't be filled in the case of success.");
                }
                if (!isSuccess && string.IsNullOrWhiteSpace(error))
                {
                    throw new InvalidOperationException("Error can't be empty in the case of failure.");
                }

                IsSuccess = isSuccess;
                Error = error;
            }

            public static Result Fail(string message)
            {
                return new Result(false, message);
            }

            public static Result<T> Fail<T>(string message)
            {
                return new Result<T>(default, false, message);
            }

            public static Result Success()
            {
                return new Result(true, string.Empty);
            }

            public static Result<T> Success<T>(T value)
            {
                return new Result<T>(value, true, string.Empty);
            }

            public static Result Combine(string errorMessagesSeparator, params Result[] results)
            {
                List<Result> failedResults = results.Where(x => x.Failure).ToList();

                if (!failedResults.Any())
                {
                    return Success();
                }

                string errorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
                return Fail(errorMessage);
            }

            public static Result Combine(params Result[] results)
            {
                return Combine(", ", results);
            }
        }

        public class Result<T> : Result
        {
            private readonly T _value;

            public T Value
            {
                get
                {
                    if (!IsSuccess)
                    {
                        throw new InvalidOperationException();
                    }
                    return _value;
                }
            }

            public Result([AllowNull] T value, bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
            {
                if (isSuccess && value == null)
                {
                    throw new InvalidOperationException("Value of object can't be null in the case of success.");
                }
                _value = value;
            }
        }
    }