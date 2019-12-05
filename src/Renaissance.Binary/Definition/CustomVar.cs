namespace Renaissance.Binary.Definition
{
    public struct CustomVar<T>
    {
        public T Value { get; set; }

        public CustomVar(T value)
            => this.Value = value;

        public static explicit operator CustomVar<T>(T value)
            => new CustomVar<T>(value);

        public static implicit operator T(CustomVar<T> customVar)
            => customVar.Value;

    }
}
