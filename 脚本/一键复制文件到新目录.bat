:: createBy mzking 
@echo off

set path_work=D:\�����޸ĵ��ļ���
set path_root=D:\���յ�Ŀ�ĵ��ļ���

echo ----�ű������
call:funCheck

echo ----��ʼɾ���ɵ�editor
call:func
	if exist %path_to% (
	   rd /s /q %path_to%
	)

echo ----��ʼ�����ļ���
call:func
	md %path_to%

echo ----��ʼ����
call:func
	XCOPY %path_work% %path_to% /E /Y

echo ----��������������
call:func
	pause>nul
	pause>nul

::����1����ʱ�ȴ�
:func
	ping -n 2 127.0.0.1>nul
goto:eof

::����2��
:funCheck
	echo ----����ļ��Ƿ����
	call:func
	if not exist %path_work% (
		echo ----����ļ��в�����
		pause>nul
		call:func
		exit
	)
	if not exist %path_to% (
		echo ----�����ļ��в�����
		pause>nul
		call:func
		exit
	)
	call:func
goto:eof