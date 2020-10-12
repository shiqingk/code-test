/**
 * 删数
 * 返回最后一个删除的数的下标
 * */
function test() {
	function ListNode(val) {
		this.val = val;
		this.next = null
	}

	function cal(num) {
		num = Math.min(num, 999);
		let node = new ListNode(0);
		let cur = node;
		for (let i = 1; i < num; i++) {
			cur.next = new ListNode(i);
			cur = cur.next;
		}
		cur.next = node;
		let n = new ListNode(0);
		n.next = node;
		node = n;
		while (node.next != null) {
			if (node.next == node) break;
			node = node.next;
			node = node.next;
			node.next = node.next.next;
		}
		console.log(node.val);
	}

	let s = '';
	while (s = readline()) {
		cal(parseInt(s));
	}
}

/**
 * 比较扑克牌大小
 * https://www.nowcoder.com/practice/d290db02bacc4c40965ac31d16b1c3eb?tpId=37&&tqId=21311&rp=1&ru=/ta/huawei&qru=/ta/huawei/question-ranking
 * */
function test() {
	function digit(i) {
		let d = parseInt(i);
		switch (i) {
			case 'J':
				d = 11;
				break;
			case 'Q':
				d = 12;
				break;
			case 'K':
				d = 13;
				break;
			case 'A':
				d = 14;
				break;
			case '2':
				d = 15;
				break;
		}
		return d;
	}

	function check(a, b) {
		let one = a.split(' ');
		let two = b.split(' ');

		if (one.length !== two.length) {
			if (one.length === 2 && (one[0] === 'joker' || one[1] === 'joker')) {
				return a;
			} else if (two.length === 2 && (two[0] === 'joker' || two[1] === 'joker')) {
				return b;
			} else if (one.length === 4 && (one[0] === one[2])) {
				return a;
			} else if (two.length === 4 && (two[0] === two[2])) {
				return b;
			} else {
				return 'ERROR';
			}
		} else { // Same length
			return digit(one[0]) > digit(two[0]) ? a : b;
		}
	}
	while (poker = readline()) {
		let two = poker.split('-');
		console.log(check(two[0], two[1]))
	}
}

/**
 * 
 * 矩阵相乘的计算次数
 * */
function test() {
	while (n = parseInt(readline())) {
		var arr = [];
		var count = 0;
		for (let i = 0; i < n; i++) {
			arr[i] = readline().split(' ').map(item => +item);
		}
		var rule = readline();
		var sta = [];
		for (let i = 0; i < rule.length; i++) {
			if (rule[i] == '(') {} else if (rule[i] == ')') {
				if (sta.length >= 2) {
					let a = sta.pop();
					let b = sta.pop();
					count += a[1] * b[0] * b[1];
					sta.push([b[0], a[1]]);
				}
			} else {
				sta.push(arr[rule.charCodeAt(i) - 65]);
			}
		}
		console.log(count)
	}
}

