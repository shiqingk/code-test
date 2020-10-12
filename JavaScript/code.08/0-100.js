/**
 * 2. 两数相加
 * https://leetcode-cn.com/problems/add-two-numbers/submissions/
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var addTwoNumbers = function(l1, l2) {
	let ret = new ListNode(''),
		cur = ret,
		val = 0;
	while (l1 || l2 || val) {
		val += (l1 && l1.val) + (l2 && l2.val);
		cur.next = new ListNode(val % 10);
		l1 = l1 && l1.next;
		l2 = l2 && l2.next;
		val = val > 9;
		cur = cur.next
	}

	return ret.next;
};
/**
 * 3. 无重复字符的最长子串
 * https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function(s) {
	if (s.length < 2) {
		return s.length
	}
	let max = 0,
		tmp = '';
	for (let i = 0; i < s.length; i++) {
		let index = tmp.lastIndexOf(s[i]);
		if (index == -1) {
			tmp += s[i];
		} else {
			tmp = tmp.substr(index + 1) + s[i];
		}
		max = Math.max(max, tmp.length);
	};
	return max;
};
/**
 * 4. 寻找两个正序数组的中位数
 * https://leetcode-cn.com/problems/median-of-two-sorted-arrays/submissions/
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function(nums1, nums2) {
	function fastSort(arr) {
		if (!arr || arr.length == 0) {
			return [];
		}
		let midIndex = arr.length / 2 >> 1;
		let mid = arr[midIndex];
		let left = [],
			right = [];
		for (let i = 0; i < arr.length; i++) {
			if (i !== midIndex) {
				if (arr[i] > mid) {
					right.push(arr[i]);
				} else {
					left.push(arr[i]);
				}
			}
		}
		return fastSort(left).concat([mid], fastSort(right));
	}
	let arr = []
	if (nums1.length > 0 && nums2.length > 0) {
		arr = fastSort(nums1.concat(nums2));
	} else if (nums1.length == 0) {
		arr = nums2;
	} else if (nums2.length == 0) {
		arr = nums1;
	}
	if (arr.length == 1) {
		return arr[0]
	}
	if (arr.length % 2 == 1) {
		return arr[(arr.length - 1) / 2]
	}
	return ((arr[arr.length / 2 - 1] + arr[arr.length / 2]) / 2).toFixed(1);
};
/**
 * 54. 螺旋矩阵，矩阵螺旋打印
 * https://leetcode-cn.com/problems/spiral-matrix/
 * */
var spiralOrder = (arr) => {
	let ret = [],
		t = 0;
	if (!arr || !arr[0]) {
		return [];
	} else if (arr.length == 1) {
		let len = arr[0].length;
		for (let i = 0; i < len; i++) {
			ret.push(arr[0].shift());
		}
		return ret;
	} else if (arr[0].length == 1) {
		let len = arr.length;
		for (let i = 0; i < len; i++) {
			ret.push(arr[i][0]);
		}
		return ret;
	}

	while (arr.length) {
		if (t % 4 == 0) {
			let len = arr[0].length;
			for (let i = 0; i < len; i++) {
				ret.push(arr[0].shift());
			}
			arr.shift();
		} else if (t % 4 == 1) {
			let len = arr.length;
			for (let i = 0; i < len; i++) {
				ret.push(arr[i].pop());
			}
		} else if (t % 4 == 2) {
			let len = arr[arr.length - 1].length;
			for (let i = 0; i < len; i++) {
				ret.push(arr[arr.length - 1].pop());
			}
			arr.pop();
		} else if (t % 4 == 3) {
			let len = arr.length;
			if (len == 1) {
				t++;
				continue;
			}
			for (let i = len - 1; i >= 0; i--) {
				ret.push(arr[i].shift());
			}
		}
		t++;
	}
	return ret.filter(x => Boolean(x) || x == 0);
}
