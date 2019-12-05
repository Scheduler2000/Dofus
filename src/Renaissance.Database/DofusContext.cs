using System;
using Microsoft.EntityFrameworkCore;
using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;

namespace Renaissance.Database
{
    public abstract class DofusContext<TEntity> : DbContext where TEntity : class, IEntity
    {
        public abstract DbSet<TEntity> Table { get; set; }


        protected DofusContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Atarax;Username=postgres;Password=Dofus2.0");
            base.OnConfiguring(optionsBuilder);
        }

        protected void Verify(string tableName)
        {
            if (!this.TableExists(tableName))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[DATABASE] Table : {tableName} doesn't exist !");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.WriteLine($"[DATABASE] Table : {tableName} correctly loaded.");
        }
    }
}
