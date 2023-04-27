using Library.Application.Infrastructure.Entities.Abstract;

namespace Library.Application.Infrastructure.Entities
{
    public record Author
    (
        string FirstName,
        string LastName
    ) : EntityBase
    {
        public ICollection<Book> Books { get; set; }
    }
}
