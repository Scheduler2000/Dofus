namespace Renaissance.Data.D2P.Mapping.Util
{

    public class ColorMultiplicator
    {
        public int Clamp(int param1, int param2, int param3)
            => param1 > param3 ? param3 : (param1 < param2 ? param2 : param1);
    }
}
