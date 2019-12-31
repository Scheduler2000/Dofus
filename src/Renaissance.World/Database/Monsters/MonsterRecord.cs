using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;
using Renaissance.World.Database.Monsters.Drop;
using Renaissance.World.Database.Monsters.Grade;

namespace Renaissance.World.Database.Monsters
{
    [Table("Monsters")]
    public class MonsterRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int GfxId { get; set; }

        public int Race { get; set; }

        public List<MonsterGradeRecord> Grades { get; set; }

        public string Look { get; set; }

        public Boolean UseSummonSlot { get; set; }

        public Boolean UseBombSlot { get; set; }

        public Boolean CanPlay { get; set; }

        public Boolean CanTackle { get; set; }

        public Boolean IsBoss { get; set; }

        public List<MonsterDropRecord> Drops { get; set; }

        public List<int> Subareas { get; set; }

        public List<int> Spells { get; set; }

        public int FavoriteSubareaId { get; set; }

        public Boolean IsMiniBoss { get; set; }

        public Boolean IsQuestMonster { get; set; }

        public int CorrespondingMiniBossId { get; set; }

        public double SpeedAdjust { get; set; }

        public int CreatureBoneId { get; set; }

        public Boolean CanBePushed { get; set; }

        public Boolean CanBeCarried { get; set; }

        public Boolean CanUsePortal { get; set; }

        public Boolean CanSwitchPos { get; set; }

        public List<int> IncompatibleIdols { get; set; }

        public Boolean AllIdolsDisabled { get; set; }

        public Boolean DareAvailable { get; set; }

        public List<int> IncompatibleChallenges { get; set; }

        public Boolean UseRaceValues { get; set; }

        public int AggressiveZoneSize { get; set; }
        public int AggressiveLevelDiff { get; set; }

        public String AggressiveImmunityCriterion { get; set; }

        public int AggressiveAttackDelay { get; set; }
    }
}
