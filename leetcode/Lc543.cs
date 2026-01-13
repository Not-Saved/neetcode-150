namespace leetcode;

public class Lc543
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static void Run()
    {
        TreeNode root =
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4, null, null),
                    new TreeNode(5, null, null)
                ),
                new TreeNode(3, null, null)
            );
        Console.WriteLine(DiameterOfBinaryTree(root));
    }


    static int maxDiam = 0;

    private static int DiameterOfBinaryTree(TreeNode root)
    {
        DiameterRec2(root);
        return maxDiam;
    }

    private static int DiameterRec(TreeNode node)
    {
        if (node.left == null && node.right == null)
        {
            return 0;
        }

        if (node.right == null || node.left == null)
        {
            var depth = DiameterRec(node.right ?? node.left);
            maxDiam = Math.Max(depth + 1, maxDiam);
            return depth + 1;
        }

        var depthL = DiameterRec(node.left);
        var depthR = DiameterRec(node.right);
        maxDiam = Math.Max(depthL + depthR + 2, maxDiam);
        return 1 + Math.Max(depthL, depthR);
    }

    private static int DiameterRec2(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var l = DiameterRec2(node.left);
        var r = DiameterRec2(node.right);
        maxDiam = Math.Max(maxDiam, l + r);
        return 1 + Math.Max(l, r);
    }
}