/**
 * 120. 三角形最小路径和
 * https://leetcode-cn.com/problems/triangle/submissions/
 * @param {number[][]} triangle
 * @return {number}
 */
var minimumTotal = function(triangle) {
	let safeMin = function(x, y) {
		return typeof x == 'number' && typeof y == 'number' ? Math.min(x, y) : typeof x == 'number' ? x : y;
	}
	for (let i = 1; i < triangle.length; i++) {
		let row = triangle[i],
			pre = triangle[i - 1];
		for (let j = 0; j < row.length; j++) {
			row[j] += safeMin(pre[j - 1], pre[j]);
		}
	}
	return Math.min(...triangle[triangle.length - 1]);
};
