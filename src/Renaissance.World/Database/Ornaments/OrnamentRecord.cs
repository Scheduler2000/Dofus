using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Ornaments
{
    [Table("Ornaments")]
    public class OrnamentRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Visible { get; set; }

        public int AssetId { get; set; }

        public int IconId { get; set; }

        public int Rarity { get; set; }

        public int Order { get; set; }
    }
}