/**
 * 矩阵相乘
 * https://www.nowcoder.com/practice/ebe941260f8c4210aa8c17e99cbc663b?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function test() {
	function getResult(x, y, z, array1, array2) {
		let ret = []
		for (let i = 0; i < x; i++) { // xz array
			ret.push(new Array(z))
		}
		for (let i = 0; i < x; i++) { //x
			for (let j = 0; j < z; j++) { //z
				let sum = 0;
				for (let k = 0; k < y; k++) { //y
					sum += array1[i][k] * array2[k][j];
				}
				ret[i][j] = sum;
			}
		}
		return ret
	}
	while (line = readline()) {
		let x = +line.trim()
		let y = +readline().trim()
		let z = +readline().trim()
		let array1 = [],
			array2 = [];
		while (x--) {
			array1.push(readline().trim().split(' ').map(Number))
		}
		while (y--) {
			array2.push(readline().trim().split(' ').map(Number))
		}
		let res = getResult(array1.length, array1[0].length, array2[0].length, array1, array2) // x,y,z,xy array,yz array
		for (let i = 0; i < res.length; i++) {
			console.log(res[i].join(' '))
		}
	}
}
/**
 * 24点游戏算法
 * https://www.nowcoder.com/practice/fbc417f314f745b1978fc751a54ac8cb?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function test() {
	while (line = readline()) {
		let arr = line.trim(' ').split(' ').map(x => parseInt(x));
		let dp = [false, false, false, false];

		function cal(total, count) {
			if (count == 4) {
				return total == 24;
			}
			for (let i = 0; i < 4; i++) {
				if (dp[i]) {
					continue;
				}
				dp[i] = true;
				if (cal(total + arr[i], count + 1) ||
					cal(total - arr[i], count + 1) ||
					cal(total * arr[i], count + 1) ||
					(total % arr[i] == 0 && cal(total / arr[i], count + 1))
				) {
					return true;
				}
				dp[i] = false;
			}
		}
		let isFalse = true;
		for (let i = 0; i < 4; i++) {
			dp[i] = true;
			if (cal(arr[i], 1)) {
				isFalse = false;
				break;
			}
			dp[i] = false;
		}
		console.log(!isFalse);
	}
}


/**
 * 配置文件恢复
 * https://www.nowcoder.com/practice/ca6ac6ef9538419abf6f883f7d6f6ee5?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function test() {
	let orders = {
		reset: 'reset what',
		'reset board': 'board fault',
		'board add': 'where to add',
		'board delete': 'no board at all',
		'reboot backplane': 'impossible',
		'backplane abort': 'install first'
	}
	let error = 'unknown command';

	function cal(str) {
		if (str.split(' ').length == 1) {
			if (!'reset'.startsWith(str) || str.length > 5) {
				console.log(error);
			} else {
				console.log(orders.reset);
			}
		} else {
			let x = str.split(' ')[0];
			let xkeyMatch = [];
			for (let key in orders) {
				if (key.startsWith(x)) {
					xkeyMatch.push({
						[key]: orders[key]
					});
				}
			}

			if (xkeyMatch.length == 0) {
				console.log(error);
			} else {
				let ykeyMatch = [];
				let y = str.split(' ')[1];
				for (let t in xkeyMatch) {
					let item = xkeyMatch[t];
					let val = Object.keys(item)[0].split(' ')[1];
					if (val && val.startsWith(y)) {
						ykeyMatch.push(item[Object.keys(item)[0]]);
					}
				}
				if (ykeyMatch.length != 1) {
					console.log(error);
				} else {
					console.log(ykeyMatch[0]);
				}
			}
		}
	}

	let str = '';
	while (str = readline()) {
		cal(str)
	}
}

/**
 * 最大公共子串
 * https://www.nowcoder.com/practice/181a1a71c7574266ad07f9739f791506?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function test() {
	function common(s1, s2) {
		let maxStr = '',
			tmpStr = '';
		for (let i = 0; i < s2.length; i++) {
			tmpStr += s2[i];
			if (s1.indexOf(tmpStr) == -1) {
				tmpStr = tmpStr.substr(1);
			} else if (tmpStr.length > maxStr.length) {
				maxStr = tmpStr;
			}
		}
		return maxStr;
	}

	while (str1 = readline()) {
		let str2 = readline();
		if (str1.length < str2.length) {
			[str1, str2] = [str2, str1]
		}
		console.log(common(str1, str2));
	}
}
/**
 * 放苹果
 * https://www.nowcoder.com/practice/bfd8234bb5e84be0b493656e390bdebf?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function 苹果() {
	function GetNum(m, n) {
		if (m < 0 || n <= 0) {
			return 0;
		} else if (m == 1 || n == 1) {
			return 1;
		} else {
			return GetNum(m - n, n) + GetNum(m, n - 1);
		}
	}


	while (str = readline()) {
		let s = str.split(' ')
		let m = s[0];
		let n = s[1];
		if (m < 0 || m > 10 || n < 1 || n > 10) {
			console.log(-1);
			break;
		}

		console.log(GetNum(m, n));
	}
	//f(m,n)=f(m-n,n)+f(m,n-1)
}

function test() {
	while (n = readline()) {
		let num1 = n.trim();
		let num2 = readline().trim();
		let len = num1.length > num2.length ? num1.length : num2.length;
		let arr = [];
		let sum = 0;
		let s = 0;
		let g = 0;
		let narr1 = num1.split('').reverse();
		let narr2 = num2.split('').reverse();
		for (let i = 0; i < len; i++) {
			let n1 = isNaN(parseInt(narr1[i])) ? 0 : parseInt(narr1[i]);
			let n2 = isNaN(parseInt(narr2[i])) ? 0 : parseInt(narr2[i]);
			sum = n1 + n2 + s;
			if (sum >= 10) {
				s = sum.toString().substr(0, 1) * 1;
				g = sum.toString().substr(1, 2) * 1;
			} else {
				s = 0;
				g = sum;
			}
			arr.push(g)

		}
		if (s > 0) {
			arr.push(s)
		}
		console.log(arr.reverse().join(''))
	}
}
/**
 * 输出单向链表中倒数第k个结点
 * https://www.nowcoder.com/practice/54404a78aec1435a81150f15f899417d?tpId=37&&tqId=21274&rp=1&ru=/ta/huawei&qru=/ta/huawei/question-ranking
 * */
