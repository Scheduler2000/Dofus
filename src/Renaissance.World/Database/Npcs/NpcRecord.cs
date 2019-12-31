using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Npcs
{
    [Table("Npcs")]
    public class NpcRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Look { get; set; }

        public string DialogMessagesCSV { get; set; }

        public string DialogRepliesCSV { get; set; }

        public int[] Actions { get; set; }

        public int TokenShop { get; set; }


        [NotMapped]
        public int[][] DialogMessages
        {
            get => DialogMessagesCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => DialogMessagesCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public int[][] DialogReplies
        {
            get => DialogRepliesCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => DialogRepliesCSV = value.ToCSV("|", x => x.ToCSV(","));
        }
    }
}
