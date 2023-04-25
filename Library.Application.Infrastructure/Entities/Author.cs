using Library.Application.Infrastructure.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Infrastructure.Entities
{
    public record Author
    (
        string FirstName,
        string LastName,
        int BookId
    ) : EntityBase
    {
        public ICollection<Book> Book { get; set; }
    }
}
