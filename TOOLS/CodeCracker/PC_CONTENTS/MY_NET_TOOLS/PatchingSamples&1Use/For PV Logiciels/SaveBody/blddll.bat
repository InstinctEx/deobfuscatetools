@echo off

if exist SaveBody.obj del SaveBody.obj
if exist SaveBody.dll del SaveBody.dll

\masm32\bin\ml /c /coff SaveBody.asm

\masm32\bin\Link /SUBSYSTEM:WINDOWS /DLL /DEF:SaveBody.def SaveBody.obj

dir SaveBody.*

pause