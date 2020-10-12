/**
 * 518. 零钱兑换 II
 * https://leetcode-cn.com/problems/coin-change-2/submissions/
 * */
var change = function(amount, coins) {
	let dp = [1, ...new Array(amount).fill(0)];
	coins.forEach(n => {
		for (let i = n; i <= amount; i++) {
			dp[i] += dp[i - n]
		}
	})
	return dp[amount];
};

/**
 * 543. 二叉树的直径
 * https://leetcode-cn.com/problems/diameter-of-binary-tree/
 * */
var diameterOfBinaryTree = function(root) {
	let fun = node => {
		if (!node) {
			return 0;
		}
		//递归求出两侧深度中较大的深度，再加上本身
		return Math.max(fun(node.left), fun(node.right)) + 1;
	}
	if (!root) {
		return 0;
	}
	//当前节点的左右深度和
	let tempH = fun(root.left) + fun(root.right);
	//当前节点的深度，左节点的直径，有节点的直径，取最大的那个
	return Math.max(tempH, diameterOfBinaryTree(root.left), diameterOfBinaryTree(root.right));
};
