
namespace HW_8_Task_1
{
    /// <summary>
    /// Stores BTree node data.
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Stored key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Pointer to be associated with key.
        /// </summary>
        public string Pointer { get; set; }

        public bool Equals(Entry other)
            => Key.Equals(other.Key) && Pointer.Equals(other.Pointer);
    }
}
