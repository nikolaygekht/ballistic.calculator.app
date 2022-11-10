@echo off
cd ..

set projectroot=%cd%

cd BallisticCalculatorNet
msbuild -t:Publish -p:Configuration=Release BallisticCalculatorNet.csproj
cd bin\release\net60-windows\publish
signtool.exe sign /tr "http://timestamp.digicert.com" /td sha256 /fd sha256 /f "%ng-nuget-certificate%" /p "%ng-nuget-certificate-password%" /v BallisticCalculatorNet.exe

cd %projectroot%

cd BallisticCalculatorNet.ReticleEditor
msbuild -t:Publish -p:Configuration=Release BallisticCalculatorNet.ReticleEditor.csproj
cd bin\release\net60-windows\publish
signtool.exe sign /tr "http://timestamp.digicert.com" /td sha256 /fd sha256 /f "%ng-nuget-certificate%" /p "%ng-nuget-certificate-password%" /v BallisticCalculatorNet.ReticleEditor.exe

cd %projectroot%
cd Setup

if exist content del .\content\*.* /q /s
if not exist content mkdir .\content
if not exist content\data mkdir .\content\data

robocopy "%projectroot%\BallisticCalculatorNet\bin\release\net60-windows\publish" "%projectroot%\Setup\content" /S
robocopy "%projectroot%\BallisticCalculatorNet.ReticleEditor\bin\release\net60-windows\publish" "%projectroot%\Setup\content" /S
robocopy "%projectroot%\data" "%projectroot%\Setup\content\data" /S

makensis BallisticCalculator.nsi

signtool.exe sign /tr "http://timestamp.digicert.com" /td sha256 /fd sha256 /f "%ng-nuget-certificate%" /p "%ng-nuget-certificate-password%" /v BallisticCaculatorSetup.exe

cd content
7z a -r BallisticCaculatorPortable.zip *.*
copy BallisticCaculatorPortable.zip ..
del BallisticCaculatorPortable.zip
cd ..