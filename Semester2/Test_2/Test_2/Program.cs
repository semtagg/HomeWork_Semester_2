
namespace Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new PriorityQueue<string>();
            q.Enqueue("a", 40);
            q.Enqueue("b", 40);
            q.Enqueue("c", 40);
            q.Enqueue("d", 80);
            q.Enqueue("e", 20);
            var result = q.Dequeue();
            result = q.Dequeue();
            result = q.Dequeue();
            result = q.Dequeue();
            result = q.Dequeue();
        }
    }
}
