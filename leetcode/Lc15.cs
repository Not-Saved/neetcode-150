namespace leetcode;

public class Lc15
{
    public static void Run()
    {
        int[] nums = [-1, 0, 1, 2, -1, -4];

        foreach (var innerList in ThreeSum(nums))
        {
            Console.WriteLine(string.Join(", ", innerList));
        }
    }

    private static IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        
        Array.Sort(nums);
        for (var i = 0; i < nums.Length - 2; i++)
        {
            var num = nums[i];
            if(num > 0) {
                i++;
                continue;
            }
            if (i > 0 && num == nums[i - 1]) continue;
            var l = i + 1;
            var r = nums.Length - 1;
            while (l < r)
            {
             
                if (l > i + 1 && nums[l] == nums[l - 1])
                {
                    l++;
                    continue;
                };
        
                
                var threeSum = nums[l] + nums[r] + num;
                switch (threeSum)
                {
                    case > 0:
                        r--;
                        break;
                    case < 0:
                        l++;
                        break;
                    default:
                        result.Add(new List<int>() { nums[l], nums[r], num });
                        l++;
                        break;
                }
            }
        }

        return result;
    }
}