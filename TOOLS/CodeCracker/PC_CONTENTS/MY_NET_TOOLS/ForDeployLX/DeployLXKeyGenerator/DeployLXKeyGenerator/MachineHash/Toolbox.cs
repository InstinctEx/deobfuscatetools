namespace DeployLX.Licensing.v4
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Windows.Forms;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class Toolbox
    {
        /* private scope */ static readonly ControlStyles controlStyles_0 = ((Environment.Version.Major >= 2) ? (ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer) : ControlStyles.DoubleBuffer);
        [ThreadStatic]
        /* private scope */ static int int_0;
        /* private scope */ static int int_1 = -1;
        /* private scope */ static int int_2 = -1;
        /* private scope */ static int int_3 = -1;
        /* private scope */ static int int_4;
        /* private scope */ static int int_5;
        /* private scope */ static MethodInfo methodInfo_0;
        /* private scope */ static MethodInfo methodInfo_1;
        [CompilerGenerated]
        /* private scope */ static ThreadStart threadStart_0;
        /* private scope */ static System.Type type_0;

        static Toolbox()
        {
            try
            {
                //smethod_1();
            }
            catch
            {
                int_2 = 0;
            }
            try
            {
                type_0 = Assembly.Load("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089").GetType("System.Security.Cryptography.AesCryptoServiceProvider");
            }
            catch (FileNotFoundException)
            {
            }
            catch (BadImageFormatException)
            {
            }
            if (type_0 == null)
            {
                type_0 = typeof(RijndaelManaged);
            }
        }

        public static bool CanGetControlAsBitmap()
        {
            if (int_5 == 0)
            {
                try
                {
                    Control control = new Control();
                    methodInfo_1 = typeof(Control).GetMethod("GetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
                    methodInfo_0 = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
                    if ((methodInfo_1 != null) && (methodInfo_0 != null))
                    {
                        methodInfo_0.Invoke(control, new object[] { ControlStyles.DoubleBuffer, true });
                    }
                    int_5 = 1;
                }
                catch
                {
                    int_5 = -1;
                }
            }
            return (int_5 == 1);
        }

        public static bool CheckInternetConnection(Uri suggestedUrl)
        {
            if (suggestedUrl == null)
            {
                suggestedUrl = new Uri("http://www.google.com");
            }
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(suggestedUrl.Host, suggestedUrl.Port);
                client.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int FastParseInt32(string value)
        {
            if (value == null)
            {
                return 0;
            }
            return FastParseInt32(value, 0, value.Length);
        }

        public static int FastParseInt32(string value, int start, int length)
        {
            if (value == null)
            {
                return 0;
            }
            int num = 0;
            int num2 = start;
            bool flag = false;
            if (value[0] == '-')
            {
                num2++;
                flag = true;
            }
            int num3 = start + length;
            while (num2 < num3)
            {
                num = (num * 10) + (value[num2] - '0');
                num2++;
            }
            if (!flag)
            {
                return num;
            }
            return -num;
        }

        public static DateTime FastParseSortableDate(string value)
        {
            //DeployLX.Licensing.v4.Check.NotNull(value, "value");
            if (value.Length != 0x13)
            {
                throw new ArgumentException("Invalid date", "value");
            }
            return new DateTime(FastParseInt32(value, 0, 4), FastParseInt32(value, 5, 2), FastParseInt32(value, 8, 2), FastParseInt32(value, 11, 2), FastParseInt32(value, 14, 2), FastParseInt32(value, 0x11, 2), DateTimeKind.Utc);
        }

        public static string FormatSortableDate(DateTime date)
        {
            return string.Format("{0:0000}-{1:00}-{2:00}T{3:00}:{4:00}:{5:00}", new object[] { date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second });
        }

        public static string FormatTime(long seconds, long max, bool includeUnit)
        {
            string str = null;
            if (max > 0x15180)
            {
                str = "M_Days";
                seconds = (int) Math.Ceiling((double) (((float) seconds) / 86400f));
            }
            else if (max > 0xe10)
            {
                str = "M_Hours";
                seconds = (int) Math.Ceiling((double) (((float) seconds) / 3600f));
            }
            else if (max > 60)
            {
                str = "M_Minutes";
                seconds = (int) Math.Ceiling((double) (((float) seconds) / 60f));
            }
            else
            {
                str = "M_Seconds";
            }
            if (!includeUnit)
            {
                return seconds.ToString();
            }
            if (seconds == 1)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return string.Format("{0} {1}", seconds, Class37.smethod_0(str, new object[0]));
        }

        public static SymmetricAlgorithm GetAes(bool forceFips)
        {
            return (Activator.CreateInstance(type_0) as SymmetricAlgorithm);
        }

        public static Bitmap GetControlAsBitmap(Control ctrl)
        {
            Bitmap bitmap3;
            if (ctrl == null)
            {
                return null;
            }
            Form form = ctrl.FindForm();
            if (ctrl.IsDisposed || ((form != null) && form.IsDisposed))
            {
                return null;
            }
            if (ctrl.InvokeRequired)
            {
                return (ctrl.Invoke(new Delegate13(Toolbox.GetControlAsBitmap), new object[] { ctrl }) as Bitmap);
            }
            using (ThreadBoost(ThreadPriority.Highest))
            {
                if (!ctrl.IsHandleCreated)
                {
                    ctrl.CreateControl();
                }
                Bitmap image = new Bitmap(ctrl.Width, ctrl.Height, PixelFormat.Format32bppRgb);
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    IntPtr hdc = graphics.GetHdc();
                    ArrayList list = new ArrayList();
                    try
                    {
                        smethod_4(ctrl, list);
                        Class21.SendMessage(ctrl.Handle, 0x317, hdc, (IntPtr) 0x17);
                        bitmap3 = image;
                    }
                    finally
                    {
                        graphics.ReleaseHdc(hdc);
                        foreach (Control control in list)
                        {
                            methodInfo_0.Invoke(control, new object[] { controlStyles_0, true });
                        }
                    }
                }
            }
            return bitmap3;
        }

        [ComVisible(false)]
        public static string GetFullPath(string path)
        {
            if (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile == null)
            {
                return null;
            }
            return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile), path);
        }

        public static Image GetImage(Stream stream)
        {
            try
            {
                Image original = null;
                if (stream != null)
                {
                    original = Image.FromStream(stream);
                    if (original != null)
                    {
                        try
                        {
                            return new Bitmap(original, original.Size);
                        }
                        finally
                        {
                            original.Dispose();
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static RegistryKey GetRegistryKey(string key, bool writeAccess)
        {
            //DeployLX.Licensing.v4.Check.NotNull(key, "key");
            int indexA = key.StartsWith("registry:") ? 9 : 0;
            if (((indexA == 0) && (key.Length < 5)) || ((indexA == 9) && (key.Length < 14)))
            {
                throw new ArgumentException("E_InvalidRegistryKey");
            }
            RegistryKey localMachine = null;
            bool flag = false;
            if (string.Compare(key, indexA, "HKLM", 0, 4, true, CultureInfo.InvariantCulture) == 0)
            {
                localMachine = Registry.LocalMachine;
            }
            else if (string.Compare(key, indexA, "HKCU", 0, 4, true, CultureInfo.InvariantCulture) == 0)
            {
                localMachine = Registry.CurrentUser;
            }
            else if (string.Compare(key, indexA, "HKCR", 0, 4, true, CultureInfo.InvariantCulture) == 0)
            {
                localMachine = Registry.ClassesRoot;
            }
            else if (string.Compare(key, indexA, "HK*U", 0, 4, true, CultureInfo.InvariantCulture) == 0)
            {
                localMachine = Registry.CurrentUser;
                flag = true;
            }
            else if (string.Compare(key, indexA, "HK*M", 0, 4, true, CultureInfo.InvariantCulture) == 0)
            {
                localMachine = Registry.LocalMachine;
                flag = true;
            }
            if (localMachine == null)
            {
                throw new ArgumentException(Class37.smethod_0("E_InvalidRegistryKey", new object[] { key }), "code");
            }
            string name = key.Substring(indexA + 5);
            RegistryKey key3 = localMachine.OpenSubKey(name, writeAccess);
            if (!flag || (key3 != null))
            {
                return key3;
            }
            if (localMachine == Registry.CurrentUser)
            {
                return Registry.LocalMachine.OpenSubKey(name, writeAccess);
            }
            return Registry.CurrentUser.OpenSubKey(name, writeAccess);
        }




        public static void GrantEveryoneAccess(string path)
        {
            if ((path != null) && (path.Length != 0))
            {
                bool flag = path.StartsWith("reg::");
                try
                {
                    if (threadStart_0 == null)
                    {
                        threadStart_0 = new ThreadStart(Toolbox.smethod_5);
                    }
                    Thread thread = new Thread(threadStart_0);
                    thread.Start();
                    thread.Join();
                }
                catch
                {
                }
                using (new Class46())
                {
                    if (flag)
                    {
                        if (path.StartsWith("reg::HKEY_CURRENT_USER"))
                        {
                            path = path.Substring(10);
                        }
                        else if (path.StartsWith("reg::HKCU"))
                        {
                            path = "CURRENT_USER" + path.Substring(9);
                        }
                        else if (path.StartsWith("reg::HKEY_LOCAL_MACHINE"))
                        {
                            path = "MACHINE" + path.Substring(0x18);
                        }
                        else if (path.StartsWith("reg::HKLM"))
                        {
                            path = "MACHINE" + path.Substring(9);
                        }
                        else if (path.StartsWith("reg::HKEY_CLASSES_ROOT"))
                        {
                            path = path.Substring(9);
                        }
                        else if (path.StartsWith("reg::HKCR"))
                        {
                            path = "CLASSES_ROOT" + path.Substring(9);
                        }
                        else if (path.StartsWith("reg::HKEY_USERS"))
                        {
                            path = path.Substring(10);
                        }
                        else if (path.StartsWith("reg::HKU"))
                        {
                            path = "USERS" + path.Substring(8);
                        }
                        else
                        {
                            path = path.Substring(5);
                        }
                    }
                    else if (!System.IO.File.Exists(path) && !Directory.Exists(path))
                    {
                        return;
                    }
                    IntPtr zero = IntPtr.Zero;
                    IntPtr ptr2 = IntPtr.Zero;
                    IntPtr ptr3 = IntPtr.Zero;
                    if (path.IndexOf('\0') > -1)
                    {
                        path = path.Replace("\0", "");
                    }
                    try
                    {
                        int error = Class21.GetNamedSecurityInfo(path, flag ? 4 : 1, 4, IntPtr.Zero, IntPtr.Zero, out zero, IntPtr.Zero, out ptr2);
                        if (error != 0)
                        {
                            throw new Win32Exception(error);
                        }
                        Class21.Struct36 struct2 = new Class21.Struct36 {
                            int_0 = 0x1fffff,
                            int_1 = 1,
                            int_2 = 0
                        };
                        if (!Class21.ConvertStringSidToSid("S-1-1-0", ref struct2.struct37_0.intptr_1))
                        {
                            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                        }
                        struct2.struct37_0.intptr_0 = IntPtr.Zero;
                        struct2.struct37_0.int_1 = 0;
                        struct2.struct37_0.int_2 = 5;
                        while (Class21.DeleteAce(zero, 0))
                        {
                        }
                        error = Class21.SetEntriesInAcl(1, ref struct2, zero, out ptr3);
                        if (error != 0)
                        {
                            throw new Win32Exception(error);
                        }
                        error = Class21.SetNamedSecurityInfo(path, flag ? 4 : 1, 0x20000004, IntPtr.Zero, IntPtr.Zero, ptr3, IntPtr.Zero);
                        if (error != 0)
                        {
                            throw new Win32Exception(error);
                        }
                    }
                    finally
                    {
                        if (ptr2 != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(ptr2);
                        }
                        if (ptr3 != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(ptr3);
                        }
                    }
                }
            }
        }

        public static bool IsResourceAddress(string address)
        {
            if ((address == null) || (address.Length == 0))
            {
                return false;
            }
            if (((string.Compare(address, 0, "asmres://", 0, 9, true, CultureInfo.InvariantCulture) != 0) && (string.Compare(address, 0, "licres://", 0, 9, true, CultureInfo.InvariantCulture) != 0)) && (string.Compare(address, 0, "html://", 0, 7, true, CultureInfo.InvariantCulture) != 0))
            {
                return false;
            }
            return true;
        }

        public static bool IsUriResource(string resource)
        {
            if ((resource == null) || (resource.Length == 0))
            {
                return false;
            }
            if ((((string.Compare(resource, 0, Uri.UriSchemeHttp, 0, Uri.UriSchemeHttp.Length, true, CultureInfo.InvariantCulture) != 0) && (string.Compare(resource, 0, Uri.UriSchemeHttps, 0, Uri.UriSchemeHttps.Length, true, CultureInfo.InvariantCulture) != 0)) && ((string.Compare(resource, 0, Uri.UriSchemeFtp, 0, Uri.UriSchemeFtp.Length, true, CultureInfo.InvariantCulture) != 0) && (string.Compare(resource, 0, Uri.UriSchemeFile, 0, Uri.UriSchemeFtp.Length, true, CultureInfo.InvariantCulture) != 0))) && !IsResourceAddress(resource))
            {
                return false;
            }
            return true;
        }


        public static string MakeEnumList(object value, string separator)
        {
            if (!(value is System.Enum))
            {
                throw new InvalidCastException("Must be enum.");
            }
            if (separator == null)
            {
                separator = ", ";
            }
            int num = 1;
            int num2 = (int) value;
            System.Type enumType = value.GetType();
            if (num2 == 0)
            {
                return System.Enum.GetName(enumType, value);
            }
            StringBuilder builder = new StringBuilder();
            while (num > 0)
            {
                int num3 = num & num2;
                if (num3 != 0)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(separator);
                    }
                    builder.Append(System.Enum.GetName(enumType, num3));
                }
                num = num << 1;
            }
            return builder.ToString();
        }

        public static string MakeSystemInfoString()
        {
            StringBuilder builder = new StringBuilder(0x100);
            try
            {
                builder.Append(Class37.smethod_0("M_Timestamp", new object[0]));
                builder.Append(": ");
                builder.Append(FormatSortableDate(DateTime.UtcNow));
                builder.Append(" / ");
                builder.Append(FormatSortableDate(DateTime.Now));
                builder.Append(Environment.NewLine);
                Assembly entryAssembly = Assembly.GetEntryAssembly();
                builder.Append(Class37.smethod_0("M_EntryAssembly", new object[0]));
                builder.Append(": ");
                try
                {
                    builder.Append((entryAssembly == null) ? "N/A" : entryAssembly.FullName);
                }
                catch (Exception exception)
                {
                    builder.Append(exception.Message);
                }
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_BaseDirectory", new object[0]));
                builder.Append(": ");
                builder.Append(AppDomain.CurrentDomain.BaseDirectory);
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_Platform", new object[0]));
                builder.Append(": ");
                builder.Append(OSRecord.ThisMachine.ToString());
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_OSVersion", new object[0]));
                builder.Append(": ");
                builder.Append(Environment.OSVersion.Version);
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_CLRVersion", new object[0]));
                builder.Append(": ");
                builder.Append(Environment.Version);
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_ProcessBitness", new object[0]));
                builder.Append(": ");
                builder.Append(Class21.bool_0 ? "64-bit" : "32-bit");
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_Culture", new object[0]));
                builder.Append(": ");
                builder.Append(CultureInfo.CurrentCulture);
                builder.Append(" / ");
                builder.Append(CultureInfo.CurrentUICulture);
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_Encoding", new object[0]));
                builder.Append(": ");
                builder.Append(Encoding.Default.EncodingName);
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_IISAvailable", new object[0]));
                builder.Append(": ");
                builder.Append(IisIsAvailable);
                builder.Append(Environment.NewLine);
                builder.Append(Class37.smethod_0("M_MachineCode", new object[0]));
                builder.Append(": ");
                builder.Append(MachineProfile.Profile.Hash);
            }
            catch (Exception exception2)
            {
                builder.Append(exception2.Message);
            }
            return builder.ToString();
        }

        public static WebProxy MakeWebProxy(string address, string username, string password, string domain)
        {
            if ((address == null) || (address.Length == 0))
            {
                throw new ArgumentNullException("address");
            }
            CredentialCache credentials = new CredentialCache();
            NetworkCredential cred = new NetworkCredential(username, password, domain);
            if (((string.Compare(address, 0, "http://", 0, 7, true) != 0) && (string.Compare(address, 0, "https://", 0, 7, true) != 0)) && (address.IndexOf("://") == -1))
            {
                address = "http://" + address;
            }
            Uri uriPrefix = new Uri(address);
            credentials.Add(uriPrefix, "Basic", cred);
            credentials.Add(uriPrefix, "NTLM", cred);
            credentials.Add(uriPrefix, "Digest", cred);
            credentials.Add(uriPrefix, "Kerberos", cred);
            return new WebProxy(address, true, new string[0], credentials);
        }



        public static CultureInfo SelectCulture(CultureInfo culture)
        {
            //DeployLX.Licensing.v4.Check.NotNull(culture, "culture");
            if (Thread.CurrentThread.CurrentUICulture == culture)
            {
                return culture;
            }
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
            if (culture.IsNeutralCulture)
            {
                foreach (CultureInfo info2 in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    if (info2.Name.StartsWith(culture.Name))
                    {
                        culture = info2;
                        break;
                    }
                }
                if (culture.IsNeutralCulture)
                {
                    return currentUICulture;
                }
            }
            Thread.CurrentThread.CurrentUICulture = culture;
            return currentUICulture;
        }

 
        private static void smethod_4(Control control_0, ArrayList arrayList_0)
        {
            if (!arrayList_0.Contains(control_0))
            {
                if ((bool) methodInfo_1.Invoke(control_0, new object[] { controlStyles_0 }))
                {
                    arrayList_0.Add(control_0);
                    methodInfo_0.Invoke(control_0, new object[] { controlStyles_0, false });
                }
                if (control_0.HasChildren)
                {
                    foreach (Control control in control_0.Controls)
                    {
                        smethod_4(control, arrayList_0);
                    }
                }
            }
        }

        [CompilerGenerated]
        private static void smethod_5()
        {
            try
            {
                Class21.LoadLibraryExW("NTMARTA.DLL", IntPtr.Zero, 0);
                Marshal.GetLastWin32Error();
            }
            catch
            {
            }
        }

        public static void SplitUserName(string winUsername, out string username, out string domain)
        {
            //DeployLX.Licensing.v4.Check.NotNull(winUsername, "winUsername");
            username = null;
            domain = null;
            int index = winUsername.IndexOf('\\');
            if (index > -1)
            {
                domain = winUsername.Substring(0, index);
                username = winUsername.Substring(index + 1);
            }
            else
            {
                index = winUsername.IndexOf('@');
                if (index > -1)
                {
                    username = winUsername.Substring(0, index);
                    domain = winUsername.Substring(index + 1);
                }
                else
                {
                    username = winUsername;
                }
            }
        }

        public static IDisposable ThreadBoost(ThreadPriority priority)
        {
            return new Class39(priority);
        }

        public static string XmlDecode(string value)
        {
            if ((value != null) && (value.Length != 0))
            {
                //return HttpUtility.HtmlDecode(value);
            }
            return value;
        }

        public static string XmlEncode(string value)
        {
            if ((value != null) && (value.Length != 0))
            {
                //return WebUtility.HtmlEncode(value);
            }
            return value;
        }

        public static bool IisIsAvailable
        {
            get
            {
                return (int_2 == 1);
            }
        }

        public static bool IsFipsEnabled
        {
            get
            {
                if (int_4 == 0)
                {
                    try
                    {
                        new RijndaelManaged();
                        int_4 = -1;
                    }
                    catch (InvalidOperationException)
                    {
                        int_4 = 1;
                    }
                }
                return (int_4 == 1);
            }
        }

        public static bool IsServiceRequest
        {
            get
            {
                if (int_1 == -1)
                {
                    int_1 = (Environment.UserInteractive) ? 0 : 1;
                }
                return (int_1 == 1);
            }
        }

        public static bool IsTerminalServices
        {
            get
            {
                if (int_3 == -1)
                {
                    //lock (SecureLicenseManager.SyncRoot)
                    //{
                        if (int_3 == -1)
                        {
                            if ((Environment.OSVersion.Platform & PlatformID.WinCE) != PlatformID.Win32S)
                            {
                                int_3 = (Class21.GetSystemMetrics(0x1000) != 0) ? 1 : 0;
                            }
                            else
                            {
                                int_3 = 0;
                            }
                        }
                    
                }
                return (int_3 == 1);
            }
        }



        public static bool ShouldUseWebLogic
        {
            get
            {
                if (int_0 == 0)
                {
                    try
                    {

                            int_0 = 1;

                    }
                    catch
                    {
                    }
                }
                return (int_0 == 1);
            }
        }

        private sealed class Class39 : IDisposable
        {
            /* private scope */ ThreadPriority threadPriority_0 = Thread.CurrentThread.Priority;

            public Class39(ThreadPriority priority)
            {
                Thread.CurrentThread.Priority = priority;
            }

            public void Dispose()
            {
                Thread.CurrentThread.Priority = this.threadPriority_0;
            }
        }

        private delegate Bitmap Delegate13(Control ctrl);
    }
}

