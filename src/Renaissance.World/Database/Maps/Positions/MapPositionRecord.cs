using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Maps.Positions
{
    [Table("MapsPositions")]
    public class MapPositionRecord : IRecord
    {
        [Key]
        public double Id { get; set; }

        public int NameId { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public Boolean Outdoor { get; set; }

        public int Capabilities { get; set; }


    }
}
