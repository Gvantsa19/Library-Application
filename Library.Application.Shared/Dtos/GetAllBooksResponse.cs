using Library.Application.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Shared.Dtos
{
    public class GetAllBooksResponse
    {
        public List<Book> Books { get; set; }
        public int CurrentPage { get; set; }
        public int Page { get; set; }
    }
}
