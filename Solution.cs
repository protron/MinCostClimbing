public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        return Calc(cost, 0);
    }

    public int Calc(int[] cost, int firstIndex) {
        var missing = cost.Length - firstIndex;
        if (missing < 2) {
            return 0;
        }
        if (missing == 2) {
            return Math.Min(cost[firstIndex], cost[firstIndex + 1]);
        }
        var costSingleStep = cost[firstIndex] + Calc(cost, firstIndex + 1);
        var costDoubleStep = cost[firstIndex + 1] + Calc(cost, firstIndex + 2);
        return Math.Min(costSingleStep, costDoubleStep);
    }
}