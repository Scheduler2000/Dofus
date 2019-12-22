using System;
using Renaissance.Binary;
using Renaissance.Data.D2P.Mapping.Element;

namespace Renaissance.Data.D2P.Mapping
{
    /// <summary>
    /// <see cref="Cell"/> refers to com.ankamagames.atouin.data.map.Cell
    /// </summary>
    public class Cell
    {
        public int CellId { get; private set; }

        public int ElementsCount { get; private set; }

        public BasicElement[] Elements { get; private set; }

        public Layer Layer { get; private set; }

        public Cell(Layer layer)
        { this.Layer = layer; }


        public void FromRaw(DofusReader reader, int mapVersion)
        {
            try
            {
                this.CellId = reader.Read<short>();
                this.ElementsCount = reader.Read<short>();
                this.Elements = new BasicElement[ElementsCount];

                for (int i = 0; i < ElementsCount; i++)
                {

                    BasicElement be = ((ElementTypesEnum)reader.Read<byte>()) switch
                    {
                        ElementTypesEnum.Graphical => new GraphicalElement(this),
                        ElementTypesEnum.Sound => new SoundElement(this),
                        _ => throw new Exception($"Un élément de type inconnu a été trouvé sur la celulle {CellId}!"),
                    };

                    be.FromRaw(reader, mapVersion);
                    Elements[i] = be;
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
