/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 05.07.2014
 * Time: 18:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Collections;
using System.Security.Cryptography;
using DeployLXLicensing;

namespace DeployLXKeyGenerator
{
	
	internal interface IMachineProfileEntryMaker
    {
        string[] GetHardwareHash(MachineProfileEntryType type);
    }
	    
public interface ILicenseCodeSupport
{
    // Methods
    byte[] MakeCode(byte[] data);
    byte[] ParseCode(byte[] code);

    // Properties
    string CharacterSet { get; }
}


	/// <summary>
	/// Description of LicenseKey.
	/// </summary>
	public class LicenseKeyGen
	{
		public LicenseKeyGen()
		{
		hashtable_0 = new Hashtable();
		}
		
		 private class SerialNumberAlgo : ILicenseCodeSupport
{
    // Fields
    /* private scope */ LicenseKeyGen licenseKey_0;

    // Methods
    public SerialNumberAlgo(LicenseKeyGen key)
    {
        this.licenseKey_0 = key;
    }

    public byte[] MakeCode(byte[] data)
    {
    	if (ReadLicenseKey.keySN==null||ReadLicenseKey.keySN.Length==0)
        return data;
    	   	
    	    byte[] buffer1 = new byte[2];
            RandomNumberGenerator.Create().GetBytes(buffer1);
            byte[] buffer2 = new byte[data.Length + 3];
            Array.Copy(data, 0, buffer2, 1, data.Length);
            int num1 = 0;
            for (int num2 = 0; num2 < 10; num2++)
            {
                if (num1 == buffer1.Length)
                {
                    num1 = 0;
                }
                for (int num3 = 0; num3 < data.Length; num3++)
                {
                    buffer2[1 + num3] = (byte)(buffer2[1 + num3] ^ buffer1[num1++]);
                    if (num1 == buffer1.Length)
                    {
                        num1 = 0;
                    }
                }
                if (((data.Length % buffer1.Length) == 0) && (num2 != 9))
                {
                    num1++;
                }
            }
            buffer2[0] = buffer1[1];
            buffer2[buffer2.Length - 2] = (byte)(num1 - 1);
            buffer2[buffer2.Length - 1] = buffer1[0];
            for (int num4 = 0; num4 < buffer2.Length; num4++)
            {
                buffer2[num4] = (byte)(buffer2[num4] ^ ReadLicenseKey.keySN[num4 % (ReadLicenseKey.keySN.Length - 1)]);
            }
            return buffer2;
    }

    public byte[] ParseCode(byte[] code)
    {
        return code;
    }

    // Properties
    public string CharacterSet
    {
        get
        {
            return null;
        }
    }
}
		 
		 private class ActivationCodeAlgo : ILicenseCodeSupport
{
    // Fields
    /* private scope */ LicenseKeyGen licenseKey_0;

    // Methods
    public ActivationCodeAlgo(LicenseKeyGen key)
    {
        this.licenseKey_0 = key;
    }

    public byte[] MakeCode(byte[] data)
    {
        if (ReadLicenseKey.keyA==null||ReadLicenseKey.keyA.Length==0)
        return data;
        
            using (Rijndael rijndael1 = new RijndaelManaged())
            {
                rijndael1.Key = ReadLicenseKey.keyA;
                rijndael1.IV = new byte[0x10];
                byte[] buffer1 = rijndael1.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
                rijndael1.IV = new byte[0x10];
                rijndael1.CreateDecryptor().TransformFinalBlock(buffer1, 0, buffer1.Length);
                return buffer1;
            }

    }

    public byte[] ParseCode(byte[] code)
    {
        return code;
    }

    // Properties
    public string CharacterSet
    {
        get
        {
            return null;
        }
    }
}

private class SimpleAlgo : ILicenseCodeSupport
{
    // Fields
    /* private scope */ LicenseKeyGen licenseKey_0;

    // Methods
    public SimpleAlgo(LicenseKeyGen key)
    {
        this.licenseKey_0 = key;
    }

    public byte[] MakeCode(byte[] data)
    {
        return data;
    }

    public byte[] ParseCode(byte[] code)
    {
        return code;
    }

    // Properties
    public string CharacterSet
    {
        get
        {
            return "0123456789";
        }
    }
}

private class BasicAlgo : ILicenseCodeSupport
{
    // Fields
    /* private scope */ LicenseKeyGen licenseKey_0;

