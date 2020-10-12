let t1 = 0;

function log(params) {
	console.log(params);
	console.log('总计用时', new Date().getTime() - t1, 'ms');

	$('#data').val(Array.isArray(params) ? params.join(',') : JSON.stringify(params));
}
t1 = new Date().getTime();

let val = 0;

//log(cal('10.0.3.193'));
log(fun());
/*
reset
reset board
board add
board delet
reboot backplane
backplane abort
*/
