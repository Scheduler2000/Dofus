using System;
using System.Linq;
using System.Text;

namespace Renaissance.Tools.ProtoBuilder.Util
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string input)
        {
            if (input[0] == '_')
                input = input.Remove(0, 1);

            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };
        }

        public static string FirstCharToLower(this string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToLower() + input.Substring(1)
            };
        }

        public static string DofusTypeToRenaissance(this string name) => name switch
        {
            "VarShort" => "CustomVar<short>",
            "VarLong" => "CustomVar<long>",
            "VarInt" => "CustomVar<int>",
            "UTF" => "string",
            "Boolean" => "bool",
            "Byte" => "byte",
            "Int" => "int",
            "Short" => "short",
            "Double" => "double",
            "Bytes" => "byte[]",
            "Float" => "float",
            "UnsignedInt" => "uint",
            _ => name
        };

        public static string RemoveCharactersFromTheEnd(this string str, char stop)
        {
            int count = 1;

            for (int i = str.Length - 1; i > 0; i--)
            {

                if (str[i] == stop)
                    break;
                count++;
            }
            return str.Substring(0, str.Length - count);
        }

        public static string ParentClassName(this string str)
        {
            StringBuilder parent = new StringBuilder();

            for (int i = 2; i < str.Length; i++)
            {
                if (str[i] == ',')
                    break;
                else parent.Append(str[i]);
            }

            return parent.ToString();
        }
    }
}
