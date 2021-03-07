DnlibEditor is an assembly editor and runs as a plug-in for Red Gate's Reflector.
DnlibEditor is using dnlib by 0xd4d and is able to manipulate IL code and save
the modified assemblies to disk.
DnlibEditor is a replacer for Reflexil plugin.

Separator for Decimal symbol is the one specific for each language -
look on Control Panel for "Regional and Language Options".
Array separator (i.e. for constants) is the ',' char!

Generic type ("-> Generic type refence") are not supported!!

For Windows 64 bit:
DnlibEditor.dll is an 32 bit assembly so can't be loaded
by 64 bit processes like Reflector.exe
So load Reflector.exe on your favorite PE editor
(CFF Explorer is a good one), goto .NET Directory and change
the Flags value: make sure the "32bit required" flag is marked!

Changing Reflector version:
You will need to change the Reflector assembly version
since it has a reference to old Reflector 7.0 version!
For this task use ReferencedVersionChanger! (attached)
Simply add DnlibEditor.dll to the list by clicking "Add files" button
and after that click the "Get them from file" button and select
your Reflector.exe file!
Finish it using Execute button!

Let me know about any bug you may find!

