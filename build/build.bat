@echo off
rd ..\lib\ /s /q
mkdir ..\lib\
cd ..\src\JinianNet.JNTemplate
rd obj\  /s /q
rd bin\  /s /q
dotnet build JinianNet.JNTemplate.csproj --configuration Release
xcopy bin\Release\*.*  ..\..\lib\ /e /y /d
cd ..\..\build\
echo �������...����libĿ¼
pause