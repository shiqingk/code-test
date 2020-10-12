function sort() {
	/*
	1，冒泡排序
		小的交换就行了
	2，简单选择排序
		每一趟找到最小的，跟最左侧的替换
	3，快排
		取中间值，小的放到left，大的放到right
		fun(left).concat([mid],fun(right));
	4，二分查找
		while(left<right){
			let mid=((left+right)/2)>>1;
		}
	5，桶排序
		先获取到max,min
		再分成若干个桶
		每个桶里面排序
		再合并
	6，插入排序
		function insertionSort(arr) {
		    var len = arr.length;
		    var preIndex, current;
		    for(vari = 1; i < len; i++) {
		        preIndex = i - 1;
		        current = arr[i];
		        while(preIndex >= 0 && arr[preIndex] > current) {
		            arr[preIndex + 1] = arr[preIndex];
		            preIndex--;
		        }
		        arr[preIndex + 1] = current;
		    }
		    return arr;
		}
	*/
}

function f(s) {
	function IsPopOrder(pushV, popV) {
		let arr = [];
		for (let i = 0; i < pushV.length; i++) {
			arr.push(pushV[i]);
			if (!popV.length) {
				return false;
			}
			if (popV[0] == pushV[i]) {
				arr.pop();
				popV.shift();
			}
		}
		let len = arr.length
		for (let i = 0; i < len; i++) {
			if (popV[0] == arr[arr.length - 1]) {
				arr.pop();
				popV.shift();
			}
		}
		return arr.length == 0
	}
	return IsPopOrder([1, 2, 3, 4, 5], [4, 5, 3, 2, 1]);
}

function LRU(operators, k) {
	debugger
	let dp = [];
	for (let i in operators) {
		let item = operators[i];
		let index = -1;
		for (let j = 0; j < dp.length; j++) {
			if (dp[j] == item) {
				index = j;
				break;
			}
		}
		if (index !== -1) {
			dp = dp.slice(0, index).concat(dp.slice(index + 1), item);
		} else {
			dp.push(item);
		}
		if (dp.length > k) {
			for (let t = 0; dp.length - k >= 0; t++) {
				dp.unshift();
			}
		}
	}
	return dp;
}


/**
 * 
 * 走梅花桩
 * */
function Redraiment(line, s) {
	debugger
	var n = parseInt(line);
	var arr = s.split(' ').map(Number);
	var dp = [],
		res = 0;
	for (let i = 0; i < n; i++) {
		dp[i] = 1;
		for (let j = 0; j < i; j++) {
			if (arr[j] < arr[i]) {
				dp[i] = Math.max(dp[j] + 1, dp[i])
			}
		}
		res = Math.max(res, dp[i])
	}
	console.log(res);
}

/**
 * 53. 最大子序和
 * https://leetcode-cn.com/problems/maximum-subarray/
 * @param {number[]} nums
 * @return {number}
 */
var maxSubArray = function(nums) {
	let ret = nums[0], //快指针
		pre = 0; //慢指针
	for (let i = 0; i < nums.length; i++) {
		pre = Math.max(pre + nums[i], nums[i]);
		ret = Math.max(pre, ret);
	}
	return ret;
};
/**
 * 35. 搜索插入位置
 * https://leetcode-cn.com/problems/search-insert-position/
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var searchInsert_2 = function(nums, target) {
	let left = 0,
		right = nums.length - 1,
		p = nums.length;
	while (left <= right) {
		let mid = (right - left >> 1) + left;
		if (nums[mid] == target) {
			return mid;
		}
		if (nums[mid] < target) {
			left = mid + 1;
		} else {
			right = mid - 1;
			p = mid;
		}
	}
	return p;
};

/**
 * 35. 搜索插入位置
 * https://leetcode-cn.com/problems/search-insert-position/
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var searchInsert = function(nums, target) {
	let index = 0;
	for (; index < nums.length; index++) {
		if (nums[index] >= target) {
			return index;
		}
	}
	return nums.length;
};
/**
 * 27. 移除元素
 * https://leetcode-cn.com/problems/remove-element/
 * @param {number[]} nums
 * @param {number} val
 * @return {number}
 */
var removeElement = function(nums, val) {
	if (nums.length == 0) {
		return 0;
	}
	let index = 0; //慢指针，初始为0
	for (let i = 0; i < nums.length; i++) {
		if (nums[i] != val) { //不相等,就放到慢指针位置去，慢指针+1
			nums[index] = nums[i];
			index++;
		}
		//相等的跳过
	}
	return index;
};

/**
 * @param {number[]} nums
 * @return {number}
 */
var removeDuplicates = function(nums) {
	if (nums.length < 2) {
		return nums.length;
	}
	let index = 0;
	for (let i = 1; i < nums.length; i++) {
		if (nums[i] != nums[index]) {
			nums[index] = nums[i];
			index++;
		}
	}
	return index + 1;
};



/**
 * 14. 最长公共前缀
 * https://leetcode-cn.com/problems/longest-common-prefix/
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function(strs) {
	if (strs.length <= 1) {
		return strs[0] || '';
	}

	let s = '';
	let min = strs[0].length;
	for (let i = 1; i < strs.length; i++) {
		strs[i].length < min ? min = strs[i].length : '';
	}

	for (let i = 1; i <= min; i++) {
		let last = s;
		s = strs[0].substring(0, i);
		for (let j = 1; j < strs.length; j++) {
			let sj = strs[j].substring(0, i);
			if (s && sj !== s) {
				return strs[j].substring(0, i - 1);
			}
		}
	}
	return s;
};
/**
 * 统计到n的质数个数
 * */
function fun333() {
	var countPrimes = function(n) {
		let ret = [];
		debugger
		for (let i = 2; i < n; i++) {
			if (isPrime(i, ret)) {
				ret.push(i);
			}
		}
		return ret;
	};
	var isPrime = (n, ret) => {
		if (n < 4) {
			return true;
		} else if (n % 2 == 0 || n % 3 == 0 || n % 6 !== 1 && n % 6 != 5) {
			return false;
		}
		for (let i = 0; i < ret.length; i++) {
			if (n % ret[i] == 0) {
				return false;
			}
			if (ret[i] > (n / 2)) {
				return true;
			}
		}
		return true;
	}
	return countPrimes(999983);
}
