namespace FullDotNet.Internal
{
    public interface IValue<T>
    {
        T Value { get; }
    }
}