@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set javahome=C:\Program Files\Java\jdk1.8.0_181
echo *                   请先修改第三行的jdk地址为你自己的jdk地址                   *
if not exist %javahome% (
	echo 文件夹%javahome%不存在
	echo 请修改脚本中第三行的jdk地址，形如C:\Program Files\Java\jdk1.8.0_181
	pause>nul
	exit
)
rem LPY
echo.
echo ************************************************************
echo *                                                          *
echo *                   JDK 系统环境变量设置                   *
echo *                                                          *
echo ************************************************************
echo.
echo === 准备设置环境变量: JAVA_HOME=%javahome%
echo === 注意: 如果JAVA_HOME存在,会被覆盖,此操作不可逆的,请仔细检查确认!! ===
echo.
echo === 准备设置环境变量(后面有个.): ClassPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%\lib\dt.jar;.;
echo === 注意: 如果classPath存在,会被覆盖,此操作不可逆的,请仔细检查确认!! ===
echo.
echo === 准备设置环境变量: PATH=%%JAVA_HOME%%\bin
echo === 注意: PATH会追加在最前面
echo.
set /P EN=请确认后按 回车键 开始设置!
echo.
echo.
echo.
echo.
echo === 新创建环境变量 JAVA_HOME=%javahome%
setx "JAVA_HOME" "%javahome%" -M
echo.
echo.
echo === 新创建环境变量 ClassPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.;
setx "ClassPath" "%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.;" -m
echo.
echo.
echo === 新追加环境变量(追加到最前面) PATH=%%JAVA_HOME%%\bin
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%%JAVA_HOME%%\bin;%Y%" -m
echo.
echo.
rem shiqingk
echo === 请按任意键退出!   
pause>nul  