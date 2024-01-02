echo off
cd /d "%~dp0"  REM Switch the current directory to the batch file directory

start "Server" "Server\bin\Debug\net6.0\Server.exe"
start "Client" "Client\bin\Debug\net6.0\Client.exe"