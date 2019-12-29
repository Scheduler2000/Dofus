namespace Renaissance.Protocol.datacenter.other
{
    public class AnimFunData : IDataCenter
    {
        protected int m_animId;
        protected int m_entityId;
        protected string m_animName;
        protected int m_animWeight;

        public int AnimId { get => this.m_animId; set => this.m_animId = value; }
        public int EntityId { get => this.m_entityId; set => this.m_entityId = value; }
        public string AnimName { get => this.m_animName; set => this.m_animName = value; }
        public int AnimWeight { get => this.m_animWeight; set => this.m_animWeight = value; }
    }
}
