using Microsoft.EntityFrameworkCore;
using Renaissance.Database;

namespace Renaissance.Auth.Database.Authentication
{
    public class AccountContext : DofusContext<Account>
    {
        public override DbSet<Account> Table { get; set; }

        public AccountContext()
        {
            this.Table = base.Set<Account>();
            base.Verify("Accounts");
        }
    }
}
