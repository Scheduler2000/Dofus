using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;
using Renaissance.Protocol.datacenter.effects;

namespace Renaissance.World.Database.Mounts
{
    [Table("Mounts")]
    public class Mount : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int FamilyId { get; set; }


        public string Look { get; set; }

        public int CertificateId { get; set; }

        public byte[] EffectsBin { get; set; }

        [NotMapped]
        public List<EffectInstanceData> Effects
        {
            get => EffectsBin.ToObject<List<EffectInstanceData>>();
            set => EffectsBin = value?.ToBinary();
        }
    }
}
