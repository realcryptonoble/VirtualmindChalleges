using System.Data.Entity;

namespace VirtualmindCodeChallenge.Models
{
    public class UserModel : DbContext
    {
        public virtual DbSet<User> users { get; set; }
    }

    public class User {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}