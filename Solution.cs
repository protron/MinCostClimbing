public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int s1 = cost[0];
        int s2 = cost[1];
        for (int i = 2; i < cost.Length; i++)
        {
            (s1, s2) = (s2, cost[i] + Math.Min(s1, s2));
        }
        return Math.Min(s1, s2);
    }
}