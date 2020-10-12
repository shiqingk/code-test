/**
 * 647. 回文子串
 * https://leetcode-cn.com/problems/palindromic-substrings/
 * @param {string} s
 * @return {number}
 */
var countSubstrings = function (s) {
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
 * 有效但是超时
 * 647. 回文子串
 * https://leetcode-cn.com/problems/palindromic-substrings/
 * @param {*} s 
 */
var countSubstrings2 = function (s) {
    let count = 0;
    for (let i = 0; i < s.length; i++) {
        for (let j = i + 1; j <= s.length; j++) {
            let item = s.substring(i, j);
            if (item.length == 1 || item == [...item].reverse().join('')) {
                count++;
            }
        }
    }

    return count;
};