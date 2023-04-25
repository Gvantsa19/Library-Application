using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Infrastructure.Entities.Abstract
{
    public record class EntityBase
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
    }
}
