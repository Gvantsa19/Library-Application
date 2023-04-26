using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Infrastructure
{
    public class QueryResult<T>
    {
        public int TotalSize { get; set; }
        public IEnumerable<T>? Result { get; set; }
    }
}
