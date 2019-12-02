namespace Renaissance.Tools.ProtoBuilder.Model
{

    public enum PropertyType
    {
        NULL,
        IsPrimitiveArray,
        IsObjectArray,
        IsPrimitiveType,
        IsObjectType,
        IsWrappedBool
    }

    public class PropertyInfo
    {
        public PropertyType PropertyType { get; set; } = PropertyType.NULL;

        public string Type { get; set; }

        public string LenWriteType { get; set; } // if array 

        public bool HasGetterTypeId { get; set; } // if generic array or dofus type, does we need to write getTypeId() ?

        public string Name { get; set; }

    }
}
