@echo off
cd ..

set projectroot=%cd%

cd BallisticCalculatorNet
msbuild -t:Publish -p:Configuration=Release BallisticCalculatorNet.csproj
cd bin\release\net80-windows\publish
signtool sign /sha1 "%CERTUM_CERTIFICATE_SHA1%" /fd sha256 /tr http://time.certum.pl /td sha256 BallisticCalculatorNet.exe

cd %projectroot%

cd BallisticCalculatorNet.ReticleEditor
msbuild -t:Publish -p:Configuration=Release BallisticCalculatorNet.ReticleEditor.csproj
cd bin\release\net80-windows\publish
signtool sign /sha1 "%CERTUM_CERTIFICATE_SHA1%" /fd sha256 /tr http://time.certum.pl /td sha256 BallisticCalculatorNet.ReticleEditor.exe

cd %projectroot%
cd Setup

if exist content del .\content\*.* /q /s
if not exist content mkdir .\content
if not exist content\data mkdir .\content\data

robocopy "%projectroot%\BallisticCalculatorNet\bin\release\net80-windows\publish" "%projectroot%\Setup\content" /S
robocopy "%projectroot%\BallisticCalculatorNet.ReticleEditor\bin\release\net80-windows\publish" "%projectroot%\Setup\content" /S
robocopy "%projectroot%\data" "%projectroot%\Setup\content\data" /S

makensis BallisticCalculator.nsi
signtool sign /sha1 "%CERTUM_CERTIFICATE_SHA1%" /fd sha256 /tr http://time.certum.pl /td sha256 BallisticCaculatorSetup.exe
cd content
7z a -r BallisticCaculatorPortable.zip *.*
copy BallisticCaculatorPortable.zip ..
del BallisticCaculatorPortable.zip
cd ..