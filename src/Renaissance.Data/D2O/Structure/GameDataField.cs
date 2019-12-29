using System;
using System.Reflection;

namespace Renaissance.Data.D2O.Structure
{
    public class GameDataField
    {
        public string Name { get; set; }

        public GameDataTypeEnum TypeId { get; set; }

        public Tuple<GameDataTypeEnum, string>[] VectorTypes { get; set; }

        public long Offset { get; set; }

        public Type FieldType => PropertyInfo != null ? PropertyInfo.PropertyType : FieldInfo.FieldType;

        internal PropertyInfo PropertyInfo { get; set; }

        internal FieldInfo FieldInfo { get; set; }


        public GameDataField(string name, GameDataTypeEnum typeId, long offset,
            FieldInfo fieldInfo, params Tuple<GameDataTypeEnum, string>[] vectorTypes)
        {
            this.Name = name;
            this.TypeId = typeId;
            this.VectorTypes = vectorTypes;
            this.Offset = offset;
            this.FieldInfo = fieldInfo;
        }

        public GameDataField(string name, GameDataTypeEnum typeId, long offset, PropertyInfo propertyInfo,
           params Tuple<GameDataTypeEnum, string>[] vectorTypes)
        {
            this.Name = name;
            this.TypeId = typeId;
            this.VectorTypes = vectorTypes;
            this.Offset = offset;
            this.PropertyInfo = propertyInfo;
        }

        public object GetValue(object instance)
        {
            if (PropertyInfo != null)
                return PropertyInfo.GetValue(instance, null);
            if (FieldInfo != null)
                return FieldInfo.GetValue(instance);
            throw new NullReferenceException($"Exception for GetValue : {nameof(instance)}");
        }
    }
}
