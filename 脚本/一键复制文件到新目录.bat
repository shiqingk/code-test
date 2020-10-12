:: createBy mzking 
@echo off

set path_work=D:\经常修改的文件夹
set path_root=D:\最终的目的地文件夹

echo ----脚本检查中
call:funCheck

echo ----开始删除旧的editor
call:func
	if exist %path_to% (
	   rd /s /q %path_to%
	)

echo ----开始创建文件夹
call:func
	md %path_to%

echo ----开始复制
call:func
	XCOPY %path_work% %path_to% /E /Y

echo ----操作结束，请检查
call:func
	pause>nul
	pause>nul

::函数1，延时等待
:func
	ping -n 2 127.0.0.1>nul
goto:eof

::函数2，
:funCheck
	echo ----检查文件是否存在
	call:func
	if not exist %path_work% (
		echo ----输出文件夹不存在
		pause>nul
		call:func
		exit
	)
	if not exist %path_to% (
		echo ----输入文件夹不存在
		pause>nul
		call:func
		exit
	)
	call:func
goto:eof