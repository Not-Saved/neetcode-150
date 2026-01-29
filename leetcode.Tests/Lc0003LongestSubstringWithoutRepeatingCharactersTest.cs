using leetcode.utils;
using Xunit.Abstractions;

namespace leetcode.Tests;

public class Lc0003LongestSubstringWithoutRepeatingCharactersTest(ITestOutputHelper output)
{
    [Fact]
    public void Test1()
    {
        const string s = "abcabcbb";

        var result = Lc0003LongestSubstringWithoutRepeatingCharacters.LongestSubstringWithoutRepeatingCharacters(s);

        output.WriteLine($"{result}");

        Assert.Equal(3, result);
    }
}