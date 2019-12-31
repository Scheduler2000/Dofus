using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.items;
using Renaissance.World.Database.Items.Weapons;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class ItemWeaponSynchroniser : AbstractSynchroniser<WeaponRecord, WeaponData>
    {
        private readonly D2IManager m_d2i;


        public ItemWeaponSynchroniser(D2IManager d2i, IEnumerable<WeaponData> datas, IRepository<WeaponRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override WeaponRecord BuildEntity(WeaponData data)
        {
            return new WeaponRecord()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                TypeId = (int)data.TypeId,
                DescriptionId = (int)data.DescriptionId,
                IconId = (int)data.IconId,
                Level = (int)data.Level,
                RealWeight = (int)data.RealWeight,
                Cursed = data.Cursed,
                UseAnimationId = data.UseAnimationId,
                Usable = data.Usable,
                Targetable = data.Targetable,
                Exchangeable = data.Exchangeable,
                Price = data.Price,
                TwoHanded = data.TwoHanded,
                Etheral = data.Etheral,
                ItemSetId = data.ItemSetId,
                ApCost = data.ApCost,
                MinRange = data.MinRange,
                Range = data.Range,
                MaxCastPerTurn = data.MaxCastPerTurn,
                CastInLine = data.CastInLine,
                CastInDiagonal = data.CastInDiagonal,
                CastTestLos = data.CastTestLos,
                CriticalHitProbability = data.CriticalHitProbability,
                CriticalHitBonus = data.CriticalHitBonus,
                CriticalFailureProbability = data.CriticalFailureProbability,
                Criteria = data.Criteria,
                CriteriaTarget = data.CriteriaTarget,
                HideEffects = data.HideEffects,
                Enhanceable = data.Enhanceable,
                NonUsableOnAnother = data.NonUsableOnAnother,
                AppearanceId = (int)data.AppearanceId,
                SecretRecipe = data.SecretRecipe,
                DropMonsterIds = data.DropMonsterIds.Select(x => (int)x).ToList(),
                RecipeSlots = (int)data.RecipeSlots,
                RecipeIds = data.RecipeIds.Select(x => (int)x).ToList(),
                BonusIsSecret = data.BonusIsSecret,
                EvolutiveEffectIds = data.EvolutiveEffectIds.Select(x => (int)x).ToList(),
                CraftXpRatio = data.CraftXpRatio,
                CraftVisible = data.CraftVisible,
                CraftFeasible = data.CraftFeasible,
                NeedUseConfirm = data.NeedUseConfirm,
                IsDestructible = data.IsDestructible,
                IsSaleable = data.IsSaleable,
                FavoriteSubAreas = data.FavoriteSubAreas.Select(x => (int)x).ToList(),
                FavoriteSubAreasBonus = (int)data.FavoriteSubAreasBonus,
                PossibleEffects = data.PossibleEffects,
                NuggetsBySubarea = data.NuggetsBySubarea.Select(x => x.ToArray()).ToArray(),
                ResourcesBySubarea = data.ResourcesBySubarea.Select(x => x.ToArray()).ToArray()
            };
        }
    }
}
