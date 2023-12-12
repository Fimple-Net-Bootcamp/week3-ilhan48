namespace Common.Utilities.Results;
public interface IDataResult<TEntity> : IResult
{
    TEntity Data { get; }
}
