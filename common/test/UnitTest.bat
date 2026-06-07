@ECHO OFF
SETLOCAL
REM LocalSetting
SET EXECUTE_PATH=~dp0
PUSHD %EXECUTE_PATH%
powershell -ExecutionPolicy Unrestricted -File "UnitTest.ps1"
EXIT -1
