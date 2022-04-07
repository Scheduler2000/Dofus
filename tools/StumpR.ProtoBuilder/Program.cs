using StumpR.ProtoBuilder.Converter.DataCenter;
using StumpR.ProtoBuilder.Converter.Enum;
using StumpR.ProtoBuilder.Converter.Message;
using StumpR.ProtoBuilder.Converter.Type;
using StumpR.ProtoBuilder.Parser;

/* ReSharper disable All */
#pragma warning disable CS0219

var protocolTypeManagerPath =
    @"C:\Users\Salamender\Desktop\scripts\com\ankamagames\dofus\network\ProtocolTypeManager.as";
var messageReceiverPath = @"C:\Users\Salamender\Desktop\scripts\com\ankamagames\dofus\network\MessageReceiver.as";


await ProtocolTypeParser.InitializeStore(protocolTypeManagerPath);
await MessageReceiverParser.InitializeStore(messageReceiverPath);


var enumPath = @"C:\Users\Salamender\Desktop\scripts\com\ankamagames\dofus\network\enums";
var dataCenterPath = @"C:\Users\Salamender\Desktop\scripts\com\ankamagames\dofus\datacenter";
var typePath = @"C:\Users\Salamender\Desktop\scripts\com\ankamagames\dofus\network\types";
var messagePath = @"C:\Users\Salamender\Desktop\scripts\com\ankamagames\dofus\network\messages";


var enumGenerator = new EnumGenerator(enumPath);
var dataCenterGenerator = new DatacenterGenerator(dataCenterPath);
var typeGenerator = new TypeGenerator(typePath);
var messageGenerator = new MessageGenerator(messagePath);

var enumTemplateFile =
    @"C:\Users\Salamender\Desktop\dev\PERSONAL\StumpR\tools\StumpR.ProtoBuilder\Template\EnumTemplate.sbncs";

var dataCenterTemplateFile =
    @"C:\Users\Salamender\Desktop\dev\PERSONAL\StumpR\tools\StumpR.ProtoBuilder\Template\DataCenterTemplate.sbncs";

var typeTemplateFile =
    @"C:\Users\Salamender\Desktop\dev\PERSONAL\StumpR\tools\StumpR.ProtoBuilder\Template\TypeTemplate.sbncs";

var messageTemplateFile =
    @"C:\Users\Salamender\Desktop\dev\PERSONAL\StumpR\tools\StumpR.ProtoBuilder\Template\NetworkMessage.sbncs";


// await Task.WhenAll(typeGenerator.GenerateFiles(typeTemplateFile),
//     dataCenterGenerator.GenerateFiles(dataCenterTemplateFile),
//     enumGenerator.GenerateFiles(enumTemplateFile),
//     messageGenerator.GenerateFiles(messageTemplateFile));

await messageGenerator.GenerateFiles(messageTemplateFile);

Console.WriteLine("Press any key to exit...");
Console.ReadKey(true);