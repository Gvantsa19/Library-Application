using Library.Application.Infrastructure.Entities.Abstract;

namespace Library.Application.Infrastructure.Entities
{
    public record Book
    (
        string Title,
        string Description
    ) : EntityBase
    {
        public ICollection<Author> Author { get; set; }
    }
}
