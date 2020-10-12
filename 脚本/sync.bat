@echo off
w32tm /config /manualpeerlist:"time.nist.gov" /syncfromflags:manual /reliable:yes /update
w32tm /resync
w32tm /resync
w32tm /config /manualpeerlist:"time.windows.com" /syncfromflags:manual /reliable:yes /update
w32tm /resync
w32tm /resync
echo 同步结束！
//pause