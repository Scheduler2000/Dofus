using Microsoft.EntityFrameworkCore;
using Renaissance.Database;

namespace Renaissance.Abstract.Database.Share
{
    public class AccountContext : DofusContext<Account>
    {
        public override DbSet<Account> Table { get; set; }

        public AccountContext()
        {
            this.Table = base.Set<Account>();
            Verify("Accounts");
        }
    }
}
