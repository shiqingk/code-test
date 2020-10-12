

/**
 * 选择排序
 * 从一组未排序的数找到最小的，放到最左侧
 * @param {*} arr 
 */
var easySelect = function(arr) {
	for (let i = 0; i < arr.length; i++) {
		let min = arr[i],
			minIndex = i;
		for (let j = i; j < arr.length; j++) {
			if (arr[j] < min) {
				min = arr[j];
				minIndex = j;
			}
		}
		if (min < arr[i]) {
			arr[minIndex] = arr[i];
			arr[i] = min;
		}
	}
	return arr;
}

var maopao = function(arr) {
	for (let index = 0; index < arr.length; index++) {
		let hasChange = false;
		for (let j = index; j < arr.length; j++) {
			if (arr[index] > arr[j]) {
				[arr[index], arr[j]] = [arr[j], arr[index]];
				hasChange = true;
			}
		}
		if (!hasChange) {
			break;
		}
	}
	return arr;
}
/**
 * 输入n个数，找出其中最小的k个数，例如输入4,5,1,6,2,7,3,8,个数字，则最小的数字是1,2,3,4
 */
var fastFilter = function(arr, k) {
	if (arr.length <= 1) {
		return arr;
	}

	let left = [],
		right = [],
		harf = arr.splice(Math.floor(arr.length / 2), 1)[0];
	for (let index = 0; index < arr.length; index++) {
		const element = arr[index];
		if (harf > element) {
			left.push(element);
		} else {
			right.push(element);
		}
	}

	if (k) {
		return fastFilter(left).concat([harf], fastFilter(right)).splice(0, k);
	}
	return fastFilter(left).concat([harf], fastFilter(right));
}
/**
 * 二分查找
 * 给出一个有序数组，返回指定数的下标
 * [1,3,4,8,9,9],4
 * @param {*} arr 
 */
var harfQuery = function(arr, k) {
	var harf = arr.length / 2;
	var left = 0;
	var right = arr.length - 1;
	while (left < right) {
		if (arr[harf] == k) {
			return harf;
		} else if (arr[harf] > k) {
			right = harf;
		} else {
			left = harf;
		}
		harf = Math.floor((right + left) / 2);
	}
	return 0;
};


/**
 * 快速排序
 * 数据以harf一分为二,小于harf的放入left，反之放入eight
 * 递归排left、right
 *  将left、harf、right合并成一个数组
 * 
 * 输入n个数，找出其中最小的k个数，例如输入4,5,1,6,2,7,3,8,个数字，则最小的数字是1,2,3,4
 */
var quickSort = function(arr) {
	if (arr.length <= 1) {
		return arr;
	}
	let left = [],
		right = [],
		harf = arr.splice(arr.length / 2, 1)[0];
	for (let index = 0; index < arr.length; index++) {
		const element = arr[index];
		if (element > harf) { //大的放右边
			right.push(element);
		} else {
			left.push(element);
		}
	}
	return quickSort(left).concat([harf], quickSort(right));
};

/**
 * 1037. 有效的回旋镖
 *  三点横坐标相同
 *  三点纵坐标相同
 *  三点位于同一斜线上
 * @param {number[][]} points
 * @return {boolean}
 */
var isBoomerang = function(points) {
	if (points[0][0] == points[1][0] && points[0][0] == points[2][0]) {
		return false;
	}
	if (points[0][1] == points[1][1] && points[0][1] == points[2][1]) {
		return false;
	}
	if (points[0][0] == points[0][1] && points[1][0] == points[1][1] && points[2][0] == points[2][1]) {
		return false;
	}

	return true;
};

/**
 * 647. 回文子串
 * https://leetcode-cn.com/problems/palindromic-substrings/
 * @param {string} s
 * @return {number}
 */
var countSubstrings = function(s) {
	let count = 0;
	let arr = new Array();
	for (let j = 0; j < s.length; j++) {
		arr[j] = new Array();
		for (let i = 0; i <= j; i++) {
			if (s[i] === s[j] && (j - i < 2 || arr[i + 1][j - 1])) {
				arr[i][j] = true;
				count++;
			}
		}
	}

	return count;
};

/**
 * 剑指 Offer 39. 数组中出现次数超过一半的数字
 * https://leetcode-cn.com/problems/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-ban-de-shu-zi-lcof/submissions/
 */
var majorityElement = function(nums) {
	let obj = {};
	for (let index = 0; index < nums.length; index++) {
		const item = nums[index];
		obj[item] ? obj[item]++ : obj[item] = 1;
		if (obj[item] > nums.length / 2) {
			return obj[item];
		}
	}
	return 0;
};



var arr = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55];
/**
 * 已知一个数组，传入n返回第n个数，用递归实现
 * @param {*} n 
 */
function GetIndexNum(n) {
	if (arr.length != n) {
		arr.pop();
		GetIndexNum(n);
	}

	return arr[n - 1];
}
