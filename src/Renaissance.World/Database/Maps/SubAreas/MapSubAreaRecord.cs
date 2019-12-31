using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Maps.SubAreas
{
    [Table("MapsSubAreas")]
    public class MapSubAreaRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public int NameId { get; set; }

        public int AreaId { get; set; }

        public List<double> MapIds { get; set; }

        public int Level { get; set; }

        public bool MountAutoTripAllowed { get; set; }

        public List<int> Monsters { get; set; }

        public List<double> EntranceMapIds { get; set; }

        public List<double> ExitMapIds { get; set; }

        public List<int> Achievements { get; set; }

        public string QuestsCSV { get; set; }

        public string NpcsCSV { get; set; }

        public int ExploreAchievementId { get; set; }

        public bool IsDiscovered { get; set; }

        public List<int> Harvestables { get; set; }

        public int AssociatedZaapMapId { get; set; }


        [NotMapped]
        public double[][] Quests
        {
            get => QuestsCSV.FromCSV("|", x => x.FromCSV<double>(","));
            set => QuestsCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public double[][] Npcs
        {
            get => NpcsCSV.FromCSV("|", x => x.FromCSV<double>(","));
            set => NpcsCSV = value.ToCSV("|", x => x.ToCSV(","));
        }
    }
}
