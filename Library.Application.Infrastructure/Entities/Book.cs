using Library.Application.Infrastructure.Entities.Abstract;
using System.Text.Json.Serialization;

namespace Library.Application.Infrastructure.Entities
{
    public record Book : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
    }
}
