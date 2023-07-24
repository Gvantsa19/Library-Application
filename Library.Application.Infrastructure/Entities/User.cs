using Library.Application.Infrastructure.Entities.Abstract;

namespace Library.Application.Infrastructure.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Phone { get; set; }
        public int RoleID { get; set; }
    }
}