function test() {
	while (len = readline()) {
		let arr = readline().split(' ')
		let k = parseInt(readline())
		if (len - k >= 0 && k > 0) {
			console.log(arr[len - k])
		} else {

			console.log(0)
		}
	}
}
/**
 * 复杂链表的复制
 * https://www.nowcoder.com/practice/f836b2c43afc4b35ad6adc41ec941dba?tpId=13&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function Clone(pHead) {
	if (pHead === null) return null;
	let pre = pHead;
	let current = pHead.next;
	while (current !== null) {
		let newNode = new RandomListNode(pre.label);
		pre.next = newNode;
		newNode.next = current;
		pre = current;
		current = current.next;
	}
	//复制最后一个节点
	let newNode = new RandomListNode(pre.label);
	pre.next = newNode;
	let pre2 = pHead;
	let current2 = pHead.next;
	let head = current2;
	while (pre2 !== null) {
		if (pre2.random !== null) {
			current2.random = pre2.random.next;
		}
		pre2 = current2.next;
		if (pre2 !== null) {
			current2.next = pre2.next;
		}
		current2 = current2.next;
	}

	return head;
}
/**
 * 二叉树中和为某一值的路径
 * https://www.nowcoder.com/practice/b736e784e3e34731af99065031301bca?tpId=13&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function erchashu() {
	var res, path;

	function FindPath(root, expectNumber) {
		// write code here
		res = [];
		path = [];
		if (root == null) {
			return []
		};
		cal(root, expectNumber);
		return path;

	}

	function cal(node, exn) {
		res.push(node.val);
		if (node.val == exn && node.left == null && node.right == null) {
			path.push(res.slice());
		} else {
			if (node.left != null) cal(node.left, exn - node.val);
			if (node.right != null) cal(node.right, exn - node.val);
		}
		res.pop()
	}
}
/**
 * 栈的压入、弹出序列
 * https://www.nowcoder.com/practice/d77d11405cc7470d82554cb392585106?tpId=13&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
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
/**
 * 判断b是不是a的子树
 * */
function HasSubtree(pRoot1, pRoot2) {
	let fun = function(node, node2) {
		if (!node2) return true
		if (!node) return false
		return node.val == node2.val && fun(node.left, node2.left) && fun(node.right, node2.right)
	}
	if (!pRoot1 || !pRoot2) {
		return false
	}
	return fun(pRoot1, pRoot2) || HasSubtree(pRoot1.left, pRoot2) || HasSubtree(pRoot1.right, pRoot2)
}

function TreeNode(x) {
	this.val = x;
	this.left = null;
	this.right = null;
}
/**
 * 	重建二叉树
 * https://www.nowcoder.com/practice/8a19cbe657394eeaac2f6ea9b0f6fcf6?tpId=13&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function reConstructBinaryTree(pre, vin) {
	//利用递归实现 其中preStart代表的是先序遍历的第一个节点的下标位置 后边的依次类推
	function rebuild(preStart, preEnd, vinStart, vinEnd) {
		let node = new TreeNode(pre[preStart])
		//判断是否只有一个节点 如果只有一个节点 则返回节点本身
		if ((preStart == preEnd) && (vinStart == vinEnd)) {
			return node
		}
		let index = vin.indexOf(pre[preStart]) //查找树的根节点
		let leftLen = index - vinStart //左子树的长度
		let leftPrend = preStart + leftLen //先选出先序遍历的左子树的所有节点
		if (leftLen > 0) {
			//此时相当于遍历左子树的左子树  因此先序遍历开始的节点需加一 中序遍历结束的节点需减一
			node.left = rebuild(preStart + 1, leftPrend, vinStart, index - 1)
		}
		if (leftLen < preEnd - preStart) {
			node.right = rebuild(leftPrend + 1, preEnd, index + 1, vinEnd)
		}
		return node
	}
	let head = rebuild(0, pre.length - 1, 0, vin.length - 1)
	return head
}
/**
 * 重建二叉树
 * */
