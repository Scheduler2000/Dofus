using System;

namespace Renaissance.Protocol.datacenter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class D2OClass : Attribute
    {
        public string Name { get; set; }

        public string Package { get; set; }

        public D2OClass(string name, string package)
        {
            this.Name = name;
            this.Package = package;
        }
    }
}
