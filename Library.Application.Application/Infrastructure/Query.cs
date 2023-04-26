using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application.Infrastructure
{
    public class Query<T>
    {
        public Query()
        {
            QueryParams = Activator.CreateInstance<T>();
        }

        public T QueryParams { get; set; }

        [Required]
        public int PageIndex { get; set; }
        [Required]
        public int PageSize { get; set; }
    }
}
