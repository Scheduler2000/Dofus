using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Heads
{
    [Table("Heads")]
    public class HeadRecord : IRecord
    {
        public int Id { get; set; }

		public short SkinId { get; set; }

		public string AssetId { get; set; }

		public int Breed { get; set; }

		public int Gender { get; set; }

		public string Label { get; set; }

		public int Order { get; set; }
	}
}