function reConstructBinaryTree(pre, vin) {
	let p = 0;
	let i = 0;
	let build = function(stop) {
		if (vin[i] != stop) {
			let root = new TreeNode(pre[p++])
			root.left = build(root.val)
			i++;
			root.right = build(stop)
			return root
		}
		return null
	}
	return build()
}
/**
 * 迷宫问题
 * https://www.nowcoder.com/practice/cf24906056f4488c9ddb132f317e03bc?tpId=37&&tqId=21266&rp=1&ru=/ta/huawei&qru=/ta/huawei/question-ranking
 * */
function cal() {
	var line;
	while (line = readline()) {
		line = line.split(' ');
		var N = +line[0];
		var M = +line[1];
		var maze = [];
		for (let i = 0; i < N; i++) {
			maze[i] = readline().split(' ');
		}
		var path_temp = [];
		var path_best = [];

		function MazeTrack(i, j) {
			maze[i][j] = 1; //表示当前节点已走，不可再走
			path_temp.push(`(${i},${j})`); //将当前节点加入到路径中
			if (i == N - 1 && j == M - 1) {
				//判断是否到达终点
				if (path_best.length == 0 || path_temp.length < path_best.length) {
					// 数组赋值不能直接给地址，不然两个变量都会关联到同一个数组
					path_best = path_temp.map(item => item);
				}
			}
			if (i - 1 >= 0 && maze[i - 1][j] == 0) //探索向上走是否可行
				MazeTrack(i - 1, j);
			if (i + 1 < N && maze[i + 1][j] == 0) //探索向下走是否可行
				MazeTrack(i + 1, j);
			if (j - 1 >= 0 && maze[i][j - 1] == 0) //探索向左走是否可行
				MazeTrack(i, j - 1);
			if (j + 1 < M && maze[i][j + 1] == 0) //探索向右走是否可行
				MazeTrack(i, j + 1);
			maze[i][j] = 0; //恢复现场，设为未走
			path_temp.pop();
		}
		MazeTrack(0, 0);
		path_best.forEach(item => console.log(item));
	}
}
/**
 * 实现一个可以存储若干个单词的词典
 * https://www.nowcoder.com/practice/03ba8aeeef73400ca7a37a5f3370fe68?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function cal() {
	let str;
	while (str = readline()) {
		let arr = str.trim().split(' ').slice(1);
		// 需要查找第几个兄弟单词
		let index = Number(arr[arr.length - 1]);
		// 需要查找的单词
		let newset = arr[arr.length - 2];
		let arr3 = [];
		for (let i = 0; i < arr.length - 2; i++) {
			if (arr[i] !== newset && arr[i].length === newset.length) {
				let arr1 = arr[i].split('').sort().join('');
				let arr2 = newset.split('').sort().join('');
				if (arr1 === arr2) {
					arr3.push(arr[i]);
				}
			}
		}
		arr3.sort();
		console.log(arr3.length);
		if (arr3.length > 0 && index <= arr3.length) {
			console.log(arr3[index - 1]);
		}
	}
}
/**
 * 字符串排序
 * 英文字母从 A 到 Z 排列，不区分大小写。
 * 同一个英文字母的大小写同时存在时，按照输入顺序排列。
 * 非英文字母的其它字符保持原来的位置。
 * https://www.nowcoder.com/practice/5190a1db6f4f4ddb92fd9c365c944584?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function cal(str) {
	let az = new Array(57).fill('');
	let other = [];
	for (let i = 0; i < str.length; i++) {
		let n = (str[i]).charCodeAt();
		if (n >= 97 && n <= 122) {
			az[n - 97] += str[i];
		} else if (n >= 65 && n <= 90) {
			az[n - 65] += str[i];
		} else {
			other.push([i, str[i]]);
		}
	}
	let ret = '';
	az.forEach(x => {
		x ? ret += x : '';
	})

	other.forEach(x => {
		ret = ret.slice(0, x[0]) + x[1] + ret.slice(x[0]);
	})
	console.log(ret);
}
/**
 * 输入一个正整数，按照从小到大的顺序输出它的所有质因子
 * https://www.nowcoder.com/practice/196534628ca6490ebce2e336b47b3607?tpId=37&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function zhiyinzi() {
	while (num = readline()) {
		let arr = [];
		for (let i = 2; i < Math.sqrt(num); i++) {
			while (num % i == 0) {
				arr.push(i);
				num = num / i;
			}
		}
		if (num > 1) {
			arr.push(num);
		}
		console.log(arr.join(' ') + ' ');
	}
}
/**
 * 删除链表的倒数第n个节点并返回链表的头指针
 * https://www.nowcoder.com/practice/f95dcdafbde44b22a6d741baf71653f6?tpId=117&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function removeNthFromEnd(head, n) {
	var fast = head,
		slow = head;
	for (let i = 0; i < n; i++) {
		fast = fast.next;
	}
	if (!fast) {
		return head.next;
	}
	while (fast.next) {
		fast = fast.next;
		slow = slow.next;
	}
	slow.next = slow.next.next;
	return head;
}
/**
 * 找出数组中第K大的数
 * https://www.nowcoder.com/practice/e016ad9b7f0b45048c58a9f27ba618bf?tpId=117&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function findKth(a, n, K) {
	let fun = function(arr) {
		if (arr.length == 0) {
			return [];
		}
		let item = arr[0],
			left = [],
			right = [];
		for (let i = 1; i < arr.length; i++) {
			if (arr[i] < item) {
				right.push(arr[i]);
			} else {
				left.push(arr[i]);
			}
		}

		return fun(left).concat([item], fun(right));
	}

	return fun(a)[K - 1];
}
/**
 * 将两个有序的链表合并为一个新链表
 * https://www.nowcoder.com/practice/a479a3f0c4554867b35356e0d57cf03d?tpId=117&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * */
