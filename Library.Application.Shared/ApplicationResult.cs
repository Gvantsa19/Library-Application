using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Shared
{
    public class ApplicationResult<T>
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public T Data { get; set; }


        public static ApplicationResult<T> Default()
        {
            return new ApplicationResult<T>();
        }
    }

    public class ApplicationResult : ApplicationResult<dynamic>
    {
        public new static ApplicationResult Default()
        {
            return new ApplicationResult();
        }
    }
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

}
