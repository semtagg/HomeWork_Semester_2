namespace HW_2_Task_2
{
    public class Node
    {        
        public Node(double item, Node nextNode)
        {
            this.item = item;
            this.nextNode = nextNode;
        }

        public Node()
        { 
        }

        public double item;
        public Node nextNode;
    }
}
