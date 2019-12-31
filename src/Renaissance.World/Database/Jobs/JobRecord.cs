using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Jobs
{
    [Table("Jobs")]
    public class JobRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int IconId { get; set; }

    }
}
