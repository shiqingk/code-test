@echo off
set regpath=HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment
set javahome=C:\Program Files\Java\jdk1.8.0_181
echo *                   �����޸ĵ����е�jdk��ַΪ���Լ���jdk��ַ                   *
if not exist %javahome% (
	echo �ļ���%javahome%������
	echo ���޸Ľű��е����е�jdk��ַ������C:\Program Files\Java\jdk1.8.0_181
	pause>nul
	exit
)
rem LPY
echo.
echo ************************************************************
echo *                                                          *
echo *                   JDK ϵͳ������������                   *
echo *                                                          *
echo ************************************************************
echo.
echo === ׼�����û�������: JAVA_HOME=%javahome%
echo === ע��: ���JAVA_HOME����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������(�����и�.): ClassPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%\lib\dt.jar;.;
echo === ע��: ���classPath����,�ᱻ����,�˲����������,����ϸ���ȷ��!! ===
echo.
echo === ׼�����û�������: PATH=%%JAVA_HOME%%\bin
echo === ע��: PATH��׷������ǰ��
echo.
set /P EN=��ȷ�Ϻ� �س��� ��ʼ����!
echo.
echo.
echo.
echo.
echo === �´����������� JAVA_HOME=%javahome%
setx "JAVA_HOME" "%javahome%" -M
echo.
echo.
echo === �´����������� ClassPath=%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.;
setx "ClassPath" "%%JAVA_HOME%%\lib\tools.jar;%%JAVA_HOME%%%\lib\dt.jar;.;" -m
echo.
echo.
echo === ��׷�ӻ�������(׷�ӵ���ǰ��) PATH=%%JAVA_HOME%%\bin
for /f "tokens=1,* delims=:" %%a in ('reg QUERY "%regpath%" /v "path"') do (
    set "L=%%a"
    set "P=%%b"
)
set "Y=%L:~-1%:%P%"

setx path "%%JAVA_HOME%%\bin;%Y%" -m
echo.
echo.
rem shiqingk
echo === �밴������˳�!   
pause>nul  