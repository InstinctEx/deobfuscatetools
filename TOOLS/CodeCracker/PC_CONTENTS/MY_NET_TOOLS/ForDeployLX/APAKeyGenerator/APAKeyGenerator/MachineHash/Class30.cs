namespace DeployLX.Licensing.v4
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Windows.Forms;

    internal sealed class Class30
    {
        /* private scope */ static readonly byte[] byte_0;
        /* private scope */ static readonly int[] int_0 = new int[] { 
            0, 0xc0c1, 0xc181, 320, 0xc301, 960, 640, 0xc241, 0xc601, 0x6c0, 0x780, 0xc741, 0x500, 0xc5c1, 0xc481, 0x440, 
            0xcc01, 0xcc0, 0xd80, 0xcd41, 0xf00, 0xcfc1, 0xce81, 0xe40, 0xa00, 0xcac1, 0xcb81, 0xb40, 0xc901, 0x9c0, 0x880, 0xc841, 
            0xd801, 0x18c0, 0x1980, 0xd941, 0x1b00, 0xdbc1, 0xda81, 0x1a40, 0x1e00, 0xdec1, 0xdf81, 0x1f40, 0xdd01, 0x1dc0, 0x1c80, 0xdc41, 
            0x1400, 0xd4c1, 0xd581, 0x1540, 0xd701, 0x17c0, 0x1680, 0xd641, 0xd201, 0x12c0, 0x1380, 0xd341, 0x1100, 0xd1c1, 0xd081, 0x1040, 
            0xf001, 0x30c0, 0x3180, 0xf141, 0x3300, 0xf3c1, 0xf281, 0x3240, 0x3600, 0xf6c1, 0xf781, 0x3740, 0xf501, 0x35c0, 0x3480, 0xf441, 
            0x3c00, 0xfcc1, 0xfd81, 0x3d40, 0xff01, 0x3fc0, 0x3e80, 0xfe41, 0xfa01, 0x3ac0, 0x3b80, 0xfb41, 0x3900, 0xf9c1, 0xf881, 0x3840, 
            0x2800, 0xe8c1, 0xe981, 0x2940, 0xeb01, 0x2bc0, 0x2a80, 0xea41, 0xee01, 0x2ec0, 0x2f80, 0xef41, 0x2d00, 0xedc1, 0xec81, 0x2c40, 
            0xe401, 0x24c0, 0x2580, 0xe541, 0x2700, 0xe7c1, 0xe681, 0x2640, 0x2200, 0xe2c1, 0xe381, 0x2340, 0xe101, 0x21c0, 0x2080, 0xe041, 
            0xa001, 0x60c0, 0x6180, 0xa141, 0x6300, 0xa3c1, 0xa281, 0x6240, 0x6600, 0xa6c1, 0xa781, 0x6740, 0xa501, 0x65c0, 0x6480, 0xa441, 
            0x6c00, 0xacc1, 0xad81, 0x6d40, 0xaf01, 0x6fc0, 0x6e80, 0xae41, 0xaa01, 0x6ac0, 0x6b80, 0xab41, 0x6900, 0xa9c1, 0xa881, 0x6840, 
            0x7800, 0xb8c1, 0xb981, 0x7940, 0xbb01, 0x7bc0, 0x7a80, 0xba41, 0xbe01, 0x7ec0, 0x7f80, 0xbf41, 0x7d00, 0xbdc1, 0xbc81, 0x7c40, 
            0xb401, 0x74c0, 0x7580, 0xb541, 0x7700, 0xb7c1, 0xb681, 0x7640, 0x7200, 0xb2c1, 0xb381, 0x7340, 0xb101, 0x71c0, 0x7080, 0xb041, 
            0x5000, 0x90c1, 0x9181, 0x5140, 0x9301, 0x53c0, 0x5280, 0x9241, 0x9601, 0x56c0, 0x5780, 0x9741, 0x5500, 0x95c1, 0x9481, 0x5440, 
            0x9c01, 0x5cc0, 0x5d80, 0x9d41, 0x5f00, 0x9fc1, 0x9e81, 0x5e40, 0x5a00, 0x9ac1, 0x9b81, 0x5b40, 0x9901, 0x59c0, 0x5880, 0x9841, 
            0x8801, 0x48c0, 0x4980, 0x8941, 0x4b00, 0x8bc1, 0x8a81, 0x4a40, 0x4e00, 0x8ec1, 0x8f81, 0x4f40, 0x8d01, 0x4dc0, 0x4c80, 0x8c41, 
            0x4400, 0x84c1, 0x8581, 0x4540, 0x8701, 0x47c0, 0x4680, 0x8641, 0x8201, 0x42c0, 0x4380, 0x8341, 0x4100, 0x81c1, 0x8081, 0x4040
         };
        /* private scope */ const string string_0 = "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5";
        /* private scope */ const string string_1 = "012345689ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^*()_+-=[]{}|;:,.?/`~";
        /* private scope */ const string string_2 = "7$,lsj*0mkyL._JV3b{Y;^HO~nSK8W@?[w`9F%RP(!qiC52DA&/4v:p)ZcU-6T|Med\x00a7GN=g'hoE}+]zQBft\x00b6ax#rI1X";
        /* private scope */ const string string_3 = "0123456789ABCDEF";

        static Class30()
        {
            byte[] buffer = new byte[3];
            buffer[0] = 1;
            buffer[2] = 1;
            byte_0 = buffer;
        }

        private Class30()
        {
        }

        public static string smethod_0(byte[] byte_1, string string_4, int int_1, int int_2, int int_3, bool bool_0)
        {
            if (byte_1 == null)
            {
                return null;
            }
            if (string_4 == null)
            {
                string_4 = "012345689ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^*()_+-=[]{}|;:,.?/`~";
            }
            StringBuilder builder = new StringBuilder(byte_1.Length);
            byte[] dst = new byte[int_3];
            Buffer.BlockCopy(byte_1, int_2, dst, 0, int_3);
            if (int_1 < 0)
            {
                int_1 = string_4.Length;
            }
            int num = 0;
            int index = 0;
            while (true)
            {
                int num3 = 0;
                num = 0;
                for (int i = index; i < int_3; i++)
                {
                    num3 = num3 << 8;
                    num3 |= dst[i];
                    dst[i] = (byte) (num3 / int_1);
                    num3 = num3 % int_1;
                    num |= dst[i];
                }
                if (dst[index] == 0)
                {
                    index++;
                }
                builder.Append(string_4[num3]);
                if (num <= 0)
                {
                    if (bool_0)
                    {
                        int num5 = smethod_6(dst.Length, string_4, int_1);
                        while (builder.Length < num5)
                        {
                            builder.Append(string_4[0]);
                        }
                    }
                    char[] array = builder.ToString().ToCharArray();
                    Array.Reverse(array);
                    return new string(array);
                }
            }
        }

        public static string smethod_1(byte[] byte_1, string string_4, int int_1)
        {
            if (byte_1 == null)
            {
                return null;
            }
            return smethod_0(byte_1, string_4, int_1, 0, byte_1.Length, false);
        }

        public static int smethod_10(string string_4)
        {
            uint num = 0x1505;
            int length = string_4.Length;
            for (int i = 0; i < length; i++)
            {
                num = ((num << 5) + num) ^ string_4[i];
            }
            return (int) num;
        }

        public static int smethod_11(string string_4)
        {
            return smethod_13(Encoding.UTF8.GetBytes((string_4 == null) ? "" : string_4));
        }

        public static int smethod_12(byte[] byte_1, int int_1, int int_2)
        {
            //DeployLX.Licensing.v4.Check.NotNull(byte_1, "data");
            if (int_1 > byte_1.Length)
            {
                throw new ArgumentOutOfRangeException("offset", int_1, null);
            }
            if ((int_1 + int_2) > byte_1.Length)
            {
                throw new ArgumentOutOfRangeException("length", int_2, null);
            }
            int num = 0;
            for (int i = int_1; i < (int_1 + int_2); i++)
            {
                num = (num >> 8) ^ int_0[(num & 0xff) ^ byte_1[i]];
            }
            return (num & 0xffff);
        }

        public static int smethod_13(byte[] byte_1)
        {
            //DeployLX.Licensing.v4.Check.NotNull(byte_1, "data");
            return smethod_12(byte_1, 0, byte_1.Length);
        }

 
        public static bool smethod_16(string string_4, bool bool_0)
        {
            if ((string_4 == null) || (string_4.Length == 0))
            {
                return true;
            }
            if (Regex.IsMatch(string_4, @"^(((((((http://)|(https://)|(ftp://)|(asmres://)|(licres://))((([a-zA-Z0-9\*\?][\-_a-zA-Z0-9\*\?]{0,25}\.)*[a-zA-Z0-9\*\?][\-_a-zA-Z0-9\*\?]{0,25}(\.[a-zA-Z0-9\*\?]{2,5})?)|((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])))(\:[0-9]{1,5})?(~?/([\.\-_a-zA-Z0-9~%={} ]*))*((/?[\.\-_a-zA-Z0-9~%\?&#={}]* ))?(\?.*)?))|(file://((([A-Za-z]:\\)|(\\\\[A-Za-z0-9]{0,16})\\)?(([A-Za-z0-9\.\-_\[\]\(\)\$ {}/]*)[\\/])*([A-Za-z0-9\.\-_\[\]\(\)\$ {}/]*)))))\|)*((((((http://)|(https://)|(ftp://)|(asmres://)|(licres://))((([a-zA-Z0-9\*\?][\-_a-zA-Z0-9\*\?]{0,25}\.)*[a-zA-Z0-9\*\?][\-_a-zA-Z0-9\*\?]{0,25}(\.[a-zA-Z0-9\*\?]{2,5})?)|((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])))(\:[0-9]{1,5})?(~?/([\.\-_a-zA-Z0-9~%={} ]*))*((/?[\.\-_a-zA-Z0-9~%\?&#={}]* ))?(\?.*)?))|(file://((([A-Za-z]:\\)|(\\\\[A-Za-z0-9]{0,16})\\)?(([A-Za-z0-9\.\-_\[\]\(\)\$ {}/]*)[\\/])*([A-Za-z0-9\.\-_\[\]\(\)\$ {}/]*)))))$", RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.Compiled))
            {
                return true;
            }
            if (bool_0)
            {
                throw new Exception("E_InvalidUrl");
            }
            return false;
        }

        public static void smethod_17(string string_4, bool bool_0)
        {
            new Class5(string_4, bool_0).method_0();
        }

        public static void smethod_18(string string_4, object object_0)
        {
            new Class6(string_4, object_0).method_0();
        }

        public static object smethod_19(string string_4)
        {
            //DeployLX.Licensing.v4.Check.NotNull(string_4, "format");
            Class7 class2 = new Class7(string_4);
            class2.method_1();
            return class2.object_0;
        }

        public static string smethod_2(byte[] byte_1, string string_4)
        {
            return smethod_1(byte_1, string_4, -1);
        }

        public static string smethod_20(string string_4)
        {
            StringBuilder builder = new StringBuilder(string_4.Length);
            foreach (char ch in string_4)
            {
                char ch2 = ch;
                if ((ch >= 'a') && (ch <= 'z'))
                {
                    ch2 = (char) (ch2 - 'a');
                    ch2 = (char) (ch2 + '\r');
                    ch2 = (char) (ch2 % '\x001a');
                    ch2 = (char) (ch2 + 'a');
                }
                else if ((ch >= 'A') && (ch <= 'Z'))
                {
                    ch2 = (char) (ch2 - 'A');
                    ch2 = (char) (ch2 + '\r');
                    ch2 = (char) (ch2 % '\x001a');
                    ch2 = (char) (ch2 + 'A');
                }
                builder.Append(ch2);
            }
            return builder.ToString();
        }

        public static object smethod_21(byte[] byte_1, Object secureLicenseContext_0)
        {
            RSAParameters parameters = new RSAParameters {
                Modulus = byte_1,
                Exponent = byte_0
            };
            CspParameters parameters2 = new CspParameters(1, "Microsoft Enhanced Cryptographic Provider v1.0", null);
            try
            {
                return smethod_22(ref parameters, parameters2, true, secureLicenseContext_0);
            }
            catch
            {
                parameters2.ProviderName = null;
                object obj2 = smethod_22(ref parameters, parameters2, false, secureLicenseContext_0);
                if (obj2 == null)
                {
                    parameters2.Flags = CspProviderFlags.UseMachineKeyStore;
                    parameters2.ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0";
                    obj2 = smethod_22(ref parameters, parameters2, false, secureLicenseContext_0);
                    if (obj2 != null)
                    {
                        return obj2;
                    }
                    parameters2.Flags = CspProviderFlags.UseMachineKeyStore;
                    parameters2.ProviderName = null;
                    obj2 = smethod_22(ref parameters, parameters2, false, secureLicenseContext_0);
                    if (obj2 != null)
                    {
                        return obj2;
                    }
                    parameters2.Flags = CspProviderFlags.NoFlags;
                    parameters2.KeyContainerName = "DLX_v3";
                    parameters2.ProviderName = null;
                    obj2 = smethod_22(ref parameters, parameters2, false, secureLicenseContext_0);
                    if (obj2 != null)
                    {
                        return obj2;
                    }
                    parameters2.Flags = CspProviderFlags.UseMachineKeyStore;
                    parameters2.KeyContainerName = "DLX_v3";
                    obj2 = smethod_22(ref parameters, parameters2, false, secureLicenseContext_0);
                    if (obj2 == null)
                    {
                        throw new Exception("E_RSADenied");
                    }
                }
                return obj2;
            }
        }

        private static object smethod_22(ref RSAParameters rsaparameters_0, CspParameters cspParameters_0, bool bool_0, Object secureLicenseContext_0)
        {
            try
            {
                RSACryptoServiceProvider provider;
                provider = provider = new RSACryptoServiceProvider(0x180, cspParameters_0);
                try
                {
                    provider.PersistKeyInCsp = false;
                }
                catch
                {
                }
                provider.ImportParameters(rsaparameters_0);
                return provider;
            }
            catch (Exception exception)
            {
            	MessageBox.Show(exception.ToString());
                if (bool_0)
                {
                    throw;
                }
            }
            return null;
        }

        public static string smethod_3(byte[] byte_1)
        {
            return smethod_1(byte_1, null, -1);
        }

        public static byte[] smethod_4(string string_4, string string_5, int int_1)
        {
            if (string_4 == null)
            {
                return null;
            }
            if (string_5 == null)
            {
                string_5 = "012345689ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^*()_+-=[]{}|;:,.?/`~";
            }
            if (int_1 < 0)
            {
                int_1 = string_5.Length;
            }
            int[] numArray = new int[0x100];
            for (int i = 0; i < int_1; i++)
            {
                numArray[string_5[i]] = i;
            }
            byte[] src = new byte[string_4.Length];
            for (int j = 0; j < string_4.Length; j++)
            {
                int num3 = numArray[string_4[j]];
                int num4 = 0;
                for (int k = src.Length - 1; k >= 0; k--)
                {
                    num4 += src[k] * int_1;
                    src[k] = (byte) num4;
                    num4 = num4 >> 8;
                }
                num4 = num3;
                for (int m = src.Length - 1; m >= 0; m--)
                {
                    num4 += src[m];
                    src[m] = (byte) num4;
                    num4 = num4 >> 8;
                }
            }
            double num7 = Math.Floor((double) (string_4.Length * Math.Log10((double) int_1))) / Math.Log10(2.0);
            int num8 = (int) Math.Round((double) (num7 / 8.0));
            while ((src.Length - num8) > 0)
            {
                if (src[(src.Length - num8) - 1] == 0)
                {
                    break;
                }
                num8++;
            }
            byte[] dst = new byte[num8];
            Buffer.BlockCopy(src, src.Length - num8, dst, 0, dst.Length);
            return dst;
        }

        public static byte[] smethod_5(string string_4, string string_5)
        {
            return smethod_4(string_4, string_5, -1);
        }

        public static int smethod_6(int int_1, string string_4, int int_2)
        {
            return smethod_7(int_1 * 8, string_4, int_2);
        }

        public static int smethod_7(int int_1, string string_4, int int_2)
        {
            if (int_2 < 0)
            {
                //DeployLX.Licensing.v4.Check.NotNull(string_4, "characterSet");
                int_2 = string_4.Length;
            }
            return (int) Math.Ceiling((double) ((int_1 * Math.Log10(2.0)) / Math.Log10((double) int_2)));
        }

        internal static byte[] smethod_8(byte[] byte_1, int int_1, int int_2)
        {
            int num;
            byte[] dst = new byte[byte_1.Length];
            if (int_2 == 0x7fffffff)
            {
                num = int_2;
            }
            else
            {
                num = int_1 + int_2;
            }
            if (num < 0)
            {
                num = 0x7fffffff;
            }
            if (int_1 > 0)
            {
                Buffer.BlockCopy(byte_1, 0, dst, 0, int_1);
            }
            int index = int_1;
            while (index < num)
            {
                if ((index + 4) > dst.Length)
                {
                    break;
                }
                dst[index] = (byte) ((byte_1[index + 1] >> 4) | (byte_1[index + 3] << 4));
                dst[index + 1] = (byte) ((byte_1[index + 2] >> 4) | (byte_1[index] << 4));
                dst[index + 2] = (byte) ((byte_1[index + 3] >> 4) | (byte_1[index + 1] << 4));
                dst[index + 3] = (byte) ((byte_1[index] >> 4) | (byte_1[index + 2] << 4));
                index += 4;
            }
            if (index < byte_1.Length)
            {
                Buffer.BlockCopy(byte_1, index, dst, index, byte_1.Length - index);
            }
            return dst;
        }

        internal static byte[] smethod_9(byte[] byte_1)
        {
            return smethod_8(byte_1, 0, byte_1.Length);
        }

        private class Class5 : Class4
        {
            /* private scope */ bool bool_1;
            /* private scope */ string string_0;

            public Class5(string url, bool newWindow)
            {
                this.string_0 = url;
                this.bool_1 = newWindow;
            }

            protected override void vmethod_0()
            {
                try
                {
                    string str = this.string_0.ToLower(CultureInfo.InvariantCulture);
                    if (this.bool_1 && !str.StartsWith(Uri.UriSchemeMailto))
                    {
                        using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false))
                        {
                            if (key != null)
                            {
                                string fileName = key.GetValue(null) as string;
                                if (fileName != null)
                                {
                                    if (fileName.IndexOf("%1") > -1)
                                    {
                                        fileName = fileName.Replace("%1", this.string_0);
                                    }
                                    else
                                    {
                                        fileName = fileName + " " + this.string_0;
                                    }
                                    string arguments = null;
                                    if (fileName.StartsWith("\""))
                                    {
                                        int index = fileName.IndexOf('"', 1);
                                        if (index > -1)
                                        {
                                            arguments = fileName.Substring(index + 1).Trim();
                                            fileName = fileName.Substring(1, index - 1);
                                        }
                                    }
                                    else
                                    {
                                        int length = fileName.IndexOf(' ');
                                        if (length > -1)
                                        {
                                            arguments = fileName.Substring(length + 1);
                                            fileName = fileName.Substring(0, length);
                                        }
                                    }
                                    Process.Start(fileName, arguments);
                                    return;
                                }
                            }
                        }
                    }
                    Process.Start(this.string_0);
                }
                catch (Exception)
                {
                    Process.Start(this.string_0);
                }
            }
        }

        private class Class6 : Class4
        {
            /* private scope */ object object_0;
            /* private scope */ string string_0;

            public Class6(string format, object data)
            {
                this.string_0 = format;
                this.object_0 = data;
            }

            protected override void vmethod_0()
            {
                IDataObject data = new DataObject(this.string_0, this.object_0);
                Clipboard.SetDataObject(data, true);
            }
        }

        private class Class7 : Class4
        {
            /* private scope */ public object object_0;
            /* private scope */ string string_0;

            public Class7(string format)
            {
                this.string_0 = format;
            }

            protected override void vmethod_0()
            {
                IDataObject dataObject = Clipboard.GetDataObject();
                if (dataObject != null)
                {
                    this.object_0 = dataObject.GetData(this.string_0, true);
                }
            }
        }
    }
}

