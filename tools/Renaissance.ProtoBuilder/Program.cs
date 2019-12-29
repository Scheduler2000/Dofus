using System;

using Renaissance.ProtoBuilder.Builder;
using Renaissance.Tools.ProtoBuilder.Builder;

namespace Renaissance.ProtoBuilder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string messagePath = @"scripts\com\ankamagames\dofus\network\messages";
            string typePath = @"scripts\com\ankamagames\dofus\network\types";
            string enumPath = @"scripts\com\ankamagames\dofus\network\enums";
            string d2oPath = @"scripts\com\ankamagames\dofus\datacenter";

            try
            {
                var eb = new EnumBuilder(enumPath);
                var mb = new MessageBuilder(messagePath);
                var tb = new TypeBuilder(typePath);

                var db = new DataCenterBuilder(d2oPath);

                db.BuildFiles();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
    }
}
