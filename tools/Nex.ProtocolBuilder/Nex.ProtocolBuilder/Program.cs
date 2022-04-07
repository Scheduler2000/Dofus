using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Nex.ProtocolBuilder.Builders;
using Nex.ProtocolBuilder.Builders.Nex.ProtocolBuilder.Builders;
using Nex.ProtocolBuilder.Generator;
using Nex.ProtocolBuilder.Parsers;
using Nex.ProtocolBuilder.Parsers.DataCenter;
using static System.Console;

namespace Nex.ProtocolBuilder
{
    internal class Program
    {
        internal static string InputPath { get; set; }
        internal static string OutputPath { get; set; }

        internal static string TypesNamespace = "StumpR.Protocol.Types";
        internal static string MessagesNamespace = "StumpR.Protocol.Messages";
        internal static string D2OClassesNamespace = "StumpR.Protocol.Datacenter";
        internal static string EnumsNamespace = "StumpR.Protocol.Enums";
        internal static string IONamespace = "StumpR.Binary";
        internal static void Main()
        {
            InputPath = $@"{Directory.GetCurrentDirectory()}/Input";
            OutputPath = $@"{Directory.GetCurrentDirectory()}/Output";
            if (!Directory.Exists(InputPath))
            {
                Directory.CreateDirectory(InputPath);
                WriteLine("ERR: Input folder is empty.");
                goto end;
            }


            if (Directory.Exists(OutputPath))
                Directory.Delete(OutputPath, true);

            Directory.CreateDirectory(OutputPath);

            retry:
            WriteLine("What to update ?");
            WriteLine("1 : network");
            WriteLine("2 : datacenter");

            switch(ReadKey().KeyChar)
            {
                case '1':
                    GenerateNetwork();
                    break;
                case '2':
                    GenerateDatacenter();
                    break;
                default:
                    WriteLine("Wrong number");
                    goto retry;
            }
            end:
            WriteLine("Press any key to exit.");
            ReadKey();
        }

        internal static void GenerateDatacenter()
        {
            WriteLine("Updating datacenter...");
            IEnumerable<string> files = Directory.EnumerateFiles(InputPath + "/scripts/com/ankamagames/dofus/datacenter/", "*.as", SearchOption.AllDirectories).ToArray();
            if (!files.Any())
            {
                WriteLine($"Unable to find any ActionScript (.as) files in path '{InputPath + "/scripts/com/ankamagames/dofus/datacenter/"}'");
                return;
            }
            foreach (var file in files)
            {
                string relativePath = GetRelativePath(file);
                if (!Directory.Exists(Path.Combine(OutputPath, "/DataCenter/", relativePath)))
                    Directory.CreateDirectory(Path.Combine(OutputPath, "/DataCenter/", relativePath));

                var parser = new DatacenterParser(file, DatacenterParser.BeforeParsingReplacementRules,
                        Array.Empty<string>())
                    { IgnoreMethods = true };

                try
                {
                    parser.ParseFile();
                    WriteLine("Parsed " + parser.Class.Name);
                }
                catch (InvalidCodeFileException)
                {
                    WriteLine("WARN: File {0} not parsed correctly", Path.GetFileName(file));
                    continue;
                }
                DatacenterGenerator.GenerateFile(parser);
            }

        }
        internal static void GenerateNetwork()
        {
            var provider = new AsProvider(InputPath);
            if (!provider.Files.Any())
            {
                WriteLine($"Unable to find any ActionScript (.as) files in path '{InputPath}'");
                return;
            }
            TypeMessageIdsParser.ParseIds(InputPath+ "/scripts/com/ankamagames/dofus/network/");

            var swMessages = Stopwatch.StartNew();
            var messagesBuilder =
                new ProtocolTypeMessageBuilder(
                    provider.Messages.Select(m => new TypeMessageParser(File.ReadAllLines(m))));
            messagesBuilder.ParseFiles();
            messagesBuilder.GenerateFiles();
            swMessages.Stop();

            var swTypes = Stopwatch.StartNew();
            var typesBuilder =
                new ProtocolTypeMessageBuilder(provider.Types.Select(m => new TypeMessageParser(File.ReadAllLines(m))));
            typesBuilder.ParseFiles();
            typesBuilder.GenerateFiles(true);
            swTypes.Stop();

            var swEnums = Stopwatch.StartNew();
            var enumsBuilder = new ProtocolEnumBuilder(provider.Enums.Select(m => new EnumParser(File.ReadAllText(m))));
            enumsBuilder.ParseFiles();
            enumsBuilder.GenerateFiles();
            swEnums.Stop();

            WriteLine($"> Messages generated in {swMessages.ElapsedMilliseconds}ms");
            WriteLine($"> Types generated in {swTypes.ElapsedMilliseconds}ms");
            WriteLine($"> Enums generated in {swEnums.ElapsedMilliseconds}ms");
        }
        public static string GetRelativePath(string file)
        {
            string folder = Path.GetDirectoryName(file);
            string[] foldersSplitted = folder.Split(new[] { "com/ankamagames/dofus/datacenter/" }, System.StringSplitOptions.RemoveEmptyEntries); // cut the source path and the "rest" of the path

            return foldersSplitted.Length > 1 ? foldersSplitted[1] : ""; // return the "rest"
        }
    }
}