    // Methods
    public BasicAlgo(LicenseKeyGen key)
    {
        this.licenseKey_0 = key;
    }

    public byte[] MakeCode(byte[] data)
    {
        return data;
    }

    public byte[] ParseCode(byte[] code)
    {
        return this.MakeCode(code);
    }

    // Properties
    public string CharacterSet
    {
        get
        {
            return null;
        }
    }
}

private class AdvancedAlgo : ILicenseCodeSupport
{
    // Fields
    /* private scope */ LicenseKeyGen licenseKey_0;

    // Methods
    public AdvancedAlgo(LicenseKeyGen key)
    {
        this.licenseKey_0 = key;
    }

    public byte[] MakeCode(byte[] data)
    {
        return data;
    }

    public byte[] ParseCode(byte[] code)
    {
        return code;
    }

    // Properties
    public string CharacterSet
    {
        get
        {
            return null;
        }
    }
}


 

public string MakeSerialNumber(string prefix, int seed, DeployLXLicensing.SerialNumberFlags flags, int extendLimitOrdinal1, int extendLimitValue1, int extendLimitOrdinal2, int extendLimitValue2, int[] groupSizes, string characterSet, DeployLXLicensing.CodeAlgorithm algorithm)
{
    if ((extendLimitOrdinal2 != -1) && (extendLimitOrdinal1 == -1))
    {
        throw new Exception("E_FirstIndexMustBeUsedBeforeSecond");
    }
    if (extendLimitOrdinal1 > 0x1f)
    {
        throw new Exception("extendLimitOrdinal1 out of range!");
    }
    if (extendLimitOrdinal2 > 0x1f)
    {
        throw new Exception("extendLimitOrdinal2 out of range!");
    }
    if (extendLimitValue1 > 0x7ffffff)
    {
        throw new Exception("extendLimitValue1 out of range!");
    }
    if (extendLimitValue2 > 0x7ffffff)
    {
        throw new Exception("extendLimitValue2 out of range!");
    }
    if (algorithm == DeployLXLicensing.CodeAlgorithm.NotSet)
    {
        algorithm = DeployLXLicensing.CodeAlgorithm.SerialNumber;
    }
    if (seed > 0xffffff)
    {
        throw new Exception("E_MaxSeed out of range!");
    }
    if ((extendLimitOrdinal1 != -1) && (extendLimitOrdinal2 == -1))
    {
        extendLimitOrdinal2 = 0;
        extendLimitValue2 = 0;
    }
    byte[] destinationArray = new byte[(1 + ((extendLimitOrdinal1 != -1) ? 4 : 0)) + ((extendLimitOrdinal2 != -1) ? 4 : 0)];
    destinationArray[0] = (byte) flags;
    if (extendLimitOrdinal1 != -1)
    {
        Array.Copy(BitConverter.GetBytes(extendLimitValue1), 0, destinationArray, 1, 4);
        destinationArray[4] = (byte) (destinationArray[4] | ((byte) (extendLimitOrdinal1 << 3)));
    }
    if (extendLimitOrdinal2 != -1)
    {
        Array.Copy(BitConverter.GetBytes(extendLimitValue2), 0, destinationArray, 5, 4);
        destinationArray[8] = (byte) (destinationArray[8] | ((byte) (extendLimitOrdinal2 << 3)));
    }
    return this.MakeSerialNumber(prefix, seed, destinationArray, groupSizes, characterSet, algorithm);
}

public string MakeSerialNumber(string prefix, int seed, byte[] data, int[] groupSizes, string characterSet, DeployLXLicensing.CodeAlgorithm algorithm)
{
    if (algorithm == DeployLXLicensing.CodeAlgorithm.NotSet)
    {
        algorithm = DeployLXLicensing.CodeAlgorithm.SerialNumber;
    }
    if (seed > 0xffffff)
    {
        throw new Exception("E_MaxSeed out of range!");
    }
    byte[] destinationArray = (data == null) ? new byte[4] : new byte[4 + data.Length];
    Array.Copy(BitConverter.GetBytes(seed), destinationArray, 4);
    if (data != null)
    {
        Array.Copy(data, 0, destinationArray, 4, data.Length);
    }
    destinationArray[3] = (byte) Utils.Crc16(destinationArray, 0, 3);
    return this.GenerateInternal(prefix, null, destinationArray, groupSizes, characterSet, algorithm);

}

public string MakeActivationCode(string prefix, string serialNumber, string hash, int refid, DateTime expires, string characterSet, DeployLXLicensing.CodeAlgorithm algorithm)
{
    if (algorithm == DeployLXLicensing.CodeAlgorithm.NotSet)
    {
        algorithm = DeployLXLicensing.CodeAlgorithm.ActivationCode;
    }
    if (hash==null)
    throw new Exception("hash is null");

    //Check.GreaterThan(refid, 0, "refid");
    //Check.LessThan(refid, 0x100, "refid");
    if (!DeployLXLicensing.MachineProfile.IsHashValid(hash))
    {
        throw new ArgumentException("Invalid hash.", "hash", null);
    }
    if (expires == DateTime.MinValue)
    {
        expires = Utils.ModExpireDate(false).AddDays(7.0);
    }
    int num = ((expires.Year - 0x7d0) | (expires.Month << 10)) | (expires.Day << 14);
    byte[] dst = new byte[10];
    hash = hash.ToUpper();
    Buffer.BlockCopy(BitConverter.GetBytes(Utils.Crc16(Encoding.UTF8.GetBytes(hash))), 0, dst, 0, 2);
    dst[2] = (byte) (dst[0] ^ (0xff - refid));
    dst[3] = (byte) (dst[1] ^ (0xff - refid));
    dst[4] = (byte) refid;
    Array.Copy(BitConverter.GetBytes(num), 0, dst, 5, 4);
    dst[dst.Length - 1] = (byte) Utils.Crc16(dst, 0, dst.Length - 2);
    return this.GenerateInternal(prefix, serialNumber, dst, null, characterSet, algorithm);
}
 


