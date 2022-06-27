namespace _617 // 617. 合并二叉树
{// 二叉树
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
    public class Solution
    {

        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return null;
            }
            else if (root1 != null && root2 == null)
            {
                return root1;
            }
            else if (root2 != null && root1 == null)
            {
                return root2;
            }
            else
            {
                root1.val += root2.val;
                root1.left = MergeTrees(root1.left, root2.left);
                root1.right = MergeTrees(root1.right, root2.right);
            }

            return root1;
        }
    }
}