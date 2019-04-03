namespace Spiral
{
    class Element<T>
    {
        public bool Visited { get; set; }
        public T Value { get; set; }

        private Element(T value) => Value = value;

        public static implicit operator Element<T>(T value) => new Element<T>(value);

        public static implicit operator T(Element<T> element) => element.Value;
    }
}
