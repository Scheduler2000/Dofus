using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Renaissance.Abstract.Extensions;
using Renaissance.Abstract.Manager.Interface;
using Renaissance.Protocol.enums;
using Renaissance.World.Database.Breeds;
using Renaissance.World.Game.Actors.Look;

namespace Renaissance.World.Manager.Game.EntityLook
{
    public class EntityLookManager : IManager
    {
        public ContextActorLook Parse(string str)
        {
            if (str == string.Empty)
                return null;

            if (string.IsNullOrEmpty(str) || str[0] != '{')
                throw new Exception("Incorrect EntityLook format : " + str);
            int i = 1;
            int num = str.IndexOf('|');
            if (num == -1)
            {
                num = str.IndexOf("}");
                if (num == -1)
                    throw new Exception("Incorrect EntityLook format : " + str);
            }
            short bones = short.Parse(str.Substring(i, num - i));
            i = num + 1;
            short[] skins = new short[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                skins = ParseCollection(str.Substring(i, num - i), new Func<string, short>(short.Parse));
                i = num + 1;
            }
            var source = new Tuple<int, int>[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                source = ParseCollection(str.Substring(i, num - i), new Func<string, Tuple<int, int>>(ParseIndexedColor));
                i = num + 1;
            }
            short[] scales = new short[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                scales = ParseCollection(str.Substring(i, num - i), new Func<string, short>(short.Parse));
                i = num + 1;
            }
            var list = new List<ContextSubEntity>();
            while (i < str.Length && str[i] != '}')
            {
                int num2 = str.IndexOf('@', i, 3);
                int num3 = str.IndexOf('=', num2 + 1, 3);
                byte category = byte.Parse(str.Substring(i, num2 - i));
                byte b = byte.Parse(str.Substring(num2 + 1, num3 - (num2 + 1)));
                int num4 = 0;
                int num5 = num3 + 1;
                var stringBuilder = new StringBuilder();
                do
                {
                    stringBuilder.Append(str[num5]);
                    if (str[num5] == '{')
                        num4++;
                    else
                        if (str[num5] == '}')
                        num4--;
                    num5++;
                }
                while (num4 > 0);
                list.Add(new ContextSubEntity((SubEntityBindingPointCategoryEnum)category, b, Parse(stringBuilder.ToString())));
                i = num5 + 1;
            }

            var colors = new List<int>();
            foreach (var color in source)
                colors.Add(color.Item2);

            return new ContextActorLook(bones, skins.Select(entry => entry).ToList(), colors.ToList(), scales.ToList(), list);

        }

        public int[] VerifiyColors(IEnumerable<int> colors, bool sex, BreedRecord breed)
        {
            var defaultColors = !sex ? breed.MaleColors : breed.FemaleColors;

            if (colors.Count() == 0)
                return defaultColors.ToArray();

            int num = 0;

            var simpleColors = new List<int>();
            foreach (int current in colors)
            {
                if (defaultColors.Length > num)
                    simpleColors.Add(current == -1 ? defaultColors[num] : current);
                num++;
            }

            return simpleColors.ToArray();
        }

        public int[] GetConvertedColors(int[] colors)
        {
            int[] col = new int[colors.Count()];
            for (int i = 0; i < colors.Count(); i++)
            {
                var color = Color.FromArgb(colors.ToArray()[i]);
                col[i] = i + 1 << 24 | color.ToArgb() & 16777215;
            }
            return col;
        }

        public Dictionary<sbyte, int> GetConvertedColorsWithIndex(IEnumerable<int> data)
        {
            var colors = data.ToArray();

            var col = new Dictionary<sbyte, int>();
            for (int i = 0; i < colors.Count(); i++)
            {
                var color = Color.FromArgb(colors[i]);
                var colorValue = i + 1 << 24 | color.ToArgb() & 16777215;
                col.Add((sbyte)(colors[i] >> 24), colorValue);
            }
            return col;
        }

        public List<int> GetConvertedColorSortedByIndex(Dictionary<sbyte, int> convertedColorsWithIndex)
        {
            var colors = new List<int>();

            for (sbyte i = 1; i <= 5; i++)

                if (convertedColorsWithIndex.ContainsKey(i))
                    colors.Add(convertedColorsWithIndex[i]);
                else
                    colors.Add(-1);
            return colors;
        }

        public ContextActorLook GetBonesLook(short bonesId, short scale)
        {
            return new ContextActorLook(bonesId, new List<short>(), new List<int>(), new List<short>() { scale }, new List<ContextSubEntity>());
        }

        private Tuple<int, int> ParseIndexedColor(string str)
        {
            int num = str.IndexOf("=");
            bool flag = str[num + 1] == '#';
            int item = int.Parse(str.Substring(0, num));
            int item2 = int.Parse(str.Substring(num + (flag ? 2 : 1), str.Length - (num + (flag ? 2 : 1))), flag ? System.Globalization.NumberStyles.HexNumber : System.Globalization.NumberStyles.Integer);
            return Tuple.Create(item, item2);
        }

        private T[] ParseCollection<T>(string str, Func<string, T> converter)
        {
            T[] result;
            if (string.IsNullOrEmpty(str))
                result = new T[0];
            else
            {
                int num = 0;
                int num2 = str.IndexOf(',', 0);
                if (num2 == -1)
                    result = new T[]
                    {
                        converter(str)
                    };
                else
                {
                    var array = new T[str.CountOccurences(',', num, str.Length - num) + 1];
                    int num3 = 0;
                    while (num2 != -1)
                    {
                        array[num3] = converter(str.Substring(num, num2 - num));
                        num = num2 + 1;
                        num2 = str.IndexOf(',', num);
                        num3++;
                    }
                    array[num3] = converter(str.Substring(num, str.Length - num));
                    result = array;
                }
            }
            return result;
        }


    }
}
