using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Renaissance.Tools.ProtoBuilder.Parsing;
using Renaissance.Tools.ProtoBuilder.Util;

namespace Renaissance.Tools.ProtoBuilder.Builder
{
    public abstract class AbstractBuilder<TConverter> where TConverter : IConverter, new()
    {
        private readonly TConverter m_converter;
        private readonly string m_directoryPath;
        private readonly SearchOption m_searchOption;

        public AbstractBuilder(string directoryPath, SearchOption searchOption)
        {
            this.m_converter = new TConverter();
            this.m_directoryPath = directoryPath;
            this.m_searchOption = searchOption;
        }

        public void BuildFiles() // TODO : SUB DIRECTORIES CREATE IN FOREACH LOOP 
        {
            Console.WriteLine($"------------ Generating {m_converter.ConverterType} files ------------ : \n");

            IEnumerable<string> files = Directory.EnumerateFiles(m_directoryPath, "*.*", m_searchOption);

            foreach (string file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);

                File.WriteAllText(@$"{Path.GetFullPath(file).RemoveCharactersFromTheEnd('\\')}\{fileName}.cs",
                    m_converter.Convert(file).ToString());

                File.Delete(file);
                Console.WriteLine($"\t-{fileName}.cs generated.");
            }


            Console.WriteLine($"{Environment.NewLine} {files.Count()} {m_converter.ConverterType}s generated !");
            Console.WriteLine($"-----------------------------------------------\n");
        }
    }
}
