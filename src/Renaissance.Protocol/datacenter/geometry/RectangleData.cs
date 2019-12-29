namespace Renaissance.Protocol.datacenter.geometry
{
    public class RectangleData : IDataCenter
    {
        private int m_width;
        private int m_height;
        private int m_x;
        private int m_y;

        public int Width { get => this.m_width; set => this.m_width = value; }
        public int Height { get => this.m_height; set => this.m_height = value; }
        public int X { get => this.m_x; set => this.m_x = value; }
        public int Y { get => this.m_y; set => this.m_y = value; }
    }
}
