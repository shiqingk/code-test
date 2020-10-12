/**
 * 超大数相加
 * */
function sumBigNumber(a, b) {
	var res = '',
		temp = 0;
	a = a.split('');
	b = b.split('');
	while (a.length || b.length || temp) {
		temp += ~~a.pop() + ~~b.pop();
		res = (temp % 10) + res;
		temp = temp > 9;
	}
	return res.replace(/^0+/, '');
}
/**
 * 超大数相乘
 * https://leetcode-cn.com/problems/multiply-strings/submissions/
 * */
const multiply = (num1, num2) => {
	if (num1 == 0 || num2 == 0) {
		return '0';
	}
	let pos = new Array(num1.length + num2.length).fill(0);
	for (let i = num1.length - 1; i >= 0; i--) {
		const n1 = +num1[i];
		for (let j = num2.length - 1; j >= 0; j--) {
			const n2 = +num2[j];
			const multi = n1 * n2;
			const sum = pos[i + j + 1] + multi;
			pos[i + j + 1] = sum % 10;
			pos[i + j] += sum / 10 | 0;
		}
	}
	return pos.join('').replace(/^0+/, '');
};
