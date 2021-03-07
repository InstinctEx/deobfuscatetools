; #########################################################################
;
;          Build this DLL from the batch file called BldDLL.bat
;
; #########################################################################

    .386
    .model flat, stdcall
    option casemap :none   ; case sensitive

; #########################################################################

    include \masm32\include\windows.inc
    include \masm32\include\user32.inc
    include \masm32\include\kernel32.inc

    includelib \masm32\lib\user32.lib
    includelib \masm32\lib\kernel32.lib

    WordToInt PROTO :DWORD,:DWORD
    BytesToString PROTO :DWORD,:DWORD,:DWORD
; #########################################################################

.data
savedEAX dd 0
savedEBX dd 0
savedECX dd 0
savedEDX dd 0
savedESP dd 0
savedEBP dd 0
savedESI dd 0
savedEDI dd 0
fileHandle  dd 0
szFName  db '\methodbody.txt',0
Zero  db '0',0
NewLine  db 0dh,0ah,0
ToConvert dw 1234h
ToConvert2 db 0AFh,34h,56h
ToConvert2size dd 3
numbkeep dd 0
forconv BYTE 5 dup (0)
Space  db 20h,0
ForConv BYTE 50000 dup (0)
format db "%X",0

.DATA?
BytesWritten  DWORD ?
.code
start:
mov savedEAX,eax
mov savedEBX,ebx
mov savedECX,ecx
mov savedEDX,edx
mov savedESP,esp
mov savedEBP,ebp
mov savedESI,esi
mov savedEDI,edi
;
MOV EDI,DWORD PTR SS:[ESP-010h] ; get CORINFO_METHOD_INFO from stack
invoke CreateFile, addr szFName, GENERIC_WRITE, FILE_SHARE_READ + FILE_SHARE_WRITE, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0
.if eax==0FFFFFFFFh
invoke CreateFile, addr szFName, GENERIC_WRITE, FILE_SHARE_READ + FILE_SHARE_WRITE, 0, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0
.endif
mov fileHandle,eax

; Move the file pointer to the end of the file
INVOKE SetFilePointer,fileHandle,0,0,FILE_END

mov eax,dword ptr [edi]
movzx eax,word ptr [eax]
invoke WordToInt, eax,offset ForConv

invoke WriteFile, fileHandle, addr ForConv, 4, addr BytesWritten, 0
invoke WriteFile, fileHandle, addr Space, 01, addr BytesWritten, 0

; mov esi,dword ptr [edi+8] ; ILCODE
; cmp ecx,dword ptr [edi+12] ; ILCODE SIZE

invoke BytesToString,dword ptr [edi+8],dword ptr [edi+12],offset ForConv
invoke WriteFile, fileHandle, addr ForConv, eax, addr BytesWritten, 0
invoke WriteFile, fileHandle, addr Space, 01, addr BytesWritten, 0

MOVZX EAX,WORD PTR DS:[EDI+010h] ; max stack
invoke WordToInt, eax,offset ForConv
invoke WriteFile, fileHandle, addr ForConv, 4, addr BytesWritten, 0
invoke WriteFile, fileHandle, addr Space, 01, addr BytesWritten, 0

MOV EAX,DWORD PTR DS:[EDI+014h] ; options
invoke WordToInt, eax,offset ForConv
invoke WriteFile, fileHandle, addr ForConv, 4, addr BytesWritten, 0
invoke WriteFile, fileHandle, addr Space, 01, addr BytesWritten, 0

MOV EAX,DWORD PTR DS:[EDI+070h] ; sig
.if eax==0
invoke WriteFile, fileHandle, addr Zero, 1, addr BytesWritten, 0
.else
MOVZX ECX,BYTE PTR DS:[EAX-1] ; signsize
invoke BytesToString,DWORD PTR DS:[EDI+070h],ecx,offset ForConv
invoke WriteFile, fileHandle, addr ForConv, eax, addr BytesWritten, 0
.endif

invoke WriteFile, fileHandle, addr NewLine, 02, addr BytesWritten, 0
INVOKE CloseHandle, fileHandle

mov eax,savedEAX
mov ebx,savedEBX
mov ecx,savedECX
mov edx,savedEDX
mov esp,savedESP
mov ebp,savedEBP
mov esi,savedESI
mov edi,savedEDI

mov eax,0123456
jmp eax
ret

WordToInt proc value:DWORD,Destination:DWORD
mov eax,value
shr ax,8
shr ax,4
.if al > 9
 add al,7
.endif
add al,030h  ; convert to char
mov ecx,dword ptr [Destination]
mov byte ptr [ecx],al
mov eax,value
shr ax,8
and ax,0Fh
.if al > 9
 add al,7
.endif
add al,030h  ; convert to char
mov ecx,dword ptr [Destination]
mov byte ptr [ecx+1],al
mov eax,value
and ax,0F0h
shr ax,4
.if al > 9
 add al,7
.endif
add al,030h  ; convert to char
mov ecx,dword ptr [Destination]
mov byte ptr [ecx+2],al
mov eax,value
and ax,0Fh
.if al > 9
 add al,7
.endif
add al,030h  ; convert to char
mov ecx,dword ptr [Destination]
mov byte ptr [ecx+3],al
mov byte ptr [ecx+4],0
    ret

WordToInt endp


BytesToString proc input:DWORD,isize:DWORD,Destination:DWORD
push edi
xor ecx,ecx
mov esi,input ; source
mov edi,dword ptr [Destination]
BeginOfLoop:
mov al,byte ptr [esi+ecx]
shr al,4
.if al > 9
 add al,7
.endif
add al,030h  ; convert to char
mov byte ptr [edi+ecx*2],al
mov al,byte ptr [esi+ecx]
and al,00Fh
.if al > 9
 add al,7
.endif
add al,030h  ; convert to char
mov byte ptr [edi+ecx*2+1],al
inc ecx
cmp ecx,isize ; SIZE
jl BeginOfLoop
mov byte ptr [edi+2*ecx],0
lea eax,[ecx*2]
pop edi
ret
BytesToString endp

; ##########################################################################

LibMain proc hInstDLL:DWORD, reason:DWORD, unused:DWORD
        ret
LibMain Endp

; ##########################################################################

TestProc proc

    ret

TestProc endp

; ##########################################################################

End LibMain
