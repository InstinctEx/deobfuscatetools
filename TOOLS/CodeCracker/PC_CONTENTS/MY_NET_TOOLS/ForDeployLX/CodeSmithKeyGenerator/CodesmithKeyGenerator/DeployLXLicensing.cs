/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 06.07.2013
 * Time: 20:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace DeployLXLicensing
{

public enum CodeAlgorithm
{
    NotSet,
    Custom1,
    Custom2,
    Custom3,
    Custom4,
    SerialNumber,
    ActivationCode,
    Simple,
    Basic,
    Advanced
}

 [Flags]
public enum SerialNumberFlags
{
    Flag1 = 1,
    Flag2 = 2,
    Flag3 = 4,
    Flag4 = 8,
    Flag5 = 0x10,
    Flag6 = 0x20,
    Flag7 = 0x40,
    Flag8 = 0x80,
    None = 0
}

     public enum MachineType
    {
        Any,
        Desktop,
        Laptop
    }

    public enum MachineProfileEntryType
    {
        CdRom = 5,
        Cpu = 1,
        Custom1 = 100,
        Custom2 = 0x65,
        Custom3 = 0x66,
        Custom4 = 0x67,
        Ide = 8,
        MACAddress = 3,
        Memory = 2,
        NotSet = 0,
        PartialFlag = 0x40000000,
        Scsi = 7,
        SystemDrive = 4,
        TypeMask = 0xfffffff,
        VideoCard = 6
    }

public sealed class MachineProfile
{
public static bool IsHashValid(string hash)
{
    //Check.NotNull(hash, "hash");
    if (hash==null||hash.Length < 5)
    {
        return false;
    }
    try
    {
        byte[] array = DeployLXKeyGenerator.Utils.StringToByte(ParseHash(hash).ToString(), "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5");
        byte num = array[1];
        if ((((num >> 2) & 7) >= 3) && (((num >> 2) & 7) <= 4))
        {
            Array.Reverse(array);
            int num2 = 0x1505;
            for (int i = 0; i < (array.Length - 3); i++)
            {
                num2 = ((num2 << 5) + num2) ^ array[i];
            }
            if (array[array.Length - 3] != ((byte) num2))
            {
                return false;
            }
            return true;
        }
        return false;
    }
    catch
    {
        return false;
    }
}

private static StringBuilder ParseHash(string string_1)
{
    StringBuilder builder = new StringBuilder(string_1);
    if (string_1.Length >= 5)
    {
        builder.Replace("-", "");
        char[] array = builder.ToString().ToCharArray();
        int index = ((array[0] % (array.Length - 1)) & 7) | 1;
        Array.Reverse(array, index, array.Length - index);
        index = 3 | (array[array.Length - 1] % (array.Length - 2));
        if (index >= array.Length)
        {
            index = array.Length - 1;
        }
        Array.Reverse(array, 0, index);
        builder.Length = 0;
        builder.Append(array);
    }
    return builder;
}



 
}

}
