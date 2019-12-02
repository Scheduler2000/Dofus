using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Renaissance.Tools.ProtoBuilder.Model;
using Renaissance.Tools.ProtoBuilder.Model.Builder;
using Renaissance.Tools.ProtoBuilder.Util;

namespace Renaissance.Tools.ProtoBuilder.Parsing
{
    /// <summary>
    /// <see cref="ClassConverter"/> converts com.ankamagames.dofus.network files(message/type) to C#.
    /// </summary>
    public abstract class ClassConverter : IConverter
    {
        public ConverterType ConverterType { get; }

        public ClassConverter(ConverterType converterType)
            => this.ConverterType = converterType;

        public StringBuilder Convert(string filePath)
        {
            string[] file = File.ReadAllLines(filePath);
            var classInfo = Parse(file);

            return WriteData(classInfo);
        }

        private int ParseHeaderClass(string[] file, ClassInfoBuilder cib)
        {
            Regex ClassDeclaration = new Regex(@"^\s*public class ([A-z]*) extends ([A-z]*)\s*implements [A-z]*");
            Regex ClassDeclarationSimple = new Regex(@"^\s*public class ([A-z]*)\s*implements ([A-z]*)");
            Regex ProtocolId = new Regex(@"^\s*public static const protocolId:uint = ([0-9]*);");

            bool endHeader = false;
            string dofusMessage = "import com.ankamagames.dofus.network.messages";
            string dofusType = "import com.ankamagames.dofus.network.types";

            cib.SetNamespace(file[0].Replace("package com.ankamagames.dofus.network",
                "namespace Renaissance.Protocol"));

            int i;
            string baseInterface = ConverterType == ConverterType.NetworkMessage ? "IDofusMessage" : "IDofusType";
            for (i = 0; i < file.Length && !endHeader; i++)
            {
                if (file[i].Contains(dofusType))
                    cib.AddUsing($"{file[i].Replace(dofusType, "Renaissance.Protocol.types").RemoveCharactersFromTheEnd('.')};");

                if (file[i].Contains(dofusMessage))
                    cib.AddUsing($"{file[i].Replace(dofusMessage, "Renaissance.Protocol.messages").RemoveCharactersFromTheEnd('.')};");

                if (ClassDeclaration.IsMatch(file[i]) || ClassDeclarationSimple.IsMatch(file[i]))
                {
                    Match match = ClassDeclaration.IsMatch(file[i])
                        ? ClassDeclaration.Match(file[i])
                        : ClassDeclarationSimple.Match(file[i]);
                    cib.SetClassName(match.Groups[1].Value)
                       .SetParent(match.Groups[2].Value == "NetworkMessage" | match.Groups[2].Value == "INetworkType"
                     ? $": {baseInterface}"
                     : $": {match.Groups[2].Value}, {baseInterface}"); ;

                }
                if (ProtocolId.IsMatch(file[i]))
                {
                    Match match = ProtocolId.Match(file[i]);
                    cib.SetProtocolId(match.Groups[1].Value);
                    endHeader = true;
                }

            }
            return i;
        }

        private List<PropertyInfoBuilder> ParsePropertiesName(string[] file, int startIndex, out int lastIndex)
        {
            var properties = new List<PropertyInfoBuilder>();
            bool endProperties = false;

            Regex propertyDeclaration = new Regex(@"^[\s]*public[\s]*var[\s*]([A-z]*):([A-z]*)");
            Regex ctorDeclaration = new Regex(@"^[\s]*public function [A-z]*\(\)");

            int i;
            string type = default; // For custom type like AcquaintanceInformation
            for (i = startIndex; i < file.Length && !endProperties; i++)
            {
                if (propertyDeclaration.IsMatch(file[i]))
                {
                    PropertyInfoBuilder piBuilder = new PropertyInfoBuilder();
                    Match match = propertyDeclaration.Match(file[i]);
                    type = match.Groups[2].Value;
                    piBuilder.SetName(match.Groups[1].Value.FirstCharToUpper());

                    if (type.DofusTypeToRenaissance() == type && type.DofusTypeToRenaissance() != "Vector") // Si c'est un objet de nature "Type"
                        piBuilder.SetType(type);


                    properties.Add(piBuilder);

                }

                if (ctorDeclaration.IsMatch(file[i]))
                    endProperties = true;
            }

            lastIndex = i;
            return properties;
        }

