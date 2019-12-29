using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;
using Renaissance.Protocol.datacenter.effects;

namespace Renaissance.World.Database.Items
{
    [Table("Items")]
    public class Item : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public int DescriptionId { get; set; }

        public int IconId { get; set; }

        public int Level { get; set; }

        public int RealWeight { get; set; }

        public bool Cursed { get; set; }

        public int UseAnimationId { get; set; }

        public bool Usable { get; set; }

        public bool Targetable { get; set; }

        public bool Exchangeable { get; set; }

        public double Price { get; set; }

        public bool TwoHanded { get; set; }

        public bool Etheral { get; set; }
        public int ItemSetId { get; set; }

        public string Criteria { get; set; }

        public string CriteriaTarget { get; set; }

        public bool HideEffects { get; set; }

        public bool Enhanceable { get; set; }

        public bool NonUsableOnAnother { get; set; }

        public int AppearanceId { get; set; }

        public bool SecretRecipe { get; set; }

        public List<int> DropMonsterIds { get; set; }

        public int RecipeSlots { get; set; }

        public List<int> RecipeIds { get; set; }

        public bool BonusIsSecret { get; set; }

        public List<int> EvolutiveEffectIds { get; set; }

        public int CraftXpRatio { get; set; }

        public string CraftVisible { get; set; }

        public string CraftFeasible { get; set; }

        public bool NeedUseConfirm { get; set; }

        public bool IsDestructible { get; set; }

        public bool IsSaleable { get; set; }

        public List<int> FavoriteSubAreas { get; set; }

        public int FavoriteSubAreasBonus { get; set; }

        public byte[] PossibleEffectsBin { get; set; }

        public string NuggetsBySubareaCSV { get; set; }

        public string ResourcesBySubareaCSV { get; set; }


        [NotMapped]
        public List<EffectInstanceData> PossibleEffects
        {
            get => PossibleEffectsBin.ToObject<List<EffectInstanceData>>();
            set => PossibleEffectsBin = value?.ToBinary();
        }

        [NotMapped]
        public double[][] NuggetsBySubarea
        {
            get => NuggetsBySubareaCSV.FromCSV("|", x => x.FromCSV<double>(","));
            set => NuggetsBySubareaCSV = value.ToCSV("|", x => x.ToCSV(","));
        }

        [NotMapped]
        public int[][] ResourcesBySubarea
        {
            get => ResourcesBySubareaCSV.FromCSV("|", x => x.FromCSV<int>(","));
            set => ResourcesBySubareaCSV = value.ToCSV("|", x => x.ToCSV(","));
        }


    }
}
