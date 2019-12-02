using Renaissance.Tools.ProtoBuilder.Builder;

namespace Renaissance.ProtoBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string messagePath = @"scripts\com\ankamagames\dofus\network\messages";
            string typePath = @"C:scripts\com\ankamagames\dofus\network\types";
            string enumPath = @"C:scripts\com\ankamagames\dofus\network\enums";

            var mb = new MessageBuilder(messagePath);
            var tb = new TypeBuilder(typePath);
            var eb = new EnumBuilder(enumPath);

            mb.BuildFiles();
            tb.BuildFiles();
            eb.BuildFiles();
        }
    }
}
