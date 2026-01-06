namespace leetcode;

public static class Lc1448
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static void Run()
    {
        var root = new TreeNode(3, new TreeNode(1, new TreeNode(3)), new TreeNode(4, new TreeNode(1), new TreeNode(5)));
        Console.WriteLine(GoodNodes(root));
    }

    private static int GoodNodes(TreeNode root)
    {
        return Visit(root, root.val);
    }

    private static int Visit(TreeNode? node, int parentMax)
    {
        if (node == null) return 0;
        var count = node.val >= parentMax ? 1 : 0;
        node.val = Math.Max(node.val, parentMax);
        return count + Visit(node.left, node.val) + Visit(node.right, node.val);
    }
}