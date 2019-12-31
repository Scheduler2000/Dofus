using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Database.Pattern;
using Renaissance.Protocol.enums.custom;
using Renaissance.World.Database.Breeds;
using Renaissance.World.Game.Actors.Look;
using Renaissance.World.IoC;
using Renaissance.World.Manager.Game.EntityLook;

namespace Renaissance.World.Database.Characters
{
    [Table("Characters")]
    public class CharacterRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int BreedId { get; set; }

        public int HeadId { get; set; }

        public string Name { get; set; }

        public short Level { get; set; }

        public string DefaultLookStr { get; set; }

        public string LastLookStr { get; set; }

        public bool Sex { get; set; }

        public int MapId { get; set; }

        public short CellId { get; set; }

        public DirectionsEnum Direction { get; set; }

        public int Kamas { get; set; }

        public long Experience { get; set; }

        public int StatsPoints { get; set; }

        public int Vitality { get; set; }

        public int Agility { get; set; }

        public int Chance { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        [NotMapped]
        public ContextActorLook DefaultLook
        {
            get => ServiceLocator.Provider.GetService<EntityLookManager>()
                                          .Parse(DefaultLookStr);

            set => DefaultLookStr = value.ToString();
        }

        [NotMapped]
        public ContextActorLook LastLook
        {
            get => ServiceLocator.Provider.GetService<EntityLookManager>()
                                          .Parse(LastLookStr);

            set => LastLookStr = value.ToString();
        }

        public CharacterRecord() { }


        public CharacterRecord(int accountId, int breedId, int headId, string name, short level, bool sex, int mapId,
                               short cellId, DirectionsEnum direction, int kamas, long experience, int statsPoints,
                               int vitality, int agility, int chance, int strength, int intelligence, int wisdom,
                               ContextActorLook defaultLook, ContextActorLook lastLook)
        {
            this.AccountId = accountId;
            this.BreedId = breedId;
            this.HeadId = headId;
            this.Name = name;
            this.Level = level;
            this.Sex = sex;
            this.MapId = mapId;
            this.CellId = cellId;
            this.Direction = direction;
            this.Kamas = kamas;
            this.Experience = experience;
            this.StatsPoints = statsPoints;
            this.Vitality = vitality;
            this.Agility = agility;
            this.Chance = chance;
            this.Strength = strength;
            this.Intelligence = intelligence;
            this.Wisdom = wisdom;
            this.DefaultLook = defaultLook;
            this.LastLook = lastLook;
        }
    }
}
