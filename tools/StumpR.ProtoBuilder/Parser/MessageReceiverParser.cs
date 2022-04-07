using System.Text.RegularExpressions;
using StumpR.ProtoBuilder.Cache;
using StumpR.ProtoBuilder.Model.Parsing;

namespace StumpR.ProtoBuilder.Parser;

public static class MessageReceiverParser
{
    private static readonly Regex _messageReceiverDeclaration;

    private static readonly Dictionary<string, int> _messages;


    static MessageReceiverParser()
    {
        _messageReceiverDeclaration = RegexCache.Instance.GetRegex(RegexEnum.MessageReceiverDeclaration);
        _messages = new Dictionary<string, int>();
    }

    public static int TryGetMessageId(string messageName)
    {
        return _messages.TryGetValue(messageName, out var id) ? id : 0;
    }

    public static async Task InitializeStore(string pathToProtocolTypeManager)
    {
        var data = (await File.ReadAllTextAsync(pathToProtocolTypeManager)).Replace("\r", "");

        var match = _messageReceiverDeclaration.Match(data);

        while (match.Success)
        {
            var messageId = int.Parse(match.Groups["message_id"].Value);
            var messageName = match.Groups["message_name"].Value;

            _messages.Add(messageName, messageId);

            match = match.NextMatch();
        }
    }
}