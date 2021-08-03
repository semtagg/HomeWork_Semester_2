using System.Collections.Generic;

namespace HW_3_Task_1
{
    /// <summary>
    /// A class wich contains node representation of BTree.
    /// </summary>
    public class Node
    {
        private int degree;

        public Node(int degree)
        {
            this.degree = degree;
            Children = new List<Node>(degree);
            Entries = new List<Entry>(degree);
        }

        /// <summary>
        /// Stores information about the descendants of the current node.
        /// </summary>
        public List<Node> Children { get; set; }

        /// <summary>
        /// Stores data of the descendants of the current node.
        /// </summary>
        public List<Entry> Entries { get; set; }

        /// <summary>
        /// Stores information about whether a node is a leaf.
        /// </summary>
        public bool IsLeaf => Children.Count == 0;

        public bool HasReachedMaxEntries => Entries.Count == (2 * this.degree) - 1;

        public bool HasReachedMinEntries => Entries.Count == this.degree - 1;
    }
}
