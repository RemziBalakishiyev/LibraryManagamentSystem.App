using Lms.Entity.Commons;

namespace Lms.Entity.Accounts
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PassworHash { get; set; }
    }
}
