namespace Renaissance.Data.D2P.Mapping.Util
{
    /// <summary>
    /// <see cref="Color"/> refers to com.ankamagames.jerakine.types.ColorMultiplicator
    /// </summary>
    public class Color
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public Color(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
    }
}
