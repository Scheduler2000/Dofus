using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Renaissance.Tools.ProtoBuilder.Model;
using Renaissance.Tools.ProtoBuilder.Model.Builder;
using Renaissance.Tools.ProtoBuilder.Parsing;
using Renaissance.Tools.ProtoBuilder.Util;

namespace Renaissance.ProtoBuilder.Parsing
{
    /// <summary>
    /// <see cref="DataCenterConverter"/> converts com.ankamagames.dofus.datacenter files to C#.
    /// </summary>
    public class DataCenterConverter : IConverter
    {
        public ConverterType ConverterType { get; } = ConverterType.D2OType;

        public StringBuilder Convert(string filePath)
        {
            string[] file = File.ReadAllLines(filePath);

            var classInfo = Parse(file);

            return WriteData(classInfo);
        }

        private int ParseHeaderClass(string[] file, ClassInfoBuilder cib)
        {
            var ClassDeclaration = new Regex(@"^\s*public class ([A-z]*) extends ([A-z]*)\s*implements [A-z]*");
            var ClassDeclarationSimple = new Regex(@"^\s*public class ([A-z]*)\s*implements ([A-z]*)");
            var otherClassDeclaration = new Regex(@"^\s*public class ([A-z]*) extends ([A-z]*)");

            bool endHeader = false;
            string dataCenterImport = "import com.ankamagames.dofus.datacenter";

            cib.SetPackage(file[0].Substring(8));
            cib.SetNamespace(file[0].Replace("package com.ankamagames.dofus.datacenter",
                "namespace Renaissance.Protocol.datacenter"));

            int i;
            string baseInterface = "IDataCenter";
            for (i = 0; i < file.Length && !endHeader; i++)
            {

                if (file[i].Contains(dataCenterImport))
                    cib.AddUsing($"{file[i].Replace(dataCenterImport, "Renaissance.Protocol.datacenter").RemoveCharactersFromTheEnd('.')};");

                if (ClassDeclaration.IsMatch(file[i]))
                {
                    Match match = ClassDeclaration.Match(file[i]);

                    cib.SetClassName($"{match.Groups[1].Value}Data")
                       .SetParent($": {match.Groups[2].Value}Data, {baseInterface}");
                    endHeader = true;
                }
                if (ClassDeclarationSimple.IsMatch(file[i]))
                {
                    Match match = ClassDeclarationSimple.Match(file[i]);

                    cib.SetClassName($"{match.Groups[1].Value}Data")
                       .SetParent($": {baseInterface}");
                    endHeader = true;
                }

                if (otherClassDeclaration.IsMatch(file[i]))
                {
                    Match match = otherClassDeclaration.Match(file[i]);

                    cib.SetClassName($"{match.Groups[1].Value}Data")
                       .SetParent($": {match.Groups[2].Value}Data");
                    endHeader = true;
                }
            }
            return i;
        }

        private List<PropertyInfoBuilder> ParsePropertiesName(string[] file, int startIndex, out int lastIndex)
        {
            var properties = new List<PropertyInfoBuilder>();
            bool endProperties = false;

            var propertyDeclaration = new Regex(@"^[\s]*public[\s]*var[\s*]([A-z]*):([A-z]*)");
            var ctorDeclaration = new Regex(@"^[\s]*public function [A-z]*\(\)");
            var vectorDeclaration = new Regex(@"^[\s]*public[\s]*var[\s*]([A-z]*):Vector.<([A-z]*)>;");
            var vectorOfVectorDeclaration = new Regex(@"^[\s]*public[\s]*var[\s*]([A-z]*):Vector.<Vector.<([A-z]*)>>;");
            int i;
            for (i = startIndex; i < file.Length && !endProperties; i++)
            {
                if (propertyDeclaration.IsMatch(file[i]))
                {
                    var piBuilder = new PropertyInfoBuilder();
                    Match match = propertyDeclaration.Match(file[i]);
                    string type = match.Groups[2].Value;
                    piBuilder.SetName(match.Groups[1].Value.FirstCharToUpper());

                    if (type.Contains("Number"))
                        piBuilder.SetType(type.Replace("Number", "double"));

                    else if (type.Contains("Vector"))
                    {
                        string typeVec = vectorDeclaration.Match(file[i]).Groups[2].Value;

                        if (typeVec == string.Empty)
                        {
                            var t = vectorOfVectorDeclaration.Match(file[i]).Groups[2].Value;

                            if (t.Contains("Number"))
                                t = t.Replace("Number", "double");

                            piBuilder.SetType($"List<List<{t}>>");
                        }
                        else
                        {
                            if (typeVec.Contains("Number"))
                                typeVec = typeVec.Replace("Number", "double");

                            piBuilder.SetType($"List<{typeVec}>");
                        }
                    }
                    else piBuilder.SetType(type);

                    properties.Add(piBuilder);

                }

                if (ctorDeclaration.IsMatch(file[i]))
                    endProperties = true;
            }

            lastIndex = i;
            return properties;
        }

        private ClassInfo Parse(string[] file)
        {
            var classBuilder = new ClassInfoBuilder(ConverterType);
            var properties = new List<PropertyInfo>();

            int index = ParseHeaderClass(file, classBuilder);
            ParsePropertiesName(file, index, out int lastIndex).ForEach(x => properties.Add(x.Build())); ;

            return classBuilder.SetProperties(properties).Build();
        }

        private StringBuilder WriteData(ClassInfo classInfo)
        {

            var writer = new StringBuilder();

            writer.AppendLine("//-------------------------------------------------------------------------------")
                  .AppendLine("// <auto-generated>")
                  .AppendLine("//	This code was generated by a tool.")
                  .AppendLine($"//  Generated on {DateTime.Now}.")
                  .AppendLine("//	Changes to this file may cause incorrect behavior !")
                  .AppendLine("//  Author : Scheduler.")
                  .AppendLine("// </auto-generated>")
                  .AppendLine("//-------------------------------------------------------------------------------\n");

            writer.AppendLine("using    System;")
                  .AppendLine("using    System.Collections.Generic;")
                  .AppendLine("using    Renaissance.Protocol.datacenter.geometry;");

            classInfo.Usings.ForEach(u => writer.AppendLine($"using {u}"));
            writer.Append(Environment.NewLine);

            writer.AppendLine($"{classInfo.Namespace}")
                  .AppendLine("{");

            if (classInfo.Parent != null && classInfo.Parent.Contains("IDataCenter"))
                writer.AppendLine($"\t[D2OClass(\"{classInfo.Name.Substring(0, classInfo.Name.Length - 4)}\", \"{classInfo.Package}\")]");

            writer.AppendLine($"\tpublic class {classInfo.Name} {classInfo.Parent}")
                  .AppendLine("\t{")
                  .Append(Environment.NewLine);

            classInfo.Properties.ForEach(property =>
                    writer.AppendLine($"\t\tprivate {property.Type} m_{property.Name.FirstCharToLower()};"));
            writer.Append(Environment.NewLine);

            classInfo.Properties.ForEach(property =>
                    writer.AppendLine($"\t\tpublic {property.Type} {property.Name}")
                          .AppendLine("\t\t{")
                          .AppendLine($"\t\t\tget => m_{property.Name.FirstCharToLower()};")
                          .AppendLine($"\t\t\tset => m_{property.Name.FirstCharToLower()} = value;")
                          .AppendLine("\t\t}")
                          .Append(Environment.NewLine));

            writer.Append(Environment.NewLine)
                  .AppendLine("\t}")
                  .AppendLine("}");

            return writer;
        }
    }
}
