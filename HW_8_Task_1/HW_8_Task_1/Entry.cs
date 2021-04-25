using System;

namespace HW_8_Task_1
{
    public class Entry
    {
        public string Key { get; set; }

        public string Pointer { get; set; }

        public bool Equals(Entry other)
        {
            return Key.Equals(other.Key) && Pointer.Equals(other.Pointer);
        }
    }
}

