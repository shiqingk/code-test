function fun() {
	function cal(k, n, m) {
		let exChange = parseInt(k).toString(m)
		let count = 0;
		for (let i = 0; i < exChange.length; i++) {
			if (exChange[i] == n.toString()) {
				count++
			}
		}
		console.log(count)
		let reg = new RegExp('/' + n + '/', 'g')
		// console.log(exChange.replace(reg, ''))
		console.log(exChange.length - exChange.replace(reg, '').length);
	}

	return cal(10, 2, 4);
}

function fun3() {
	function getLost(arr) {
		debugger
		if (arr.length == 1 && arr[0] != 0) {
			return 0
		}
		if (arr[0] != 0 || arr.length == 0) {
			return 0
		}
		if (arr[arr.length - 1] == arr.length - 1) {
			return arr.length
		}

		let lost = []
		for (let i = 1; i < arr.length; i++) {
			if (arr[i] - arr[i - 1] != 1) {
				return arr[i] - 1;
			}
		}
		return 0;
	}
	return getLost([0, 1, 2, 3, 4].sort((a, b) => a - b));
	/*function cal(k,n,m){
	    let exChange = parseInt(k).toString(m);
	    let count=0;
	    return exChange.replace(new RegExp(String(m),'g'),'').length
	    // console.log(count)
	}*/
	//return cal(10, 4, 4);
}


function fun4() {
	function getMaxArea(arr, m, n) {
		let obj = {}, //记录所有小旗子，及其数量，不一定成对
			key = {}; //有成对的小旗子
		for (let i = 0; i < m; i++) {
			for (let j = 0; j < n; j++) {
				let val = arr[i][j]
				if (val > 0) {
					obj[val] ? obj[val]++ : obj[val] = 1;
					if (obj[val] > 1) {
						key[val] = val;
					}
				}
			}
		}
		let keys = Object.keys(key);
		if (keys.length == 0) { //不存在成对的旗子，结束
			console.log(1);
			return;
		}
		let max = 1;
		for (let t = 0; t < keys.length; t++) {
			let item = parseInt(keys[t]), //当前成对的小旗子，然后在所有片区找出他的最大面积
				minX,
				maxX,
				minY,
				maxY;
			for (let i = 0; i < m; i++) {
				for (let j = 0; j < n; j++) {
					if (arr[i][j] == item) {
						minX = Math.min(minX !== undefined ? minX : j, j);
						maxX = Math.max(maxX !== undefined ? maxX : j, j);
						minY = Math.min(minY !== undefined ? minY : i, i);
						maxY = Math.max(maxY !== undefined ? maxY : i, i);
					}
				}
			}
			//计算最大面积
			max = Math.max(max, (maxX - minX + 1) * (maxY - minY + 1));
		}
		console.log(max);
	}
	return getMaxArea([
		[1, 0, 1],
		[0, 0, 0],
		[0, 1, 0, ]
	], 3, 3);
}

/*

第一题,输入k,m,n,
	k是十进制数
	m是匹配的数字
	n是进制
	要求,将k按n进制转换,然后输出包含多少个m
第二题,
	0到n+1个数,但是只接收到了n个,找出丢失的那个数
	发送是按顺序发送,但是接收的时候不是
	
第三题
	m*n个格子,有若干个小旗子,每个小旗子都有个数字
	计算出,包含多个相同小旗子的最大矩形面积
	*/

/**
 * 华为一面
 * 3*3格子，奇数列从上往下打印，欧数列从下往上打印
 * */
function fun1() {
	let f = (arr) => {
		let ret = [],
			col = 0;
		while (arr[0].length) {
			if (col % 2 == 0) {
				for (let i = 0; i < arr.length; i++) {
					ret.push(arr[i].shift());
				}
			} else {
				for (let i = arr.length - 1; i >= 0; i--) {
					ret.push(arr[i].shift());
				}
			}
			col++;
		}
		return ret;
	}
	return f([
		[1, 2, 3, 5],
		[4, 5, 6, 7],
		[7, 8, 9, 9],
		[6, 7, 8, 3],
	]);
}
