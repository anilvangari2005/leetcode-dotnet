// https://leetcode.com/problems/count-good-nodes-in-binary-tree/


/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public partial class Solution
{
    public int GoodNodes(TreeNode root)
    {
        if (root == null)
            return 0;
        return 1 + GetCount(root, root.val);
    }

    public int GetCount(TreeNode node, int maxVal)
    {
        int count = 0;
        if (node.left != null && node.left.val >= maxVal)
            count++;
        if (node.right != null && node.right.val >= maxVal)
            count++;

        int leftCount = 0;
        if (node.left != null)
            leftCount = GetCount(node.left, node.left.val > maxVal ? node.left.val : maxVal);

        int rightCount = 0;
        if (node.right != null)
            rightCount = GetCount(node.right, node.right.val > maxVal ? node.right.val : maxVal);

        return count + leftCount + rightCount;
    }
}