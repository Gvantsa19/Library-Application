using Library.Application.Infrastructure.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Infrastructure.Entities
{
    public record Book
    (
        string Title,
        int AuthorId,
        string Description
    ) : EntityBase
    {
        public ICollection<Author> Author { get; set; }
    }
}
