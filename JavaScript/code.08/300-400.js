/**
 * 300. 最长上升子序列
 * https://leetcode-cn.com/problems/longest-increasing-subsequence/submissions/
 * @param {number[]} nums
 * @return {number}
 */
var lengthOfLIS = function(nums) {
	let dp = new Array(nums.length).fill(1),
		max = 0;
	for (let i = 0; i < nums.length; i++) {
		for (let j = 0; j < i; j++) {
			nums[i] > nums[j] ? dp[i] = Math.max(dp[i], dp[j] + 1) : '';
		}
		max = Math.max(max, dp[i]);
	}
	return max;
};
/**
 * 322. 零钱兑换
 * https://leetcode-cn.com/problems/coin-change/submissions/
 * */
var coinChange = function(coins, amount) {
	let dp = [0, ...new Array(amount).fill(amount + 1)]
	coins.forEach(n => {
		for (let i = n; i <= amount; i++) {
			dp[i] = Math.min(dp[i], dp[i - n] + 1)
		}
	})
	return dp[amount] === amount + 1 ? -1 : dp[amount]
}
/**
 * 395. 至少有K个重复字符的最长子串
 * https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/
 * @param {string} s
 * @param {number} k
 * @return {number}
 */
var longestSubstring = function(s, k) {
	if (k == 1) {
		return Boolean(s) ? s.length : 0;
	} else if (k == 0) {
		return 0;
	}
	let maxlen = 0;
	for (let i = 0; i < s.length; i++) {
		for (let j = i + k; j <= s.length; j++) {
			let item = s.substring(i, j);
			if (maxlen >= item.length) {
				continue;
			}

			let bb = {};
			let isBreak = false;
			for (let t = 0; t < item.length; t++) {
				bb[item[t]] = (bb[item[t]] || 0) + 1;
				isBreak = bb[item[t]] < k && bb[item[t]] + item.length - t < k;
				if (isBreak) {
					break;
				}
			}
			if (isBreak) {
				continue;
			}
			for (const key in bb) {
				isBreak = bb[key] < k;
				if (isBreak) {
					break;
				}
			}
			if (!isBreak) {
				maxlen = item.length;
			}
		}
	}

	return maxlen;
};
