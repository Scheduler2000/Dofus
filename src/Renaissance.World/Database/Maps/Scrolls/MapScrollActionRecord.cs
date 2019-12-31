using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Maps.Scrolls
{
    [Table("MapsScrollsActions")]
    public class MapScrollActionRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public double RightMapId { get; set; }

        public double BottomMapId { get; set; }

        public double LeftMapId { get; set; }

        public double TopMapId { get; set; }
    }
}
