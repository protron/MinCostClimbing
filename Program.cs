using System.Diagnostics;
using System.Text.Json;

var solution = new Solution();
var testCases = File.ReadAllLines("TestCases.jsonl");
var expectedResults = File.ReadAllLines("ExpectedResults.txt");
var items = Enumerable.Range(0, testCases.Length).Zip(testCases, expectedResults);
foreach (var item in items) {
    var index = item.First;
    var testCase = item.Second;
    int expected = int.Parse(item.Third);
    int[]? input = JsonSerializer.Deserialize<int[]>(testCase);
    Debug.Assert(input is not null);
    int actual = solution.MinCostClimbingStairs(input);
    if (expected != actual) {
        Console.WriteLine($"ERROR at line {index}: expected {expected} but actually got {actual}. TestCase: {testCase}");
    } else {
        Console.WriteLine($"Line {index}: TestCase: {testCase} returned expected {expected}.");
    }
}