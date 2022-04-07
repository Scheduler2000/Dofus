using Scriban;
using StumpR.ProtoBuilder.Helpers;
using StumpR.ProtoBuilder.Parser;

namespace StumpR.ProtoBuilder.Converter;

public abstract class ProtocolGenerator
{
    private readonly string _directoryPath;
    private readonly IParser _parser;
    private readonly SearchOption _searchOption;

    protected ProtocolGenerator(string directoryPath, SearchOption searchOption, IParser parser)
    {
        _parser = parser;
        _directoryPath = directoryPath;
        _searchOption = searchOption;
    }

    public async Task GenerateFiles(string templateFile)
    {
        Console.WriteLine($"------------ Generating {_parser.ParserType} files ------------ : \n");

        var files = Directory.EnumerateFiles(_directoryPath, "*.*", _searchOption).ToList();
        var helper = @$"{Directory.GetParent(templateFile)}\Helper.sbncs";

        var template = Template.Parse(await File.ReadAllTextAsync(helper) + await File.ReadAllTextAsync(templateFile));


        await Parallel.ForEachAsync(files, async (file, token) =>
        {
            try
            {
                var templateInfo = _parser.Parse(file);

                var rendered = await template.RenderAsync(templateInfo).ConfigureAwait(false);
                var fileName = Path.GetFileNameWithoutExtension(file);
                var output = @$"{Path.GetFullPath(file).RemoveCharactersFromTheEnd('\\')}\{fileName}.cs";

                await File.WriteAllTextAsync(output, rendered, token).ConfigureAwait(false);
                File.Delete(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Parsing error regarding {file} : \n {ex}");
            }
        });


        Console.WriteLine($"{Environment.NewLine} {files.Count} {_parser.ParserType}s generated !");
        Console.WriteLine("-----------------------------------------------\n");
    }
}