        private int ParsePropertiesGetter(string[] file, int startIndex, List<PropertyInfoBuilder> properties)
        {
            Regex getterDeclaration = new Regex(@"^[\s]*public function get[\s*]([A-z]*)\(\) : [A-z]*");
            Regex serializeFncReg = new Regex(@"^(\s*)public(\s*)function(\s*)serializeAs_([A-z]*)\(output:ICustomDataOutput\)*");

            bool isInFncSerialize = false;
            int i;

            for (i = startIndex; i < file.Length && !isInFncSerialize; i++)
            {
                if (serializeFncReg.IsMatch(file[i]))
                    isInFncSerialize = true;
                if (getterDeclaration.IsMatch(file[i]))
                {
                    var piBuilder = new PropertyInfoBuilder();
                    var match = getterDeclaration.Match(file[i]);
                    piBuilder.SetName(match.Groups[1].Value.FirstCharToUpper());
                    properties.Add(piBuilder);
                }

            }
            return i;
        }

        private void ParsePropertiesTypeAttribute(string[] file, int startIndex, List<PropertyInfoBuilder> properties)
        {
            Regex deserializeFncReg = new Regex(@"^(\s*)public(\s*)function(\s*)deserialize\(input:ICustomDataInput\)*");

            Regex arraySizeWriteCall = new Regex(@"^(\s*)output.write([A-z]*)\(this.([A-z]*).length\);");
            Regex booleanByteCall = new Regex(@"^\s*_box[0-9] = BooleanByteWrapper.setFlag\(_box[0-9],([0-9]*),this.([A-z]*)\);");

            Regex serializeObject = new Regex(@"^\s*this.([A-z]*).serializeAs_([A-z]*)\(output\);");
            Regex serializeObject2 = new Regex(@"^\s*this.([A-z]*).serialize\(output\);");
            Regex arraySerializePrimitiveCall = new Regex(@"^(\s*)output.write([A-z]*)\(this.([A-z]*)\[[A-z0-9]*\]\);");
            Regex arraySerializeCall = new Regex(@"^\s*\(this.([A-z]*)\[_*[A-Za-z0-9]*] as ([A-z]*)\).([A-z]*)\([A-z]*\);");
            Regex arraySerializeCallType = new Regex(@"^\s*this.([A-z]*)\[_*[A-Za-z0-9]*].serializeAs_([A-z]*)\(output\);");
            Regex primitiveWriteCall = new Regex(@"^\s*output.write([A-z]*)\(this.([A-z]*)\);");

            string propertyName = default;
            string lenWriteType = default;
            string propertyType = default;
            bool isInFncSerialize = true;


            for (int i = startIndex; i < file.Length && isInFncSerialize; i++)
            {
                if (deserializeFncReg.IsMatch(file[i]))
                    isInFncSerialize = false;

                else if (arraySizeWriteCall.IsMatch(file[i]))
                {
                    var match = arraySizeWriteCall.Match(file[i]);
                    lenWriteType = match.Groups[2].Value.DofusTypeToRenaissance();
                    propertyName = match.Groups[3].Value.FirstCharToUpper();
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetLenWriteType(lenWriteType);
                }

                else if (booleanByteCall.IsMatch(file[i]))
                {
                    var match = booleanByteCall.Match(file[i]);
                    propertyName = match.Groups[2].Value.FirstCharToUpper();
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsWrappedBool)
                                .SetType("WrappedBool");
                }

                else if (serializeObject.IsMatch(file[i]))
                {
                    var match = serializeObject.Match(file[i]);
                    propertyName = match.Groups[1].Value.FirstCharToUpper();
                    propertyType = match.Groups[2].Value.DofusTypeToRenaissance();
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsObjectType)
                                .SetType(propertyType);
                }

