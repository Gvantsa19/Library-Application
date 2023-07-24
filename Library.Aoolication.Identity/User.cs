using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;


namespace Library.Aoolication.Identity
{
    public class User : IdentityUser
    {
        public DateTimeOffset CreateDate { get; set; }
    }
}
