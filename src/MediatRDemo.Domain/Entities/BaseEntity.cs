namespace MediatRDemo.Domain.Entities
{
    public class BaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
