public class Solution
{
    private int[] input;
    private int?[] cache;

    public int MinCostClimbingStairs(int[] cost)
    {
        this.input = cost;
        this.cache = new int?[cost.Length];
        return Calc(0);
    }

    public int Calc(int firstIndex)
    {
        if (cache[firstIndex].HasValue)
        {
            return cache[firstIndex].Value;
        }
        var missing = input.Length - firstIndex;
        if (missing < 2)
        {
            return 0;
        }
        if (missing == 2)
        {
            return Math.Min(input[firstIndex], input[firstIndex + 1]);
        }
        var costSingleStep = input[firstIndex] + Calc(firstIndex + 1);
        var costDoubleStep = input[firstIndex + 1] + Calc(firstIndex + 2);
        var result = Math.Min(costSingleStep, costDoubleStep);
        cache[firstIndex] = result;
        return result;
    }
}