                else if (serializeObject2.IsMatch(file[i])) // DofusType is often guess.
                {
                    var match = serializeObject2.Match(file[i]);
                    propertyName = propertyName = match.Groups[1].Value.FirstCharToUpper();
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsObjectType)
                                .SetHasGetterTypeId(true);
                }

                else if (arraySerializeCall.IsMatch(file[i]))
                {
                    var match = arraySerializeCall.Match(file[i]);
                    propertyName = match.Groups[1].Value.FirstCharToUpper();
                    propertyType = match.Groups[2].Value;
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsObjectArray)
                                .SetHasGetterTypeId(file[i - 1].Contains("getTypeId()"))
                                .SetType($"{propertyType}[]");

                }
                else if (arraySerializeCallType.IsMatch(file[i]))
                {
                    var match = arraySerializeCallType.Match(file[i]);
                    propertyName = match.Groups[1].Value.FirstCharToUpper();
                    propertyType = match.Groups[2].Value;
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsObjectArray)
                                .SetHasGetterTypeId(file[i - 1].Contains("getTypeId()"))
                                .SetType($"{propertyType}[]");
                }

                else if (arraySerializePrimitiveCall.IsMatch(file[i]))
                {
                    var match = arraySerializePrimitiveCall.Match(file[i]);
                    propertyName = match.Groups[3].Value.FirstCharToUpper();
                    propertyType = match.Groups[2].Value.DofusTypeToRenaissance();
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsPrimitiveArray)
                                .SetType($"{propertyType}[]");
                }

                else if (primitiveWriteCall.IsMatch(file[i]))
                {
                    var match = primitiveWriteCall.Match(file[i]);
                    propertyName = match.Groups[2].Value.FirstCharToUpper();
                    propertyType = match.Groups[1].Value.DofusTypeToRenaissance();
                    var propertyInfo = properties.Find(x => x.PropertieName == propertyName);
                    propertyInfo.SetPropertyType(PropertyType.IsPrimitiveType)
                                .SetType(propertyType);
                }
            }
        }

        private ClassInfo Parse(string[] file)
        {
            ClassInfoBuilder classBuilder = new ClassInfoBuilder(ConverterType);
            List<PropertyInfo> properties = new List<PropertyInfo>();

            int index = ParseHeaderClass(file, classBuilder);
            List<PropertyInfoBuilder> propertiesBuilder = ParsePropertiesName(file, index, out int lastIndex);
            int serializeIndex = ParsePropertiesGetter(file, lastIndex, propertiesBuilder);
            ParsePropertiesTypeAttribute(file, serializeIndex, propertiesBuilder);

            propertiesBuilder.ForEach(x => properties.Add(x.Build()));
            return classBuilder.SetProperties(properties).Build();
        }

        private StringBuilder WriteData(ClassInfo classInfo)
        {
            StringBuilder writer = new StringBuilder();
            string baseInterface = ConverterType == ConverterType.NetworkMessage ? "IDofusMessage" : "IDofusType";
            string overrideWithNew = ($": {baseInterface}" == classInfo.Parent) ? string.Empty : "new";
            string getterSetter = "{ get; set; }";
            int wrappedBoolCounter = 0;

            writer.AppendLine("//-------------------------------------------------------------------------------")
                  .AppendLine("// <auto-generated>")
                  .AppendLine("//	This code was generated by a tool.")
                  .AppendLine($"//  Generated on {DateTime.Now}.")
                  .AppendLine("//	Changes to this file may cause incorrect behavior !")
                  .AppendLine("//  Author : Scheduler.")
                  .AppendLine("// </auto-generated>")
                  .AppendLine("//-------------------------------------------------------------------------------\n");

            writer.AppendLine("using    Renaissance.Binary;")
                  .AppendLine("using    Renaissance.Binary.Definition;");

            classInfo.Usings.ForEach(u => writer.AppendLine($"using {u}"));
            writer.Append(Environment.NewLine);

            writer.AppendLine($"{classInfo.Namespace}")
                  .AppendLine("{");

            writer.AppendLine($"\tpublic class {classInfo.Name} {classInfo.Parent}")
                  .AppendLine("\t{");

            writer.AppendLine($"\t\tpublic {overrideWithNew} const int NetworkId = {classInfo.ProtocolId};")
                  .AppendLine($"\t\tpublic {overrideWithNew} int ProtocolId " + "{ get { return NetworkId; } }")
                  .Append(Environment.NewLine);

            classInfo.Properties.ForEach(property =>
                      writer.AppendLine($"\t\tpublic {property.Type} {property.Name} {getterSetter}")
                            .Append(Environment.NewLine));

            writer.Append(Environment.NewLine)
                  .Append($"\t\tpublic {classInfo.Name}() ")
                  .Append("{ }")
                  .Append(Environment.NewLine)
                  .AppendLine(Environment.NewLine);

            writer.Append($"\t\tpublic {classInfo.Name} Init{classInfo.Name}(");
            for (int i = 0; i < classInfo.Properties.Count; i++)
                if (i == classInfo.Properties.Count - 1)
                    writer.Append($"{classInfo.Properties[i].Type} _{classInfo.Properties[i].Name.ToLower()}");
                else
                    writer.Append($"{classInfo.Properties[i].Type} _{classInfo.Properties[i].Name.ToLower()}, ");
            writer.Append(")")
                  .Append(Environment.NewLine)
                  .AppendLine("\t\t{")
                  .Append(Environment.NewLine);
            classInfo.Properties.ForEach(property => writer.AppendLine($"\t\t\tthis.{property.Name} = _{property.Name.ToLower()};"));
            writer.Append(Environment.NewLine)
                  .AppendLine("\t\t\treturn this;")
                  .AppendLine("\t\t}")
                  .Append(Environment.NewLine);

            writer.AppendLine($"\t\tpublic {overrideWithNew} byte[] Serialize()")
                  .AppendLine("\t\t{")
                  .Append(Environment.NewLine)
                  .AppendLine("\t\t\tusing DofusWriter writer = new DofusWriter();")
                  .Append(Environment.NewLine);

            if (classInfo.Parent != ": IDofusMessage" && classInfo.Parent != ": IDofusType")
                writer.AppendLine("\t\t\twriter.Write(base.Serialize());");

            if (classInfo.Properties.Exists(property => property.PropertyType == PropertyType.IsWrappedBool))
            {
                writer.AppendLine("\t\t\tbyte box = 0;");
                foreach (var property in classInfo.Properties.Where(x => x.PropertyType == PropertyType.IsWrappedBool))
                {
                    writer.AppendLine($"\t\t\tbox = writer.SetFlag(box,{wrappedBoolCounter},this.{property.Name});");
                    if (classInfo.Properties.FindLast(x => x.Type == "WrappedBool").Name == property.Name)
                        writer.AppendLine("\t\t\twriter.Write(box);");
                    wrappedBoolCounter++;
                }
            }

            classInfo.Properties.ForEach(property =>
            {
                switch (property.PropertyType)
                {
                    case PropertyType.IsPrimitiveArray:
                        if (property.LenWriteType != null)
                            writer.AppendLine($"\t\t\twriter.Write(({property.LenWriteType})(this.{property.Name}.Length));");

                        writer.AppendLine($"\t\t\tforeach(var item in {property.Name})")
                              .AppendLine("\t\t\t\twriter.Write(item);");
                        break;
                    case PropertyType.IsObjectArray:
                        if (property.LenWriteType != null)
                            writer.AppendLine($"\t\t\twriter.Write(({property.LenWriteType})(this.{property.Name}.Length));");

                        writer.AppendLine($"\t\t\tforeach(var obj in {property.Name})")
                              .AppendLine("\t\t\t{");

                        if (property.HasGetterTypeId)
                            writer.AppendLine($"\t\t\t\twriter.Write((short)(obj.ProtocolId));");
                        writer.AppendLine("\t\t\t\twriter.Write(obj.Serialize());");
                        writer.AppendLine("\t\t\t}");
                        break;
                    case PropertyType.IsPrimitiveType:
                        writer.AppendLine($"\t\t\twriter.Write(this.{property.Name});");
                        break;
                    case PropertyType.IsObjectType:
                        if (property.HasGetterTypeId)
                            writer.AppendLine($"\t\t\twriter.Write((short)({property.Name}.ProtocolId));");
                        writer.AppendLine($"\t\t\twriter.Write(this.{property.Name}.Serialize());");
                        break;
                    case PropertyType.NULL:
                        Console.WriteLine("ERROR PROPERTY TYPE ON FILE : {0}", classInfo.Name);
                        break;
                }

            });
            writer.Append(Environment.NewLine)
                  .AppendLine("\t\t\treturn writer.Data;")
                  .AppendLine("\t\t}")
                  .Append(Environment.NewLine);
            wrappedBoolCounter = 0;


            writer.AppendLine($"\t\tpublic {overrideWithNew} void Deserialize(DofusReader reader)")
                  .AppendLine("\t\t{")
                  .Append(Environment.NewLine);

            if (classInfo.Parent != ": IDofusMessage" && classInfo.Parent != ": IDofusType")
                writer.AppendLine("\t\t\tbase.Deserialize(reader);");

            if (classInfo.Properties.Exists(property => property.PropertyType == PropertyType.IsWrappedBool))
            {
                writer.AppendLine("\t\t\tbyte box = reader.Read<byte>();");
                foreach (var property in classInfo.Properties.Where(x => x.PropertyType == PropertyType.IsWrappedBool))
                {
                    writer.AppendLine($"\t\t\tthis.{property.Name} = reader.ReadFlag(box,{wrappedBoolCounter});");
                    wrappedBoolCounter++;
                }
            }

            classInfo.Properties.ForEach(property =>
            {
                switch (property.PropertyType)
                {
                    case PropertyType.IsPrimitiveArray:
                        writer.AppendLine($"\t\t\tint {property.Name}_length = reader.Read<{property.LenWriteType}>();")
                              .AppendLine($"\t\t\tthis.{property.Name} = new {property.Type.RemoveCharactersFromTheEnd('[')}[{property.Name}_length];")
                              .AppendLine($"\t\t\tfor(int i = 0; i < {property.Name}_length; i++)")
                              .AppendLine($"\t\t\t\tthis.{property.Name}[i] = reader.Read<{property.Type.RemoveCharactersFromTheEnd('[')}>();");
                        break;
                    case PropertyType.IsObjectArray:
                        if (property.LenWriteType != null)
                            writer.AppendLine($"\t\t\tint {property.Name}_length = reader.Read<{property.LenWriteType}>();")
                              .AppendLine($"\t\t\tthis.{property.Name} = new {property.Type.RemoveCharactersFromTheEnd('[')}[{property.Name}_length];")
                              .AppendLine($"\t\t\tfor(int i = 0; i < {property.Name}_length; i++)")
                              .AppendLine("\t\t\t{");

                        if (property.HasGetterTypeId)
                            writer.AppendLine("reader.Skip(2); // skip read short for protocolManager.GetInstance(short)");

                        writer.AppendLine($"\t\t\t\tthis.{property.Name}[i] = new {property.Type.RemoveCharactersFromTheEnd('[')}();")
                              .AppendLine($"\t\t\t\tthis.{property.Name}[i].Deserialize(reader);")
                              .AppendLine("\t\t\t}");
                        break;
                    case PropertyType.IsPrimitiveType:
                        writer.AppendLine($"\t\t\tthis.{property.Name} = reader.Read<{property.Type}>();");
                        break;
                    case PropertyType.IsObjectType:
                        if (property.HasGetterTypeId)
                            writer.AppendLine("reader.Skip(2); // skip read short");

                        writer.AppendLine($"\t\t\tthis.{property.Name} = new {property.Type}();")
                              .AppendLine($"\t\t\tthis.{property.Name}.Deserialize(reader);");
                        break;
                    case PropertyType.NULL:
                        Console.WriteLine("ERROR PROPERTY TYPE ON FILE : {0}", classInfo.Name);
                        break;
                }
            });

            writer.Append(Environment.NewLine)
                  .AppendLine("\t\t}")
                  .Append(Environment.NewLine);


            writer.Append(Environment.NewLine)
                  .AppendLine("\t}")
                  .AppendLine("}");

            return writer;
        }
    }
}