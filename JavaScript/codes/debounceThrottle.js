/**
 * 少发请求
 * 最后一次调用时执行，t时间内未再次调用，说明上一次是最后一次
 * 
 * 应用在前端时,常见的场景是,输入框打字动作结束一段时间后再去触发查询/搜索/校验,
 * 而不是每打一个字都要去触发,造成无意义的ajax查询等,
 * 或者与调整窗口大小绑定的函数,其实只需要在最后窗口大小固定之后再去执行动作.
 */
var jieliu = function(f, t = 1000) {
	let index;
	return function() {
		let arg = arguments;
		if (index) {
			clearTimeout(index);
		}
		index = setTimeout(() => {
			f.apply(this, arg);
		}, t);
	}
}

/**
 * 防抖，没隔多久调用一次
 */
var fun = function(f, t = 1000) {
	let last = 0; //子函数中还在使用，不会被gc回收
	return function() { //每次都会触发
		if (Date.now() - last < t) {
			return;
		}
		f.apply(this, arguments);
		last = Date.now();
	}
}



let input = document.querySelector('#data');
input.addEventListener('input', jieliu(function(e) {
	console.log("您的输入是", e.target.value)
}));
