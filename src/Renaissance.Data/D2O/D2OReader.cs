using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Renaissance.Binary;
using Renaissance.Data.D2O.Structure;

namespace Renaissance.Data.D2O
{
    public class D2OReader
    {
        private DofusReader m_reader;
        private GameDataCreator m_creator;
        private IEnumerable<Type> m_dataCenter;

        private Dictionary<int, GameDataClassDefintion> m_classes;
        private Dictionary<int, int> m_indexes;


        public D2OReader(byte[] data, IEnumerable<Type> dataCenter)
        {
            this.m_reader = new DofusReader(data);
            this.m_dataCenter = dataCenter;
            this.m_creator = new GameDataCreator(ReadField);

            this.m_classes = new Dictionary<int, GameDataClassDefintion>();
            this.m_indexes = new Dictionary<int, int>();

            Initialize();
        }


        private void Initialize()
        {
            var header = m_reader.ReadUTBytes(3);

            if (header != "D2O")
                throw new FormatException("Header doesn't equal the string \"D2O\" : Corrupted file");

            ReadIndexTable();
            ReadClassesTable();

        }

        private void ReadIndexTable()
        {
            var headerOffset = m_reader.Read<int>();
            m_reader.Position = headerOffset;

            var indexTableLen = m_reader.Read<int>();
            this.m_indexes = new Dictionary<int, int>(indexTableLen / 8);

            for (int i = 0; i < indexTableLen; i += 8)
                m_indexes.Add(m_reader.Read<int>(), m_reader.Read<int>());
        }

        private void ReadClassesTable()
        {
            var classCount = m_reader.Read<int>();
            this.m_classes = new Dictionary<int, GameDataClassDefintion>(classCount);

            for (int i = 0; i < classCount; i++)
            {
                var key = m_reader.Read<int>();
                var className = m_reader.Read<string>();
                className = (className.Length > 4 && className.Substring(className.Length - 4) == "Data") ? className : className + "Data";
                var packageName = m_reader.Read<string>();

                var type = m_dataCenter.FirstOrDefault(x => x.Name == className)
                    ?? throw new NullReferenceException($"Type null {className} doesn't exist");

                var fieldsLen = m_reader.Read<int>();
                var fields = new List<GameDataField>(fieldsLen);

                for (int j = 0; j < fieldsLen; j++)
                {
                    var fieldName = m_reader.Read<string>();
                    fieldName = $"m_{char.ToLower(fieldName[0]).ToString()}{fieldName.Substring(1)}";
                    var fieldType = (GameDataTypeEnum)(m_reader.Read<int>());
                    var vectorTypes = new List<Tuple<GameDataTypeEnum, string>>();

                    if (fieldType == GameDataTypeEnum.List)
                    {
                        GameDataTypeEnum dataField;

                        do
                        {
                            var item = m_reader.Read<string>().Replace("_", "");
                            dataField = (GameDataTypeEnum)m_reader.Read<int>();
                            vectorTypes.Add(Tuple.Create(dataField, item));
                        } while (dataField == GameDataTypeEnum.List);
                    }

                    var fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                        ?? throw new NullReferenceException(string.Format("Missing field '{0}' ({1}) in class '{2}'",
                                                             fieldName, fieldType, type.Name));

                    fields.Add(new GameDataField(fieldName, fieldType, m_reader.Position, fieldInfo, vectorTypes.ToArray()));
                }

                m_classes.Add(key, new GameDataClassDefintion(fields.ToDictionary(entry => entry.Name),
                                                              key, className, packageName, type, m_reader.Position));
            }
        }

        public Dictionary<int, object> ReadObjects(bool allownulled = false)
        {
            var result = new Dictionary<int, object>(m_indexes.Count);


            foreach (var index in m_indexes)
            {
                m_reader.Position = index.Value;

                try { result.Add(index.Key, ReadObject(index.Key)); }

                catch (Exception ex)
                {
                    if (allownulled)
                        result.Add(index.Key, null);
                    else
                        Console.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        public object ReadObject(int index)
        {
            var offset = m_indexes[index];

            m_reader.Position = offset;

            var classid = m_reader.Read<int>();

            var result = m_creator.BuildObject(m_classes[classid]);

            return result;
        }

        private object ReadField(GameDataField field, GameDataTypeEnum dataType, int vectorDimension = 0)
        {
            switch (dataType)
            {
                case GameDataTypeEnum.Int:
                    return m_reader.Read<int>();

                case GameDataTypeEnum.Bool:
                    return m_reader.Read<byte>() != 0;

                case GameDataTypeEnum.String:
                    return m_reader.Read<string>();

                case GameDataTypeEnum.Double:
                    return m_reader.Read<double>();

                case GameDataTypeEnum.I18N:
                    return m_reader.Read<int>();

                case GameDataTypeEnum.UInt:
                    return m_reader.Read<uint>();

                case GameDataTypeEnum.List:
                    return ReadFielVector(field, vectorDimension);

                default: /* Reading an object */
                    var classId = m_reader.Read<int>();
                    return classId == unchecked((int)0xAAAAAAAA)
                                        ? null : m_classes.Keys.Contains(classId)
                                        ? m_creator.BuildObject(m_classes[classId]) : null;
            }
        }

        private object ReadFielVector(GameDataField field, int vectorDimension)
        {
            var count = m_reader.Read<int>();
            var vectorType = field.FieldType;

            for (int i = 0; i < vectorDimension; i++)
                vectorType = vectorType.GetGenericArguments()[0];

            if (!m_creator.ObjetCreators.ContainsKey(vectorType))
                m_creator.ObjetCreators.Add(vectorType, m_creator.CreateObjectBuilder(vectorType));

            var result = m_creator.ObjetCreators[vectorType](new object[0]) as IList;

            for (int i = 0; i < count; i++)
            {
                vectorDimension++;

                try
                {
                    var obj = ReadField(field, field.VectorTypes[vectorDimension - 1].Item1, vectorDimension);
                    result.Add(obj);
                }
                catch (Exception ex)
                { Console.WriteLine(ex.ToString()); }

                vectorDimension--;
            }

            return result;
        }
    }
}