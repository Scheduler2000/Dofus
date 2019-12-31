using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Titles
{
    [Table("Titles")]
    public class TitleRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string NameMale { get; set; }

        public string NameFemale { get; set; }

        public bool Visible { get; set; }

        public int CategoryId { get; set; }
    }
}
