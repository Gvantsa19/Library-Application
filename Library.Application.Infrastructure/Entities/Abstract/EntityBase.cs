namespace Library.Application.Infrastructure.Entities.Abstract
{
    public record class EntityBase
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
    }
}
