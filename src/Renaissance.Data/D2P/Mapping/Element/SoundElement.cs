using System;
using Renaissance.Binary;

namespace Renaissance.Data.D2P.Mapping.Element
{
    public class SoundElement : BasicElement
    {
        public int SoundId { get; private set; }

        public int MinDelayBetweenLoops { get; private set; }

        public int MaxDelayBetweenLoops { get; private set; }

        public int BaseVolume { get; private set; }

        public int FullVolumeDistance { get; private set; }

        public int NullVolumeDistance { get; private set; }


        public SoundElement(Cell cell)
            : base(cell, ElementTypesEnum.Sound) { }

        public override void FromRaw(DofusReader reader, int mapVersion)
        {
            try
            {
                this.SoundId = reader.Read<int>();
                this.BaseVolume = reader.Read<int>();
                this.FullVolumeDistance = reader.Read<int>();
                this.NullVolumeDistance = reader.Read<int>();
                this.MinDelayBetweenLoops = reader.Read<short>();
                this.MaxDelayBetweenLoops = reader.Read<short>();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
