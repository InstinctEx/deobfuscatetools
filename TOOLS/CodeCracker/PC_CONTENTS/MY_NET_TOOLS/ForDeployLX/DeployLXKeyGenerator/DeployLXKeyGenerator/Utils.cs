/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 05.07.2014
 * Time: 19:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using Microsoft.Win32;
using System.Globalization;

namespace DeployLXKeyGenerator
{
	/// <summary>
	/// Description of Class11.
	/// </summary>
	public class Utils
	{
static readonly int[] _crctable;
internal const string DefaultRadix = "012345689ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^*()_+-=[]{}|;:,.?/`~";

		public Utils()
		{
		}
		
		static Utils()
		{
		_crctable = new int[] { 
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
      }

		public static RegistryKey OpenRegistryPath(string path, bool writable, bool createIfDoesntExist)
        {
            RegistryKey key2;
            
            string[] strArray = path.Split(new char[] { '\\' });
            RegistryKey localMachine;
            if (strArray.Length != 0)
            {
                if (strArray.Length == 1)
                {
                    localMachine = Registry.LocalMachine;
                    goto Label_00FE;
                }
                switch (strArray[0].ToUpper(CultureInfo.InvariantCulture))
                {
                    case "HKLM":
                    case "HKEY_LOCAL_MACHINE":
                        localMachine = Registry.LocalMachine;
                        goto Label_00FE;

                    case "HKCU":
                    case "HKEY_CURRENT_USER":
                        localMachine = Registry.CurrentUser;
                        goto Label_00FE;

                    case "HKCR":
                    case "HKEY_CLASSES_ROOT":
                        localMachine = Registry.ClassesRoot;
                        goto Label_00FE;
                }
            }
            return null;
        Label_00FE:
            key2 = localMachine;
            RegistryKey key3 = localMachine;
            RegistryKey key4 = null;
            RegistryKey key5 = null;
            try
            {
                int index = strArray.Length - 1;
                while (((strArray[index].Length == 0) || (strArray[index][0] == '@')) && (index > 0))
                {
                    index--;
                }
                if (index <= 0)
                {
                    return null;
                }
                for (int i = 1; i <= index; i++)
                {
                    if (i == index)
                    {
                        key5 = key2.OpenSubKey(strArray[i], writable);
                        if (key5 == null)
                        {
                            if (!createIfDoesntExist)
                            {
                                return null;
                            }
                            key2.Close();
                            key2 = key3.OpenSubKey(strArray[i - 1], true);
                            if (key2 == null)
                            {
                                return null;
                            }
                            key5 = key2.CreateSubKey(strArray[i]);
                            key2.Close();
                        }
                    }
                    else
                    {
                        key4 = key2.OpenSubKey(strArray[i], false);
                        if (key4 == null)
                        {
                            if (!createIfDoesntExist)
                            {
                                return null;
                            }
                            key2.Close();
                            key2 = key3.OpenSubKey(strArray[i - 1], true);
                            if (key2 == null)
                            {
                                return null;
                            }
                            key4 = key2.CreateSubKey(strArray[i]);
                        }
                        if (key3 != localMachine)
                        {
                            key3.Close();
                        }
                        key3 = key2;
                        key2 = key4;
                    }
                }
            }
            finally
            {
                if (((key2 != localMachine) && (key2 != null)) && (key2 != key5))
                {
                    key2.Close();
                }
                if (((key4 != localMachine) && (key4 != null)) && (key4 != key5))
                {
                    key4.Close();
                }
                if (((key3 != localMachine) && (key3 != null)) && (key3 != key5))
                {
                    key3.Close();
                }
            }
            return key5;
        }

        public static int GetShortHashCode(string s)
        {
            return Crc16(Encoding.UTF8.GetBytes(s ?? ""));
        }
  
        public static int Crc16(byte[] data)
        {
            return Crc16(data, 0, data.Length);
        }

 
        public static int Crc16(byte[] data, int offset, int length)
        {
            int num1 = 0;
            for (int num2 = offset; num2 < (offset + length); num2++)
            {
                num1 = (num1 >> 8) ^ _crctable[(num1 & 0xff) ^ data[num2]];
            }
            return (num1 & 0xffff);
        }

        public static string ByteToString(byte[] data, string characterSet, int radix)
        {
            return ByteToString(data, characterSet, radix, 0, data.Length, false);
        }

        public static string ByteToString(byte[] data, string characterSet, int radix, int offset, int count, bool padToLongest)
        {
            if (data == null)
            {
                return null;
            }
            if (characterSet == null)
            {
                characterSet = DefaultRadix;
            }
            StringBuilder builder1 = new StringBuilder(data.Length);
            byte[] buffer1 = new byte[count];
            Buffer.BlockCopy(data, offset, buffer1, 0, count);
            if (radix < 0)
            {
                radix = characterSet.Length;
            }
            int num1;
            int num2 = 0;
            do
            {
                int num3 = 0;
                num1 = 0;
                for (int num4 = num2; num4 < count; num4++)
                {
                    num3 = num3 << 8;
                    num3 |= buffer1[num4];
                    buffer1[num4] = (byte)(num3 / radix);
                    num3 = num3 % radix;
                    num1 |= buffer1[num4];
                }
                if (buffer1[num2] == 0)
                {
                    num2++;
                }
                builder1.Append(characterSet[num3]);
            }
            while (num1 > 0);
            if (padToLongest)
            {
                int num5 = CalculateLongestStringForByte(buffer1.Length, characterSet, radix);
                while (builder1.Length < num5)
                {
                    builder1.Append(characterSet[0]);
                }
            }
            char[] chArray1 = builder1.ToString().ToCharArray();
            Array.Reverse(chArray1);
            return new string(chArray1);
        }
        
        
 public static byte[] StringToByte(string input, string charset)
{
    return StringToByte(input, charset, -1);
}

 public static byte[] StringToByte(string input, string charset, int int_1)
{
    if (input == null)
    {
        return null;
    }
    if (charset == null)
    {
        charset = "012345689ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^*()_+-=[]{}|;:,.?/`~";
    }
    if (int_1 < 0)
    {
        int_1 = charset.Length;
    }
    int[] numArray = new int[0x100];
    for (int i = 0; i < int_1; i++)
    {
        numArray[charset[i]] = i;
    }
    byte[] src = new byte[input.Length];
    for (int j = 0; j < input.Length; j++)
    {
        int num3 = numArray[input[j]];
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
    double num7 = Math.Floor((double) (input.Length * Math.Log10((double) int_1))) / Math.Log10(2.0);
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

 
        
        public static int CalculateLongestStringForByte(int dataLength, string characterSet, int radix)
        {
            return CalculateLongestStringForBit(dataLength * 8, characterSet, radix);
        }

        public static int CalculateLongestStringForBit(int msbPos, string characterSet, int radix)
        {
            if (radix < 0)
            {
                radix = characterSet.Length;
            }
            return (int)Math.Ceiling(((msbPos * Math.Log10(2)) / Math.Log10(radix)));
        }
                
             
        public static DateTime ModExpireDate(bool b)
        {
            DateTime time1 = DateTime.UtcNow.Date;
            if (!b)
            {
                return time1.AddTicks(0xc92a6998f0);
            }
            return time1;
        }

 

 


 

 


 

 

	}
}
