using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Shared
{
    public class PagingRequest
    {
        const int maxPageSize = 100;

        public int PageNumber { get; set; }
        private int pageSize;

        public int PageSize 
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > maxPageSize ? value : maxPageSize;
            }
        }

        public string OrderBy { get; set; }
        public string Direction { get; set; }
    }
}
