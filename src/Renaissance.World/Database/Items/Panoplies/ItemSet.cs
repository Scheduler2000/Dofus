using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;
using Renaissance.Protocol.datacenter.effects;

namespace Renaissance.World.Database.Items.Panoplies
{
    [Table("ItemsSets")]
    public class ItemSet : IEntity
    {
        [Key]
        public int Id { get; set; }

        public List<int> Items { get; set; }

        public string Name { get; set; }

        public byte[] EffectsBin { get; set; }

        public bool BonusIsSecret { get; set; }

        [NotMapped]
        public List<List<EffectInstanceData>> Effects
        {
            get => EffectsBin.ToObject<List<List<EffectInstanceData>>>();
            set => EffectsBin = value.ToBinary();
        }

    }
}
