namespace HW_4_Task_1
{
    /// <summary>
    /// Interface of the parse tree node.
    /// </summary>
    interface INode
    {
        /// <summary>
        /// Calculates the value.
        /// </summary>
        /// <returns>Result.</returns>
        public double Calculate();

        /// <summary>
        /// Prints the value.
        /// </summary>
        public void Print();
    }
}
