namespace Renaissance.Binary.Definition
{
    public struct WrappedBool
    {
        public bool Value { get; set; }

        public WrappedBool(bool value)
            => this.Value = value;

        public static implicit operator WrappedBool(bool value)
            => new WrappedBool(value);
    }
}
