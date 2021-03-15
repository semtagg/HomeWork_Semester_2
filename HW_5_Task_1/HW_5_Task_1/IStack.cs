namespace HW_2_Task_2
{
    public interface IStack
    {
        bool IsEmpty();

        double Pop();

        void Push(double element);
    }
}