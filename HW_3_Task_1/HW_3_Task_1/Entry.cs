
namespace HW_3_Task_1
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
        /// Data to be associated with key.
        /// </summary>
        public string Data { get; set; }

        public bool Equals(Entry other)
            => Key.Equals(other.Key) && Data.Equals(other.Data);
    }
}
