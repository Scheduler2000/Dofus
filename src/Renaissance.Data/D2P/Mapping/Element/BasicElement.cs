﻿using Renaissance.Binary;

namespace Renaissance.Data.D2P.Mapping.Element
{
    /// <summary>
    /// <see cref="BasicElement"/> refers to com.ankamagames.atouin.data.map.elements.BasicElement
    /// </summary>
    public abstract class BasicElement
    {
        public CellElement Cell { get; protected set; }

        public int ElementType { get; }

        protected BasicElement(CellElement cell, ElementTypesEnum elementType)
        {
            this.Cell = cell;
            this.ElementType = (int)elementType;
        }

        public abstract void FromRaw(DofusReader reader, int mapVersion);
    }
}