function mergeTwoLists(l1, l2) {
	let head = new ListNode(0);
	let cur = head;
	while (l1 && l2) {
		if (l1.val > l2.val) {
			cur.next = l2;
			l2 = l2.next;
		} else {
			cur.next = l1;
			l1 = l1.next;
		}
		cur = cur.next;
	}
	if (l1) {
		cur.next = l1;
	}
	if (l2) {
		cur.next = l2;
	}
	return head.next;
}
/**
 * 判断链表是否有环
 * https://www.nowcoder.com/practice/650474f313294468a4ded3ce0f7898b9?tpId=117&tags=&title=&diffculty=0&judgeStatus=0&rp=1
 * @param {Object} head
 */
function hasCycle(head) {
	if (!head) {
		return false
	}
	let slow = head,
		fast = head;
	while (fast && fast.next) {
		slow = slow.next;
		fast = fast.next.next;
		if (slow == fast) {
			return true;
		}
	}
	return false
}
/**
 * 60. 第k个排列
 * https://leetcode-cn.com/problems/permutation-sequence/
 * @param {number} n
 * @param {number} k
 * @return {string}
 */
const getPermutation = (n, k) => { // 以 n=4 k=10 为例
	const nums = [];
	let factorial = 1; // 阶乘  
	for (let i = 1; i <= n; i++) {
		nums.push(i); // [1, 2, 3, 4]
		factorial = factorial * i; // 4!   24
	}

	k--; // nums中数字们的索引是从0开始，k要先减去1
	let resStr = '';
	while (nums.length > 0) { // 选了一个数字就删掉，直到为空
		factorial = factorial / nums.length; //  3! .. 2! .. 1!
		const index = k / factorial | 0; // 当前选择的数字的索引
		resStr += nums[index]; // 加上当前选的数字
		nums.splice(index, 1); // nums删去选的这个数字
		k = k % factorial; // 更新 k，
	}
	return resStr;
};
/**
 * 反转链表
 * https://www.nowcoder.com/practice/75e878df47f24fdc9dc3e400ec6058ca?tpId=117&&tqId=35000&rp=1&ru=/ta/job-code-high&qru=/ta/job-code-high/question-ranking
 * */
function ReverseList(pHead) {
	let pre = null
	while (pHead) {
		let next = pHead.next;
		pHead.next = pre;
		pre = pHead;
		pHead = next;
	}

	return pre;
}

function ListNode(val) {
	this.val = val;
	this.next = null;
}
/**
 * 翻转链表m到n
 * */
var reverseBetween = function(head, m, n) {
	if (m == n) return head;
	let dummy = new ListNode(0);
	dummy.next = head;
	//a和d 节点从虚拟节点开始移动到相应的位置
	let a = dummy,
		d = dummy;
	for (let i = 0; i < m - 1; i++) a = a.next;
	for (let j = 0; j < n; j++) d = d.next;
	let b = a.next,
		c = d.next;
	for (let p = b, q = p.next; q !== c;) {
		let o = q.next;
		q.next = p;
		p = q, q = o;
	}
	a.next = d;
	b.next = c;
	return dummy.next;
};
