using System.Diagnostics;
using System.Text.Json;

var solution = new Solution();
var summary = (successes: 0, failures: 0);
var testCases = File.ReadAllLines("TestCases.jsonl");
var expectedResults = File.ReadAllLines("ExpectedResults.txt");
var items = Enumerable.Range(1, testCases.Length).Zip(testCases, expectedResults);
foreach (var item in items) {
    var lineNumber = item.First;
    var testCase = item.Second;
    int expected = int.Parse(item.Third);
    int[]? input = JsonSerializer.Deserialize<int[]>(testCase);
    Debug.Assert(input is not null);
    int actual = solution.MinCostClimbingStairs(input);
    if (expected != actual) {
        Write(ConsoleColor.Red, $"ERROR at line {lineNumber}: expected {expected} but actually got {actual}. TestCase: {testCase}");
        summary.failures += 1;
    } else {
        Write(ConsoleColor.Green, $"Line {lineNumber}: TestCase: {testCase} returned expected {expected}.");
        summary.successes += 1;
    }
}
Write(ConsoleColor.Gray, $"--- Summary ---");
Write(ConsoleColor.Green, $"Successes: {summary.successes}");
if (summary.failures > 0) {
    Write(ConsoleColor.Red, $"Failures: {summary.failures}");
} else {
    Write(ConsoleColor.Gray, $"Failures: {summary.failures}");
}

void Write(ConsoleColor color, string s) {
    Console.ForegroundColor = color;
    Console.WriteLine(s);
}