using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Breeds
{
    [Table("Breeds")]
    public class BreedRecord : IRecord
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DescriptionId { get; set; }

        public int GameplayDescriptionId { get; set; }

        public int GameplayClassDescriptionId { get; set; }

        public string MaleLook { get; set; }

        public string FemaleLook { get; set; }

        public string StatsPointsForStrengthCSV { get; set; }


        public int[] BreedSpellsId { get; set; }

        public int[] MaleColors { get; set; }

        public int[] FemaleColors { get; set; }

        public int SpawnMap { get; set; }

        public string StatsPointsForIntelligenceCSV { get; set; }

        public string StatsPointsForChanceCSV { get; set; }

        public string StatsPointsForAgilityCSV { get; set; }

        public string StatsPointsForVitalityCSV { get; set; }

        public string StatsPointsForWisdomCSV { get; set; }


        [NotMapped]
        public int[][] StatsPointsForIntelligence
        {
            get => StatsPointsForIntelligenceCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => StatsPointsForIntelligenceCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public int[][] StatsPointsForChance
        {
            get => StatsPointsForChanceCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => StatsPointsForChanceCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public int[][] StatsPointsForAgility
        {
            get => StatsPointsForAgilityCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => StatsPointsForAgilityCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public int[][] StatsPointsForVitality
        {
            get => StatsPointsForVitalityCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => StatsPointsForVitalityCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public int[][] StatsPointsForWisdom
        {
            get => StatsPointsForWisdomCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => StatsPointsForWisdomCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

    }
}
