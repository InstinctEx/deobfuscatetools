namespace DeployLX.Licensing.v4
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Principal;
    using System.Text;

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    internal sealed class Class21
    {
        /* private scope */ public static bool bool_0 = (IntPtr.Size == 8);
        /* private scope */ public static bool bool_1 = smethod_0();

        private Class21()
        {
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr intptr_0);
        [DllImport("setupapi.dll", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int CM_Locate_DevNode(out IntPtr intptr_0, string string_0, int int_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", SetLastError=true)]
        public static extern bool ConvertSidToStringSid(IntPtr intptr_0, ref IntPtr intptr_1);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", CharSet=CharSet.Unicode)]
        internal static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor([In, MarshalAs(UnmanagedType.LPTStr)] string string_0, int int_0, out IntPtr intptr_0, out ulong ulong_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool ConvertStringSidToSid([MarshalAs(UnmanagedType.LPTStr)] string string_0, ref IntPtr intptr_0);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern IntPtr CreateFile(string string_0, uint uint_0, uint uint_1, IntPtr intptr_0, uint uint_2, uint uint_3, IntPtr intptr_1);
        [DllImport("gdi32")]
        public static extern IntPtr CreatePatternBrush(IntPtr intptr_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool DeleteAce(IntPtr intptr_0, int int_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32")]
        public static extern bool DeleteObject(IntPtr intptr_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool DeviceIoControl(IntPtr intptr_0, int int_0, IntPtr intptr_1, int int_1, [Out] byte[] byte_0, int int_2, ref int int_3, IntPtr intptr_2);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool DuplicateToken(IntPtr intptr_0, int int_0, ref IntPtr intptr_1);
        [DllImport("user32")]
        public static extern int FillRect(IntPtr intptr_0, byte[] byte_0, IntPtr intptr_1);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int FreeLibrary(IntPtr intptr_0);
        [DllImport("iphlpapi", CharSet=CharSet.Unicode)]
        public static extern int GetAdaptersInfo([Out] byte[] byte_0, ref uint uint_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool GetDiskFreeSpaceEx([In] string string_0, out long long_0, out long long_1, out long long_2);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int GetDriveType(string string_0);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern IntPtr GetModuleHandle(string string_0);
        [DllImport("advapi32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int GetNamedSecurityInfo(string string_0, int int_0, int int_1, [Out] IntPtr intptr_0, [Out] IntPtr intptr_1, out IntPtr intptr_2, [Out] IntPtr intptr_3, out IntPtr intptr_4);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);
        [DllImport("user32", CharSet=CharSet.Unicode, ExactSpelling=true)]
        public static extern int GetSystemMetrics(int int_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool GetSystemPowerStatus(byte[] byte_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32", CharSet=CharSet.Unicode)]
        public static extern bool GetTextExtentPoint32(IntPtr intptr_0, string string_0, int int_0, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0, SizeConst=8)] byte[] byte_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", SetLastError=true)]
        public static extern bool GetTokenInformation(IntPtr intptr_0, int int_0, IntPtr intptr_1, int int_1, ref int int_2);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool GetVersionEx(IntPtr intptr_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool GetVolumeInformation([In] string string_0, [Out] StringBuilder stringBuilder_0, int int_0, out int int_1, out int int_2, out int int_3, [Out] StringBuilder stringBuilder_1, int int_4);
        [DllImport("kernel32", CharSet=CharSet.Unicode)]
        public static extern void GlobalMemoryStatus(byte[] byte_0);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int GlobalMemoryStatusEx(byte[] byte_0);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern IntPtr LoadLibraryExW([MarshalAs(UnmanagedType.LPWStr)] string string_0, IntPtr intptr_0, uint uint_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("advapi32", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool LogonUser([MarshalAs(UnmanagedType.LPTStr)] string string_0, [MarshalAs(UnmanagedType.LPTStr)] string string_1, [MarshalAs(UnmanagedType.LPTStr)] string string_2, int int_0, int int_1, ref IntPtr intptr_0);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32", SetLastError=true)]
        public static extern bool MessageBeep(int int_0);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtCreateKey([In, Out] ref IntPtr intptr_0, uint uint_0, IntPtr intptr_1, int int_0, IntPtr intptr_2, int int_1, [In, Out] ref int int_2);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtDeleteKey(IntPtr intptr_0);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtDeleteValueKey(IntPtr intptr_0, IntPtr intptr_1);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtEnumerateValueKey(IntPtr intptr_0, int int_0, int int_1, [Out] byte[] byte_0, int int_2, out int int_3);
        [DllImport("ntdll", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern uint NtFsControlFile(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3, [Out] byte[] byte_0, uint uint_0, [In, Out] byte[] byte_1, uint uint_1, [Out] ulong[] ulong_0, uint uint_2);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtOpenKey(out IntPtr intptr_0, uint uint_0, IntPtr intptr_1);
        [DllImport("ntdll")]
        public static extern int NtQuerySystemInformation(int int_0, byte[] byte_0, int int_1, out int int_2);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtQueryValueKey(IntPtr intptr_0, IntPtr intptr_1, int int_0, [Out] byte[] byte_0, int int_1, out int int_2);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtSetSecurityObject(IntPtr intptr_0, int int_0, IntPtr intptr_1);
        [DllImport("ntdll", CharSet=CharSet.Unicode)]
        public static extern int NtSetValueKey(IntPtr intptr_0, IntPtr intptr_1, int int_0, int int_1, byte[] byte_0, int int_2);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int QueryDosDevice(string string_0, StringBuilder stringBuilder_0, int int_0);
        [DllImport("gdi32")]
        public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);
        [DllImport("user32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, IntPtr intptr_2);
        [DllImport("gdi32")]
        public static extern int SetBkMode(IntPtr intptr_0, int int_0);
        [DllImport("advapi32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int SetEntriesInAcl(int int_0, [In, Out] ref Struct36 struct36_0, IntPtr intptr_0, out IntPtr intptr_1);
        [DllImport("advapi32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern int SetNamedSecurityInfo(string string_0, int int_0, uint uint_0, IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3);
        [DllImport("gdi32")]
        public static extern int SetTextColor(IntPtr intptr_0, int int_0);
        [DllImport("shell32", CharSet=CharSet.Unicode)]
        public static extern int SHGetFolderPath(IntPtr intptr_0, int int_0, IntPtr intptr_1, int int_1, StringBuilder stringBuilder_0);
        private static bool smethod_0()
        {
            return (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432") != null);
        }

        public static string smethod_1()
        {
            string str;
            byte[] buffer = new byte[0x100];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                WindowsIdentity current = WindowsIdentity.GetCurrent();
                int num = 0;
                if (!GetTokenInformation(current.Token, 1, handle.AddrOfPinnedObject(), buffer.Length, ref num))
                {
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
                IntPtr zero = IntPtr.Zero;
                try
                {
                    ConvertSidToStringSid(Marshal.ReadIntPtr(handle.AddrOfPinnedObject()), ref zero);
                    str = Marshal.PtrToStringAnsi(zero);
                }
                finally
                {
                    if (zero != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(zero);
                    }
                }
            }
            finally
            {
                handle.Free();
            }
            return str;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("gdi32", CharSet=CharSet.Unicode)]
        public static extern bool TextOut(IntPtr intptr_0, int int_0, int int_1, string string_0, int int_2);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool VirtualProtect([In] byte[] byte_0, IntPtr intptr_0, int int_0, out int int_1);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr intptr_0);
        [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr intptr_0);

        public class Class22 : IDisposable
        {
            /* private scope */ GCHandle gchandle_0;
            /* private scope */ GCHandle gchandle_1;
            /* private scope */ Class21.Struct38 struct38_0 = new Class21.Struct38();

            public Class22(string value)
            {
                this.struct38_0.ushort_0 = (ushort) (value.Length * 2);
                this.struct38_0.ushort_1 = this.struct38_0.ushort_0;
                this.gchandle_0 = GCHandle.Alloc(value, GCHandleType.Pinned);
                this.struct38_0.intptr_0 = this.gchandle_0.AddrOfPinnedObject();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);
                this.method_1();
            }

            ~Class22()
            {
                this.method_1();
            }

            public IntPtr method_0()
            {
                if (!this.gchandle_1.IsAllocated)
                {
                    this.gchandle_1 = GCHandle.Alloc(this.struct38_0, GCHandleType.Pinned);
                }
                return this.gchandle_1.AddrOfPinnedObject();
            }

            public void method_1()
            {
                if (this.gchandle_1.IsAllocated)
                {
                    this.gchandle_1.Free();
                }
                if (this.gchandle_0.IsAllocated)
                {
                    this.gchandle_0.Free();
                }
            }
        }

        public class Class23 : IDisposable
        {
            /* private scope */ Class21.Class22 class22_0;
            /* private scope */ GCHandle gchandle_0;
            /* private scope */ IntPtr intptr_0;
            /* private scope */ Class21.Struct39 struct39_0 = new Class21.Struct39();

            public void Dispose()
            {
                GC.SuppressFinalize(this);
                this.method_2();
            }

            ~Class23()
            {
                this.method_2();
            }

            public void method_0(string string_0, uint uint_0, IntPtr intptr_1, IntPtr intptr_2)
            {
                this.method_2();
                this.struct39_0.uint_0 = (uint) Marshal.SizeOf(this.struct39_0);
                this.struct39_0.intptr_0 = intptr_1;
                this.struct39_0.uint_1 = uint_0;
                this.class22_0 = new Class21.Class22(string_0);
                this.struct39_0.intptr_1 = this.class22_0.method_0();
                if (intptr_2 == new IntPtr(-1))
                {
                    ulong num;
                    Class21.ConvertStringSecurityDescriptorToSecurityDescriptor(string.Format("O:{0}G:S-1-3-1D:(A;;GA;;;S-1-1-0)", Class21.smethod_1()), 1, out this.intptr_0, out num);
                    intptr_2 = this.intptr_0;
                }
                this.struct39_0.intptr_2 = intptr_2;
                this.struct39_0.intptr_3 = IntPtr.Zero;
            }

            public IntPtr method_1()
            {
                this.gchandle_0 = GCHandle.Alloc(this.struct39_0, GCHandleType.Pinned);
                return this.gchandle_0.AddrOfPinnedObject();
            }

            public void method_2()
            {
                if (this.gchandle_0.IsAllocated)
                {
                    this.gchandle_0.Free();
                }
                if (this.class22_0 != null)
                {
                    this.class22_0.Dispose();
                    this.class22_0 = null;
                }
                if (this.intptr_0 != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(this.intptr_0);
                    this.intptr_0 = IntPtr.Zero;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct36
        {
            /* private scope */ public int int_0;
            /* private scope */ public int int_1;
            /* private scope */ public int int_2;
            /* private scope */ public Class21.Struct37 struct37_0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct37
        {
            /* private scope */ public IntPtr intptr_0;
            /* private scope */ public int int_0;
            /* private scope */ public int int_1;
            /* private scope */ public int int_2;
            /* private scope */ public IntPtr intptr_1;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct38
        {
            /* private scope */ public ushort ushort_0;
            /* private scope */ public ushort ushort_1;
            /* private scope */ public IntPtr intptr_0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct39
        {
            /* private scope */  public uint uint_0;
            /* private scope */  public IntPtr intptr_0;
            /* private scope */  public IntPtr intptr_1;
            /* private scope */  public uint uint_1;
            /* private scope */  public IntPtr intptr_2;
            /* private scope */  public IntPtr intptr_3;
        }
    }
}

