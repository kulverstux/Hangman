
using System.Data;
using System.Net.Mail;

class Solution
{
    public static int[] FillWithRandomNumbers()
    {
        int[] ts = new int[10000];
        int length = ts.Length;
        Random random = new Random();
        for (int i = 0; i < length; i++)
        { 
            ts[i] = random.Next(-50,50);
        }
        return ts;
    }
    public static int ComputeClosestToZero(int[] ts)
    {
        int length = ts.Length;
        if (length == 0) return 0;

        int closestPositiveToZero = ts[0];
        int closestNegativeToZero = ts[0];

        for (int i = 0; i < length; i++)
        {
            if (ts[i] >= 0)
            {
                if (ts[i] < closestPositiveToZero)
                {
                    closestPositiveToZero = ts[i];
                }
            }
            else
               if (ts[i] > closestNegativeToZero)
                {
                    ts[i] = closestNegativeToZero;
                }
        }
        if (Math.Abs(closestNegativeToZero) < closestPositiveToZero)
        {
            return closestNegativeToZero;
        }
        else
        {
            if (Math.Abs(closestNegativeToZero) == closestPositiveToZero)
                return closestPositiveToZero;
        }
        return closestPositiveToZero;
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"Lowest: {ComputeClosestToZero(FillWithRandomNumbers())}");   
    }
    
}