namespace Common.Persistence.Repositories;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public BaseEntity()
    {
        Id = default!;
    }
    public BaseEntity(TId ıd)
    {
        Id = ıd;
    }
}
