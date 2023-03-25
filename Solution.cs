public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var subClass = new SubClass(cost);
        return subClass.Calc(0);
    }

    private class SubClass
    {
        public int[] input;
        public int?[] cache;

        public SubClass(int[] input)
        {
            this.input = input;
            this.cache = new int?[input.Length];
        }

        public int Calc(int firstIndex)
        {
            if (cache[firstIndex] is int cacheItem)
            {
                return cacheItem;
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
}