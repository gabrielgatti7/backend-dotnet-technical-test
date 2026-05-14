namespace TechnicalTest.Question2;

public static class Fibonacci
{
    public static IEnumerable<int> GenerateSequence(int x)
    {
        int current = 0;
        int next = 1;
        for (int i = 0; i < x; i++)
        {
            yield return current;

            int a = current + next;
            current = next;
            next = a;
        }
    }
}
