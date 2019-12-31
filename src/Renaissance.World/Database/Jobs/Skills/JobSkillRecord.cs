using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Jobs.Skills
{
    [Table("JobsSkills")]
    public class JobSkillRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentJobId { get; set; }

        public bool IsForgemagus { get; set; }

        public List<int> ModifiableItemTypeIds { get; set; }

        public int GatheredRessourceItem { get; set; }

        public List<int> CraftableItemIds { get; set; }

        public int InteractiveId { get; set; }

        public int Range { get; set; }

        public bool UseRangeInClient { get; set; }

        public string UseAnimation { get; set; }

        public int Cursor { get; set; }

        public int ElementActionId { get; set; }

        public bool AvailableInHouse { get; set; }

        public int LevelMin { get; set; }

        public bool ClientDisplay { get; set; }

    }
}
