using System.Collections.Generic;
using Renaissance.Tools.ProtoBuilder.Parsing;

namespace Renaissance.Tools.ProtoBuilder.Model
{

    public class ClassInfo
    {
        public string Name { get; set; }

        public string Namespace { get; set; }

        public string Parent { get; set; }

        public List<string> Usings { get; set; }

        public string ProtocolId { get; set; }

        public ConverterType ClassType { get; set; }

        public List<PropertyInfo> Properties { get; set; }

        public ClassInfo(ConverterType classType)
        {
            this.Usings = new List<string>();
            this.Properties = new List<PropertyInfo>();
            this.ClassType = classType;
        }
    }
}
