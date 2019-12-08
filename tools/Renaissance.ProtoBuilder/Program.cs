using System;
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

            try
            {
                var eb = new EnumBuilder(enumPath);
                var mb = new MessageBuilder(messagePath);
                var tb = new TypeBuilder(typePath);

                mb.BuildFiles();
                tb.BuildFiles();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
