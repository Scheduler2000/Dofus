using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;
using Renaissance.World.Database.Maps.Cells;

namespace Renaissance.World.Database.Maps
{
    [Table("Maps")]
    public class Map : IEntity
    {
        [Key]
        public double Id { get; set; }

        public int SubAreadId { get; set; }

        public int TopNeighbourId { get; set; }

        public int BottomNeighbourId { get; set; }

        public int LeftNeighbourId { get; set; }

        public int RightNeighbourId { get; set; }

        public int FightCellsCount { get; set; }

        public List<int> RedCells { get; set; }

        public List<int> BlueCells { get; set; }

        public List<int> OtherCells { get; set; }

        public byte[] CellsBin { get; set; }

        [NotMapped]
        public List<Cell> Cells
        {
            get => CellsBin.ToObject<List<Cell>>();
            set => CellsBin = value.ToBinary();
        }

    }
}
