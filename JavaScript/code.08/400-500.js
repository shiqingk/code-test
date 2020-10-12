/**
 * 416. 分割等和子集
 * https://leetcode-cn.com/problems/partition-equal-subset-sum/submissions/
 * @param {number[]} nums
 * @return {boolean}
 */
var canPartition = function(nums) {
	let sum = nums.reduce((a, b) => a + b) / 2;
	if (sum % 1 !== 0) {
		return false;
	}
	let dp = [true, ...Array(sum).fill(false)];
	for (let n of nums) {
		for (let i = sum; i >= n; i--) {
			if (dp[sum]) {
				return true;
			}
			dp[i] = dp[i] || dp[i - n];
		}
	}
	return dp[sum];
};
