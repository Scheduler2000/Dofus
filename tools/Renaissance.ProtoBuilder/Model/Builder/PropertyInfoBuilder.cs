namespace Renaissance.Tools.ProtoBuilder.Model.Builder
{
    public class PropertyInfoBuilder
    {
        private readonly PropertyInfo m_property;

        public string PropertieName { get => m_property.Name; }

        public PropertyInfoBuilder()
            => this.m_property = new PropertyInfo();

        public PropertyInfoBuilder SetHasGetterTypeId(bool b)
        {
            m_property.HasGetterTypeId = b;
            return this;
        }

        public PropertyInfoBuilder SetPropertyType(PropertyType propertyType)
        {
            m_property.PropertyType = propertyType;
            return this;
        }
        public PropertyInfoBuilder SetName(string name)
        {
            m_property.Name = name;
            return this;
        }
        public PropertyInfoBuilder SetLenWriteType(string attribute)
        {
            m_property.LenWriteType = attribute;
            return this;
        }
        public PropertyInfoBuilder SetType(string type)
        {
            m_property.Type = type;
            return this;
        }

        public PropertyInfo Build() { return m_property; }
    }
}