   private static void Xor(byte[] A, byte[] B)
        {
            int x = 0;
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = (byte)(A[i] ^ B[x++]);
                if (x == B.Length)
                {
                    x = 0;
                }
            }
        }

 private static int smethod_14(int int_0, int int_1, out int int_2, out int int_3)
{
    int_2 = int_0 / int_1;
    int_3 = int_0 % int_1;
    while (int_3 > int_2)
    {
        int_1--;
        int_2 = int_0 / int_1;
        int_3 = int_0 % int_1;
    }
    return int_1;
}

 

 


private string GenerateInternal(string prefix, string SerialNumber, byte[] Data, int[] GroupSizes, string CharacterSet, DeployLXLicensing.CodeAlgorithm codeAlgorithm)
{
    //this.method_6();
    //Check.NotNull(values, "values");
    ILicenseCodeSupport customCodeSupport = this.GetCustomCodeSupport(codeAlgorithm);
    if (customCodeSupport == null)
    {
        throw new Exception("E_UnknownAlgorithm");
    }
    if (CharacterSet == null)
    {
        CharacterSet = customCodeSupport.CharacterSet;
    }
    if (CharacterSet == null)
    {
        CharacterSet = "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5";
    }
    /*if (string_4.Length < DeployLXLicensing.CodeAlgorithm_0.)
    {
        throw new Exception("E_CharacterSetTooShort");
    }
    */
    if (CharacterSet.IndexOf('-') > -1)
    {
        throw new ArgumentException("E_CharacterSetContainsDash");
    }
    if (Data.Length > 0x7f)
    {
        throw new ArgumentException("E_MaximumDataExceeded");
    }
    if (SerialNumber != null)
    {
        SerialNumber = SerialNumber.ToUpper();
    }
    byte[] destinationArray = new byte[1 + Data.Length];
    Array.Copy(Data, destinationArray, Data.Length);
    byte num = (byte) Utils.Crc16(destinationArray, 0, destinationArray.Length - 1);
    destinationArray[destinationArray.Length - 1] = num;
    destinationArray = customCodeSupport.MakeCode(destinationArray);
    
    
    if (prefix != null)
    {
        prefix.Trim();
        if (prefix.Length == 0)
        {
            prefix = null;
        }
    }
    if (SerialNumber != null)
    {
        SerialNumber.Trim();
        if (SerialNumber.Length == 0)
        {
            SerialNumber = null;
        }
    }
    if (prefix != null)
    {
        Xor(destinationArray, Encoding.UTF8.GetBytes(prefix));
    }
    if (SerialNumber != null)
    {
        Xor(destinationArray, Encoding.UTF8.GetBytes(SerialNumber));
    }
    byte num2 = (byte) (((byte) Data.Length) | 0x80);
    for (int i = 0; i < destinationArray.Length; i++)
    {
        destinationArray[i] = (byte) (destinationArray[i] ^ num2);
    }
    byte[] buffer2 = new byte[destinationArray.Length + 1];
    Array.Copy(destinationArray, 0, buffer2, 1, destinationArray.Length);
    buffer2[0] = num2;
    destinationArray = buffer2;
    char[] array = (CharacterSet[(int) codeAlgorithm] + Utils.ByteToString(destinationArray, CharacterSet, -1, 0, destinationArray.Length, true) + CharacterSet[Utils.Crc16(destinationArray) % (CharacterSet.Length - 1)]).ToCharArray();
    Array.Reverse(array, 0, char.ToLower(array[array.Length - 1]) % (array.Length - 2));
    string str = new string(array);
    if ((prefix != null) && (prefix.IndexOf('-') == -1))
    {
        str = prefix + str;
    }
    if (GroupSizes == null)
    {
        int length;
        int num6;
        int num4 = 8;
        if (str.Length <= 0x12)
        {
            num4 = 4;
        }
        else if (str.Length <= 0x23)
        {
            num4 = 5;
        }
        else if (str.Length <= 0x30)
        {
            num4 = 6;
        }
        num4 = smethod_14(str.Length, num4, out length, out num6);
        GroupSizes = new int[length];
        length = str.Length;
        int num7 = (prefix == null) ? -1 : prefix.LastIndexOf('-');
        if (num7 != -1)
        {
            int num8 = (prefix.Length - num7) - 1;
            if ((num8 > 0) && (num8 < num4))
            {
                num4 = smethod_14(str.Length + num8, num4, out length, out num6);
                length = str.Length + num8;
                GroupSizes[0] = num4 - num8;
                length -= num7;
                num7 = 1;
            }
            else
            {
                num7 = 0;
            }
        }
        else
        {
            num7++;
        }
        while (num7 < GroupSizes.Length)
        {
            GroupSizes[num7] = num4 + ((num6 > 0) ? 1 : 0);
            length -= num4 + ((num6 > 0) ? 1 : 0);
            num6--;
            if (num6 < 0)
            {
                num6 = 0;
            }
            num7++;
        }
    }
    if (GroupSizes.Length <= 0)
    {
        if ((prefix != null) && (prefix.IndexOf('-') == -1))
        {
            return str;
        }
        return string.Format("{0}{2}", prefix, str);
    }
    StringBuilder builder = new StringBuilder(str);
    int index = 0;
    for (int j = 0; j < GroupSizes.Length; j++)
    {
        index += GroupSizes[j];
        if (index >= builder.Length)
        {
            break;
        }
        builder.Insert(index, '-');
        index++;
    }
    if ((prefix != null) && (prefix.IndexOf('-') != -1))
    {
        builder.Insert(0, prefix);
    }
    return builder.ToString();
}

 
static Hashtable hashtable_0;

public ILicenseCodeSupport GetCustomCodeSupport(DeployLXLicensing.CodeAlgorithm algorithm)
{
    //string keyFolder = Configuration.KeyFolder;
    lock (typeof(LicenseKeyGen))
    {
        ILicenseCodeSupport support = hashtable_0[algorithm] as ILicenseCodeSupport;
        if (support == null)
        {
            switch (algorithm)
            {
                case DeployLXLicensing.CodeAlgorithm.SerialNumber:
                    return new SerialNumberAlgo(this);

                case DeployLXLicensing.CodeAlgorithm.ActivationCode:
                    return new ActivationCodeAlgo(this);

                case DeployLXLicensing.CodeAlgorithm.Simple:
                    return new SimpleAlgo(this);

                case DeployLXLicensing.CodeAlgorithm.Basic:
                    return new BasicAlgo(this);

                case DeployLXLicensing.CodeAlgorithm.Advanced:
                    return new AdvancedAlgo(this);
            }
        }
        return support;
    }
}

 


 

 


 


		
	}
}
