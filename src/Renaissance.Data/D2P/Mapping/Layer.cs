using System;
using Renaissance.Binary;

namespace Renaissance.Data.D2P.Mapping
{
    /// <summary>
    /// <see cref="Layer"/> refers to com.ankamagames.atouin.data.map.Layer
    /// </summary>
    public class Layer
    {
        public int LayerId { get; private set; }

        public int CellsCount { get; private set; }

        public Cell[] Cells { get; private set; }

        public Layer() { }


        public void FromRaw(DofusReader reader, int mapVersion)
        {
            try
            {
                this.LayerId = mapVersion >= 9 ? reader.Read<byte>() : reader.Read<byte>();
                this.CellsCount = reader.Read<short>();
                this.Cells = new Cell[CellsCount];

                if (CellsCount > 0)
                {
                    for (int i = 0; i < CellsCount; i++)
                    {
                        var cell = new Cell(this);
                        cell.FromRaw(reader, mapVersion);
                        Cells[i] = cell;
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
