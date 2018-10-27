@echo off
cd /d %~dp0
echo            ��ӭʹ�÷���������̨
echo   ��ȷ�����Ƿ����Թ���Ա���ģʽ���б�����
echo                  www.jiniannet.com
echo .
:cmdshow
echo ��������������������Ҫ�������������������
echo ��  1 ����netframework�桡��������
echo ��  2 ����netcore �桡������������
echo ��  3 ����netstandard �桡��������
echo ��  4 ���������ļ�����������������
echo ��  5 ����core/standard���� ������
echo ��  6 ����netframework������������
echo ��  0 �˳� ���������������� ������
echo ����������������������������������������������������������������
echo .

:cmdinput
set cmdtype=0
set /p cmdtext=input your command:

if /i "%cmdtext%"=="1" goto cmdbuildnf
if /i "%cmdtext%"=="2" goto cmdbuildnc
if /i "%cmdtext%"=="3" goto cmdbuildns
if /i "%cmdtext%"=="4" goto cmdclearfiles
if /i "%cmdtext%"=="5" goto cmdncev
if /i "%cmdtext%"=="6" goto cmdnfev 
if /i "%cmdtext%"=="0" goto cmdexit
if /i "%cmdtext%"=="exit" goto cmdexit
echo input error,try again��
goto cmdinput

:cmdexit
exit

:cmdbuildnf
set cmdtype=1
goto cmdnfev

:cmdbuildnfnext
cd ../src/JinianNet.JNTemplate
set fdir=%WINDIR%\Microsoft.NET\Framework
set key_param=/warn:3 /nologo /o /recurse:*.cs

if exist jiniannet.snk del jiniannet.snk
if exist ../../tool/jiniannet.snk set key_param=/keyfile:../../tool/jiniannet.snk %key_param%

if not exist ..\..\lib\net20 md ..\..\lib\net20
%fdir%\v3.5\csc.exe /target:library /out:../../lib/net20/JinianNet.JNTemplate.dll /doc:../../lib/net20/JinianNet.JNTemplate.xml %key_param% /define:NET20,NOTDNX
echo jntemplate for .net v2.0 build success!

if not exist ..\..\lib\net40 md ..\..\lib\net40
%fdir%\v4.0.30319\csc.exe /target:library /out:../../lib/net40/JinianNet.JNTemplate.dll /doc:../../lib/net40/JinianNet.JNTemplate.xml %key_param% /define:NET40,NOTDNX
echo jntemplate for .net v4.0 build success!

cd ..
cd ..
cd build

if exist ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll del ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll
copy ..\lib\net20\JinianNet.JNTemplate.dll ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll
echo copy files success.
goto cmdinput

:cmdbuildnc
set cmdtype=1
goto cmdncev

:cmdbuildncnext
cd ../src/JinianNet.JNTemplate

dotnet build JinianNet.JNTemplateCore.csproj --configuration Release --output ..\..\lib\netcoreapp2.0

cd ..
cd ..
cd build
echo jntemplate for netcoreapp 2.0 build success!
goto cmdinput


:cmdbuildns
set cmdtype=2
goto cmdncev

:cmdbuildnsnext
cd ../src/JinianNet.JNTemplate

dotnet build JinianNet.JNTemplateStandard.csproj --configuration Release --output ..\..\lib\netstandard2.0 --framework netstandard2.0

cd ..
cd ..
cd build
echo jntemplate for netStandard 2.0 build success!
goto cmdinput

:cmdclearfiles
echo current path:%cd%
del ..\src\JinianNet.JNTemplate.Test\dll\JinianNet.JNTemplate.dll
rd ..\lib /s /q
md ..\lib
del ..\src\JinianNet.JNTemplate.Test\html\*.html
del ..\src\JinianNet.JNTemplate.Test\html\*.txt
if exist ..\TestResults rd ..\TestResults /s /q
rd ..\src\JinianNet.JNTemplate\obj /s /q
rd ..\src\JinianNet.JNTemplate\bin /s /q
rd ..\src\JinianNet.JNTemplate.Test\bin /s /q
rd ..\src\JinianNet.JNTemplate.Test\obj /s /q

echo clear files success!
goto cmdinput


:cmdncev
echo current path:%cd%
if exist ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs.build.tmp if exist ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs del ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs.build.tmp
if exist ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs.build.tmp if exist ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs del ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs.build.tmp

if not exist ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs.build.tmp ren ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp
if not exist ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs.build.tmp ren ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs AssemblyInfo.cs.build.tmp

rd ..\src\JinianNet.JNTemplate\obj /s /q
rd ..\src\JinianNet.JNTemplate\bin /s /q
rd ..\src\JinianNet.JNTemplate.Test\bin /s /q
rd ..\src\JinianNet.JNTemplate.Test\obj /s /q

echo config net core or net Standard env success!

if %cmdtype% equ 1 goto cmdbuildncnext
if %cmdtype% equ 2 goto cmdbuildnsnext
goto cmdinput

:cmdnfev 
echo current path:%cd%
if exist ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs.build.tmp if not exist ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs ren ..\src\JinianNet.JNTemplate\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
if exist ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs.build.tmp if not exist ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs ren ..\src\JinianNet.JNTemplate.Test\Properties\AssemblyInfo.cs.build.tmp AssemblyInfo.cs
rd ..\src\JinianNet.JNTemplate\obj /s /q
rd ..\src\JinianNet.JNTemplate\bin /s /q
rd ..\src\JinianNet.JNTemplate.Test\bin /s /q
rd ..\src\JinianNet.JNTemplate.Test\obj /s /q

echo config framework env success!

if %cmdtype% equ 1 goto cmdbuildnfnext
goto cmdinput