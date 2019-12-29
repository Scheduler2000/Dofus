using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Items.Weapons
{
    public class WeaponContext : DofusContext<Weapon>
    {
        public override DbSet<Weapon> Table { get; set; }

        public WeaponContext()
        {
            this.Table = base.Set<Weapon>();
            Verify("ItemsWeapons");
        }
    }
}
