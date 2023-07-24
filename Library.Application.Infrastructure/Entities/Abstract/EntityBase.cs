using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Infrastructure.Entities.Abstract
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public EntityStatus EntityStatus { get; private set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? LastChangeDate { get; set; }

        public virtual void Delete()
        {
            EntityStatus = EntityStatus.Deleted;
        }

        public virtual void Activate()
        {
            EntityStatus = EntityStatus.Active;
        }

        public bool Active()
        {
            return EntityStatus == EntityStatus.Active;
        }
    }

    public enum EntityStatus
    {
        Deleted,
        Active,
        Locked
    }
}
