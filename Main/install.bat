@ECHO OFF

set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%

echo Installing Service...
echo ---------------------------------------------------
InstallUtil /i Main.exe
echo ---------------------------------------------------
echo Done.