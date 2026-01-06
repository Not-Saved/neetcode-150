namespace leetcode;

public static class Lc4
{
    public static void Run()
    {
        int[] nums1 = [1, 3, 6];
        int[] nums2 = [0, 0];
        Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
    }

    private static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            (nums1, nums2) = (nums2, nums1);
        }

        int l = 0, r = nums1.Length;
        while (true)
        {
            var pX = (l + r) / 2;
            var pY = (nums1.Length + nums2.Length + 1) / 2 - pX;

            var pXmax = (pX == 0) ? int.MinValue : nums1[pX - 1];
            var pYmax = (pY == 0) ? int.MinValue : nums2[pY - 1];
            var pXmin = (pX == nums1.Length) ? int.MaxValue : nums1[pX];
            var pYmin = (pY == nums2.Length) ? int.MaxValue : nums2[pY];
   
            if (pXmax <= pYmin && pYmax <= pXmin)
            {
                return (nums1.Length + nums2.Length) % 2 == 1
                    ? Math.Max(pXmax, pYmax)
                    : (Math.Max(pXmax, pYmax) + Math.Min(pXmin, pYmin)) / 2.0;
            }
            else if (pXmax > pYmin)
            {
                r = pX - 1;
            }
            else
            {
                l = pX + 1;
            }
        }

        throw new ArgumentException("Input arrays are not sorted.");
    }
}