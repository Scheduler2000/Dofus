using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.monsters;
using Renaissance.World.Database.Monsters;
using Renaissance.World.Database.Monsters.Drop;
using Renaissance.World.Database.Monsters.Drop.Coefficient;
using Renaissance.World.Database.Monsters.Grade;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MonsterSynchroniser : AbstractSynchroniser<Monster, MonsterData>
    {
        private readonly D2IManager m_d2i;

        public MonsterSynchroniser(D2IManager d2i, IEnumerable<MonsterData> datas, IRepository<Monster> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override Monster BuildEntity(MonsterData data)
        {
            return new Monster()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                GfxId = (int)data.GfxId,
                Race = data.Race,
                Look = data.Look,
                UseSummonSlot = data.UseSummonSlot,
                UseBombSlot = data.UseBombSlot,
                CanPlay = data.CanPlay,
                CanTackle = data.CanTackle,
                IsBoss = data.IsBoss,
                Subareas = data.Subareas.Select(x => (int)x).ToList(),
                Spells = data.Spells.Select(x => (int)x).ToList(),
                FavoriteSubareaId = data.FavoriteSubareaId,
                IsMiniBoss = data.IsMiniBoss,
                IsQuestMonster = data.IsQuestMonster,
                CorrespondingMiniBossId = (int)data.CorrespondingMiniBossId,
                SpeedAdjust = data.SpeedAdjust,
                CreatureBoneId = data.CreatureBoneId,
                CanBePushed = data.CanBePushed,
                CanBeCarried = data.CanBeCarried,
                CanUsePortal = data.CanUsePortal,
                CanSwitchPos = data.CanSwitchPos,
                IncompatibleIdols = data.IncompatibleIdols.Select(x => (int)x).ToList(),
                AllIdolsDisabled = data.AllIdolsDisabled,
                DareAvailable = data.DareAvailable,
                IncompatibleChallenges = data.IncompatibleChallenges.Select(x => (int)x).ToList(),
                UseRaceValues = data.UseRaceValues,
                AggressiveZoneSize = data.AggressiveZoneSize,
                AggressiveLevelDiff = data.AggressiveLevelDiff,
                AggressiveImmunityCriterion = data.AggressiveImmunityCriterion,
                AggressiveAttackDelay = data.AggressiveAttackDelay,

                Drops = data.Drops.Select(x =>
                    new MonsterDrop()
                    {
                        MonsterId = x.MonsterId,
                        DropId = (int)x.DropId,
                        ObjectId = x.ObjectId,
                        PercentDropForGrade1 = x.PercentDropForGrade1,
                        PercentDropForGrade2 = x.PercentDropForGrade2,
                        PercentDropForGrade3 = x.PercentDropForGrade3,
                        PercentDropForGrade4 = x.PercentDropForGrade4,
                        PercentDropForGrade5 = x.PercentDropForGrade5,
                        Count = x.Count,
                        Criteria = x.Criteria,
                        HasCriteria = x.HasCriteria,
                        SpecificDropCoefficient = x.SpecificDropCoefficient.Select(y =>
                        new MonsterDropCoefficient()
                        {
                            MonsterId = (int)y.MonsterId,
                            MonsterGrade = (int)y.MonsterGrade,
                            DropCoefficient = y.DropCoefficient,
                            Criteria = y.Criteria,
                        }).ToList()

                    }).ToList(),

                Grades = data.Grades.Select(x =>
                        new MonsterGrade()
                        {
                            MonsterId = x.MonsterId,
                            Grade = (int)x.Grade,
                            Level = (int)x.Level,
                            Vitality = x.Vitality,
                            PaDodge = x.PaDodge,
                            PmDodge = x.PmDodge,
                            Wisdom = x.Wisdom,
                            EarthResistance = x.EarthResistance,
                            AirResistance = x.AirResistance,
                            FireResistance = x.FireResistance,
                            WaterResistance = x.WaterResistance,
                            NeutralResistance = x.NeutralResistance,
                            GradeXp = x.GradeXp,
                            LifePoints = x.LifePoints,
                            ActionPoints = x.ActionPoints,
                            MovementPoints = x.MovementPoints,
                            DamageReflect = x.DamageReflect,
                            HiddenLevel = (int)x.HiddenLevel,
                            Strength = x.Strength,
                            Intelligence = x.Intelligence,
                            Chance = x.Chance,
                            Agility = x.Agility,
                            StartingSpellId = x.StartingSpellId,

                        }).ToList(),
            };
        }
    }
}
