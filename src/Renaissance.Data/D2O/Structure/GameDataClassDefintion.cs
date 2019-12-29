using System;
using System.Collections.Generic;

namespace Renaissance.Data.D2O.Structure
{
    public class GameDataClassDefintion
    {
        public Dictionary<string, GameDataField> Fields { get; }

        public int Id { get; }

        public string Name { get; }

        public string PackageName { get; }

        public Type ClassType { get; }

        public long Offset { get; set; }

        public GameDataClassDefintion(Dictionary<string, GameDataField> fields, int id, string name,
                                      string packageName, Type classType, long offset)
        {
            this.Fields = fields;
            this.Id = id;
            this.Name = name;
            this.PackageName = packageName;
            this.ClassType = classType;
            this.Offset = offset;
        }
    }
}
