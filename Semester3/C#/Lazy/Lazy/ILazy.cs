namespace Lazy
{
    /// <summary>
    /// An interface representing a lazy calculation.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public interface ILazy<T>
    {
        /// <summary>
        /// Returns the calculation result.
        /// </summary>
        /// <returns>Calculation result.</returns>
        T Get();
    }
}
