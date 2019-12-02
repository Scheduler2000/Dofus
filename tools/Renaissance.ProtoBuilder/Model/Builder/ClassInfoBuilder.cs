using System.Collections.Generic;
using Renaissance.Tools.ProtoBuilder.Parsing;

namespace Renaissance.Tools.ProtoBuilder.Model.Builder
{
    public class ClassInfoBuilder
    {
        private readonly ClassInfo m_classInfo;

        public ClassInfoBuilder(ConverterType classType)
            => this.m_classInfo = new ClassInfo(classType);

        public ClassInfoBuilder SetClassName(string name)
        {
            m_classInfo.Name = name;
            return this;
        }

        public ClassInfoBuilder SetNamespace(string nspace)
        {
            m_classInfo.Namespace = nspace;
            return this;
        }

        public ClassInfoBuilder SetParent(string baseClass)
        {
            m_classInfo.Parent = baseClass;
            return this;
        }
        public ClassInfoBuilder SetProtocolId(string pid)
        {
            m_classInfo.ProtocolId = pid;
            return this;
        }
        public ClassInfoBuilder AddUsing(string import)
        {
            m_classInfo.Usings.Add(import);
            return this;
        }

        public ClassInfoBuilder SetProperties(List<PropertyInfo> properties)
        {
            m_classInfo.Properties = properties;
            return this;
        }

        public ClassInfo Build() { return m_classInfo; }
    }
}
