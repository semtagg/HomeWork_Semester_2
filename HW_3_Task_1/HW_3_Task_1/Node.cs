using System.Collections.Generic;

namespace HW_3_Task_1
{
    public class Node
    {
        private int degree;

        public Node(int degree)
        {
            this.degree = degree;
            Children = new List<Node>(degree);
            Entries = new List<Entry>(degree);
        }

        public List<Node> Children { get; set; }

        public List<Entry> Entries { get; set; }

        public bool IsLeaf => Children.Count == 0;

        public bool HasReachedMaxEntries => Entries.Count == (2 * this.degree) - 1;

        public bool HasReachedMinEntries => Entries.Count == this.degree - 1;
    }
}
