namespace DeployLX.Licensing.v4
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Xml;

    public sealed class MachineProfile
    {
        /* private scope */ static ArrayList arrayList_0;
        /* private scope */ static bool bool_0;
        /* private scope */ static readonly byte[] byte_0 = new byte[] { 
            0x1c, 0, 0, 0, 0x53, 0x43, 0x53, 0x49, 0x44, 0x49, 0x53, 0x4b, 0x10, 0x27, 0, 0, 
            1, 5, 0x1b, 0, 0, 0, 0, 0, 0x11, 2, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0xec
         };
        /* private scope */ const int int_0 = 3;
        /* private scope */ const int int_1 = 4;
        /* private scope */ const int int_2 = 4;
        /* private scope */ const int int_3 = 3;
        /* private scope */ const int int_4 = 4;
        /* private scope */ int int_5;
        /* private scope */ static int int_6;
        /* private scope */ static readonly int[] int_7 = new int[] { 0x1a0, 0x10c, 8, 400, 0x194, 0x288 };
        /* private scope */ static readonly int[] int_8 = new int[] { 420, 0x110, 12, 0x194, 0x198, 0x2c0 };
        /* private scope */ static MachineProfile machineProfile_0;
        /* private scope */ static MachineProfile machineProfile_1 = GetDefaultProfile();
        /* private scope */ MachineProfileEntryCollection machineProfileEntryCollection_0;
        /* private scope */ string string_0;

        public MachineProfile()
        {
            this.int_5 = 3;
            this.machineProfileEntryCollection_0 = new MachineProfileEntryCollection();
            this.machineProfileEntryCollection_0.Changed += new CollectionEventHandler(this.machineProfileEntryCollection_0_Changed);
        }

        internal MachineProfile(MachineProfileEntryCollection hardware)
        {
            this.int_5 = 3;
            this.machineProfileEntryCollection_0 = new MachineProfileEntryCollection();
            this.machineProfileEntryCollection_0 = hardware;
        }

        public static bool CheckIsDefault(MachineProfileEntryCollection profile)
        {
            //DeployLX.Licensing.v4.Check.NotNull(profile, "profile");
            if (profile.Count != machineProfile_1.machineProfileEntryCollection_0.Count)
            {
                return false;
            }
            foreach (MachineProfileEntry entry in (IEnumerable) machineProfile_1.machineProfileEntryCollection_0)
            {
                bool flag = false;
                foreach (MachineProfileEntry entry2 in (IEnumerable) profile)
                {
                    if (entry2.Type == entry.Type)
                    {
                        if (entry2.Weight != entry.Weight)
                        {
                            return false;
                        }
                        if (entry2.PartialMatchWeight != entry.PartialMatchWeight)
                        {
                            return false;
                        }
                        if (entry2.Interface1_0 != entry.Interface1_0)
                        {
                            return false;
                        }
                        flag = true;
                    }
                }
                if (!flag)
                {
                    return false;
                }
            }
            return true;
        }

        public static int CompareHash(string hash, MachineProfile profile, bool fileMoved)
        {
            return CompareHash(hash, profile.GetComparableHash(false, null), fileMoved, profile.machineProfileEntryCollection_0);
        }

        public static int CompareHash(string hash, string comparedHash, bool fileMoved, MachineProfileEntryCollection hardwareList)
        {
            MachineProfileEntryType[] typeArray;
            return CompareHash(hash, comparedHash, fileMoved, hardwareList, out typeArray);
        }

        public static int CompareHash(string hash, string comparedHash, bool fileMoved, MachineProfileEntryCollection hardwareList, out MachineProfileEntryType[] diffs)
        {
            byte[] buffer;
            //DeployLX.Licensing.v4.Check.NotNullOrEmpty(hash, "hash");
            //DeployLX.Licensing.v4.Check.NotNullOrEmpty(comparedHash, "comparedHash");
            //DeployLX.Licensing.v4.Check.NotNull(hardwareList, "hardwareList");
            diffs = null;
            if (!IsHashValid(hash) || !IsHashValid(comparedHash))
            {
                return 0x2711;
            }
            ArrayList list = smethod_4(hash, out buffer);
            ArrayList list2 = smethod_4(comparedHash, out buffer);
            ArrayList list3 = new ArrayList();
            int num = (((int[]) list[0])[0] >> 2) & 7;
            int num2 = (((int[]) list2[0])[0] >> 2) & 7;
            if (((num > 4) || (num < 3)) || ((num2 > 4) || (num2 < 3)))
            {
                return 0x2712;
            }
            bool flag = (((int[]) list[0])[0] & 1) != 0;
            int num3 = 0;
            for (int i = 0; i < hardwareList.Count; i++)
            {
                int[] numArray;
                int[] numArray2;
                if (list.Count > (i + 1))
                {
                    numArray = list[i + 1] as int[];
                }
                else
                {
                    numArray = new int[0];
                }
                if (list2.Count > (i + 1))
                {
                    numArray2 = list2[i + 1] as int[];
                }
                else
                {
                    numArray2 = new int[0];
                }
                bool flag2 = (numArray.Length == 0) && (numArray2.Length == 0);
                for (int j = 0; j < numArray.Length; j++)
                {
                    for (int m = 0; m < numArray2.Length; m++)
                    {
                        if (numArray[j] == numArray2[m])
                        {
                            flag2 = true;
                            numArray2[m] = -1;
                            numArray[j] = -1;
                        }
                    }
                }
                if (!flag2)
                {
                    goto Label_0218;
                }
                bool flag3 = false;
                for (int k = 0; k < numArray.Length; k++)
                {
                    if (numArray[k] != -1)
                    {
                        goto Label_0188;
                    }
                }
                goto Label_018B;
            Label_0188:
                flag3 = true;
            Label_018B:
                if (!flag3 && !flag)
                {
                    for (int n = 0; n < numArray2.Length; n++)
                    {
                        if (numArray2[n] != -1)
                        {
                            goto Label_01B2;
                        }
                    }
                }
                goto Label_01B5;
            Label_01B2:
                flag3 = true;
            Label_01B5:
                if (flag3)
                {
                    if (fileMoved)
                    {
                        num3 += Math.Max(hardwareList[i].FileMovedWeight, hardwareList[i].PartialMatchWeight);
                    }
                    else
                    {
                        num3 += hardwareList[i].PartialMatchWeight;
                    }
                    list3.Add(hardwareList[i].Type | MachineProfileEntryType.PartialFlag);
                }
                continue;
            Label_0218:
                num3 += fileMoved ? hardwareList[i].FileMovedWeight : hardwareList[i].Weight;
                list3.Add(hardwareList[i].Type);
            }
            if (list3.Count > 0)
            {
                diffs = list3.ToArray(typeof(MachineProfileEntryType)) as MachineProfileEntryType[];
            }
            return Math.Min(num3, 10);
        }

        public static byte[] GetAdditionalData(string hash)
        {
            //DeployLX.Licensing.v4.Check.NotNullOrEmpty(hash, "hash");
            byte[] array = Class30.smethod_5(smethod_3(hash).ToString(), "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5");
            Array.Reverse(array);
            byte[] dst = null;
            int count = array[array.Length - 4] >> 4;
            if (count > 0)
            {
                dst = new byte[count];
                Buffer.BlockCopy(array, array.Length - (4 + count), dst, 0, count);
            }
            return dst;
        }

        public string GetComparableHash(bool firstOnly, byte[] additional)
        {
            if (this.machineProfileEntryCollection_0.Count == 0)
            {
                return null;
            }
            if (additional != null)
            {
                if (additional.Length > 8)
                {
                    throw new Exception("E_AdditionalProfileDataTooLong");
                }
                if (additional.Length == 0)
                {
                    additional = null;
                }
            }
            ArrayList list = new ArrayList();
            using (MemoryStream stream = new MemoryStream())
            {
                foreach (MachineProfileEntry entry in (IEnumerable) this.machineProfileEntryCollection_0)
                {
                    string str = null;
                    string[] strArray = null;
                    switch ((entry.Type & MachineProfileEntryType.TypeMask))
                    {
                        case MachineProfileEntryType.Cpu:
                            str = smethod_13();
                            goto Label_01AF;

                        case MachineProfileEntryType.Memory:
                            str = smethod_12();
                            goto Label_01AF;

                        case MachineProfileEntryType.MACAddress:
                            strArray = smethod_14();
                            goto Label_01AF;

                        case MachineProfileEntryType.SystemDrive:
                            str = smethod_5();
                            goto Label_01AF;

                        case MachineProfileEntryType.CDRom:
                            strArray = smethod_16("{4D36E965-E325-11CE-BFC1-08002BE10318}", false, null, new string[0]);
                            goto Label_01AF;

                        case MachineProfileEntryType.VideoCard:
                            strArray = smethod_16("{4D36E968-E325-11CE-BFC1-08002BE10318}", false, "03", new string[0]);
                            goto Label_01AF;

                        case MachineProfileEntryType.Scsi:
                            strArray = smethod_16("{4D36E97B-E325-11CE-BFC1-08002BE10318}", false, "01", new string[] { "00", "01", "04" });
                            goto Label_01AF;

                        case MachineProfileEntryType.Ide:
                            strArray = smethod_16("{4D36E96A-E325-11CE-BFC1-08002BE10318}", false, "01", new string[] { "01" });
                            goto Label_01AF;

                        case MachineProfileEntryType.Motherboard:
                            strArray = smethod_19(false);
                            goto Label_01AF;

                        case MachineProfileEntryType.Custom1:
                        case MachineProfileEntryType.Custom2:
                        case MachineProfileEntryType.Custom3:
                        case MachineProfileEntryType.Custom4:
                            if (entry.Interface1_0 != null)
                            {
                                break;
                            }
                            str = "";
                            goto Label_01AF;

                        default:
                            str = "";
                            goto Label_01AF;
                    }
                    strArray = entry.Interface1_0.imethod_0(entry.Type);
                Label_01AF:
                    if (strArray == null)
                    {
                        strArray = new string[] { str };
                    }
                    this.method_1(entry, firstOnly, strArray, list, stream);
                }
                return this.method_0(firstOnly, additional, list, stream);
            }
        }

        public string GetComparableHashFromDiagnostic(bool firstOnly, string diagnosticFragment)
        {
            if (this.machineProfileEntryCollection_0.Count == 0)
            {
                return null;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(diagnosticFragment);
            ArrayList list = new ArrayList();
            using (MemoryStream stream = new MemoryStream())
            {
                foreach (MachineProfileEntry entry in (IEnumerable) this.machineProfileEntryCollection_0)
                {
                    string[] strArray = null;
                    XmlNode node = document.SelectSingleNode(string.Format("//Component[@type='{0}']", entry.Type));
                    if (node == null)
                    {
                        strArray = new string[] { "" };
                    }
                    else
                    {
                        strArray = new string[node.ChildNodes.Count];
                        int index = 0;
                        foreach (XmlNode node2 in node.ChildNodes)
                        {
                            if (node2.Attributes["raw"] != null)
                            {
                                byte[] buffer = Convert.FromBase64String(node2.Attributes["raw"].Value);
                                char[] chArray = new char[buffer.Length];
                                for (int i = 0; i < buffer.Length; i++)
                                {
                                    chArray[i] = (char) buffer[i];
                                }
                                strArray[index] = new string(chArray);
                            }
                            else
                            {
                                strArray[index] = node2.Attributes["id"].Value;
                            }
                            index++;
                        }
                    }
                    this.method_1(entry, firstOnly, strArray, list, stream);
                }
                return this.method_0(firstOnly, null, list, stream);
            }
        }

        public static MachineProfile GetDefaultProfile()
        {
            MachineProfile profile = new MachineProfile();
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.MACAddress, 3, 1, 3));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.Cpu, 1, 1, 2));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.SystemDrive, 3, 2, 3));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.Memory, 1, 1, 1));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.CDRom, 1, 1, 1));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.VideoCard, 1, 1, 1));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.Ide, 1, 1, 1));
            profile.machineProfileEntryCollection_0.Add(new MachineProfileEntry(MachineProfileEntryType.Scsi, 1, 1, 1));
            return profile;
        }

        public string GetDiagnosticHash()
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                using (XmlTextWriter writer2 = new XmlTextWriter(writer))
                {
                    writer2.Formatting = Formatting.Indented;
                    writer2.Indentation = 1;
                    writer2.IndentChar = '\t';
                    writer2.WriteStartDocument();
                    writer2.WriteStartElement("MachineProfile");
                    writer2.WriteAttributeString("isLaptop", IsLaptop ? "true" : "false");
                    writer2.WriteElementString("Hash", this.GetComparableHash(false, null));
                    writer2.WriteStartElement("Os");
                    OSRecord thisMachine = OSRecord.ThisMachine;
                    writer2.WriteAttributeString("product", thisMachine.Product.ToString());
                    writer2.WriteAttributeString("edition", thisMachine.Edition.ToString());
                    if (thisMachine.Version != null)
                    {
                        writer2.WriteAttributeString("version", thisMachine.Version.ToString());
                    }
                    writer2.WriteAttributeString("servicePack", thisMachine.ServicePack);
                    writer2.WriteEndElement();
                    writer2.WriteStartElement("Laptop");
                    writer2.WriteAttributeString("isLaptop", IsLaptop ? "yes" : "no");
                    bool systemPowerStatus = Class21.GetSystemPowerStatus(new byte[0x18]);
                    writer2.WriteAttributeString("battery", smethod_0() ? "yes" : "no");
                    writer2.WriteAttributeString("lid", smethod_1() ? "yes" : "no");
                    writer2.WriteAttributeString("gotPower", systemPowerStatus ? "yes" : "no");
                    writer2.WriteEndElement();
                    foreach (MachineProfileEntry entry in (IEnumerable) this.machineProfileEntryCollection_0)
                    {
                        writer2.WriteStartElement("Component");
                        writer2.WriteAttributeString("displayName", entry.DisplayName);
                        writer2.WriteAttributeString("type", entry.Type.ToString());
                        string str = null;
                        string[] strArray = null;
                        switch ((entry.Type & MachineProfileEntryType.TypeMask))
                        {
                            case MachineProfileEntryType.Cpu:
                                str = smethod_13();
                                goto Label_0342;

                            case MachineProfileEntryType.Memory:
                                str = smethod_12();
                                goto Label_0342;

                            case MachineProfileEntryType.MACAddress:
                                strArray = smethod_14();
                                goto Label_0342;

                            case MachineProfileEntryType.SystemDrive:
                                str = smethod_5();
                                goto Label_0342;

                            case MachineProfileEntryType.CDRom:
                                strArray = smethod_16("{4D36E965-E325-11CE-BFC1-08002BE10318}", true, null, new string[0]);
                                goto Label_0342;

                            case MachineProfileEntryType.VideoCard:
                                strArray = smethod_16("{4D36E968-E325-11CE-BFC1-08002BE10318}", true, "03", new string[0]);
                                goto Label_0342;

                            case MachineProfileEntryType.Scsi:
                                strArray = smethod_16("{4D36E97B-E325-11CE-BFC1-08002BE10318}", true, "01", new string[] { "00", "01", "04" });
                                goto Label_0342;

                            case MachineProfileEntryType.Ide:
                                strArray = smethod_16("{4D36E96A-E325-11CE-BFC1-08002BE10318}", true, "01", new string[] { "01" });
                                goto Label_0342;

                            case MachineProfileEntryType.Motherboard:
                                strArray = smethod_19(true);
                                goto Label_0342;

                            case MachineProfileEntryType.Custom1:
                            case MachineProfileEntryType.Custom2:
                            case MachineProfileEntryType.Custom3:
                            case MachineProfileEntryType.Custom4:
                                if (entry.Interface1_0 != null)
                                {
                                    break;
                                }
                                str = "";
                                goto Label_0342;

                            default:
                                str = "";
                                goto Label_0342;
                        }
                        strArray = entry.Interface1_0.imethod_0(entry.Type);
                    Label_0342:
                        if (str == null)
                        {
                            if (strArray != null)
                            {
                                foreach (string str2 in strArray)
                                {
                                    smethod_2(writer2, str2);
                                }
                            }
                        }
                        else
                        {
                            smethod_2(writer2, str);
                        }
                        writer2.WriteEndElement();
                    }
                    writer2.WriteEndElement();
                }
            }
            return sb.ToString();
        }

        public static MachineProfileEntryType[] GetDifferences(string hash, MachineProfile profile)
        {
            return GetDifferences(hash, profile.GetComparableHash(false, null), profile.machineProfileEntryCollection_0);
        }

        public static MachineProfileEntryType[] GetDifferences(string hash, string comparedHash, MachineProfileEntryCollection hardwareList)
        {
            MachineProfileEntryType[] typeArray;
            CompareHash(hash, comparedHash, false, hardwareList, out typeArray);
            return typeArray;
        }

        public static int GetHashVersion(string hash)
        {
            byte[] buffer;
            //DeployLX.Licensing.v4.Check.NotNullOrEmpty(hash, "hash");
            return ((((int[]) smethod_4(hash, out buffer)[0])[0] >> 2) & 7);
        }

        public static bool IsHashValid(string hash)
        {
            //DeployLX.Licensing.v4.Check.NotNull(hash, "hash");
            if (hash.Length < 5)
            {
                return false;
            }
            try
            {
                byte[] array = Class30.smethod_5(smethod_3(hash).ToString(), "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5");
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

        public static bool IsLaptopHash(string hash)
        {
            //DeployLX.Licensing.v4.Check.NotNull(hash, "hash");
            if (hash.Length < 5)
            {
                return false;
            }
            return ((Class30.smethod_5(smethod_3(hash).ToString(), "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5")[1] & 2) != 0);
        }

        private void machineProfileEntryCollection_0_Changed(object sender, CollectionEventArgs e)
        {
            this.string_0 = null;
            if (this.machineProfileEntryCollection_0.Count > 0x10)
            {
                throw new Exception("E_TooMuchHardware");
            }
        }

        private string method_0(bool bool_1, byte[] byte_1, ArrayList arrayList_1, MemoryStream memoryStream_0)
        {
            int num = 0;
            if (byte_1 != null)
            {
                num += byte_1.Length * 8;
            }
            if (!bool_1)
            {
                num += ((int) Math.Ceiling((double) (((double) arrayList_1.Count) / 2.0))) * 8;
            }
            for (int i = Class30.smethod_7((((int) ((memoryStream_0.Length + 3) * 8)) + 4) + num, "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5", -1) % 5; i != 0; i = Class30.smethod_7((((int) ((memoryStream_0.Length + 3) * 8)) + 4) + num, "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5", -1) % 5)
            {
                memoryStream_0.WriteByte(0x85);
            }
            if (byte_1 != null)
            {
                memoryStream_0.Write(byte_1, 0, byte_1.Length);
            }
            if (!bool_1)
            {
                for (int j = 0; j < arrayList_1.Count; j++)
                {
                    byte num4 = (byte) (((int) arrayList_1[j++]) << 4);
                    if (j < arrayList_1.Count)
                    {
                        num4 = (byte) (num4 | ((byte) ((int) arrayList_1[j])));
                    }
                    memoryStream_0.WriteByte(num4);
                }
            }
            int num5 = this.machineProfileEntryCollection_0.Count - 1;
            if (byte_1 != null)
            {
                num5 |= byte_1.Length << 4;
            }
            memoryStream_0.WriteByte((byte) num5);
            memoryStream_0.Flush();
            byte[] array = memoryStream_0.ToArray();
            int index = 0x1505;
            foreach (byte num7 in array)
            {
                index = ((index << 5) + index) ^ num7;
            }
            memoryStream_0.WriteByte((byte) index);
            byte num8 = (byte) ((0x30 | (IsLaptop ? 2 : 0)) | (bool_1 ? 1 : 0));
            memoryStream_0.WriteByte(num8);
            num8 = 8;
            memoryStream_0.WriteByte(8);
            array = memoryStream_0.ToArray();
            Array.Reverse(array);
            StringBuilder builder = new StringBuilder(Class30.smethod_1(array, "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5", -1));
            char[] chArray = builder.ToString().ToCharArray();
            int length = 3 | (chArray[chArray.Length - 1] % (chArray.Length - 2));
            if (length >= chArray.Length)
            {
                length = chArray.Length - 1;
            }
            Array.Reverse(chArray, 0, length);
            index = ((chArray[0] % (chArray.Length - 1)) & 7) | 1;
            Array.Reverse(chArray, index, chArray.Length - index);
            builder.Length = 0;
            builder.Append(chArray);
            int num10 = builder.Length % 5;
            if (num10 == 0)
            {
                num10 = 5;
            }
            while (num10 < builder.Length)
            {
                builder.Insert(num10, '-');
                num10 += 6;
            }
            return builder.ToString();
        }

        private void method_1(MachineProfileEntry machineProfileEntry_0, bool bool_1, string[] string_1, ArrayList arrayList_1, MemoryStream memoryStream_0)
        {
            if (string_1.Length > 15)
            {
                throw new InvalidOperationException(Class37.smethod_0("E_TooManyHardwareVariations", new object[] { machineProfileEntry_0.DisplayName }));
            }
            if (!bool_1)
            {
                arrayList_1.Add(string_1.Length);
            }
            foreach (string str in string_1)
            {
                memoryStream_0.WriteByte((byte) Class30.smethod_11(str));
                if (bool_1)
                {
                    return;
                }
            }
        }

        private static bool smethod_0()
        {
            byte[] buffer = new byte[0x18];
            return (Class21.GetSystemPowerStatus(buffer) && (buffer[1] < 0x80));
        }

        private static bool smethod_1()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E97D-E325-11CE-BFC1-08002BE10318}", false))
            {
                if (key != null)
                {
                    foreach (string str in key.GetSubKeyNames())
                    {
                        try
                        {
                            using (RegistryKey key2 = key.OpenSubKey(str, false))
                            {
                                if ((key2 != null) && ((key2.GetValue("MatchingDeviceId") as string) == "*pnp0c0d"))
                                {
                                    return true;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return false;
        }

        private static string smethod_10(byte[] byte_1, int int_9)
        {
            StringBuilder builder = new StringBuilder();
            int num = 0;
            for (int i = int_9; i < byte_1.Length; i++)
            {
                if (byte_1[i] == 0)
                {
                    break;
                }
                num++;
            }
            for (int j = 0; j < num; j += 4)
            {
                for (int k = 1; k >= 0; k--)
                {
                    int num5 = 0;
                    for (int m = 0; m < 2; m++)
                    {
                        num5 *= 0x10;
                        byte num7 = byte_1[((int_9 + j) + (k * 2)) + m];
                        if ((num7 >= 0x30) && (num7 <= 0x39))
                        {
                            num5 += num7 - 0x30;
                        }
                        else if ((num7 >= 0x61) && (num7 <= 0x66))
                        {
                            num5 += num7 - 0x51;
                        }
                        else if ((num7 >= 0x41) && (num7 <= 70))
                        {
                            num5 += num7 - 0x31;
                        }
                    }
                    if (num5 > 0)
                    {
                        builder.Append((char) num5);
                    }
                }
            }
            return builder.ToString();
        }

        private static string smethod_11(byte[] byte_1, int int_9)
        {
            byte num2;
            int index = int_9;
            do
            {
                num2 = byte_1[index];
                index++;
            }
            while (num2 != 0);
            return Encoding.ASCII.GetString(byte_1, int_9, (index - int_9) - 1);
        }

        private static string smethod_12()
        {
            string str="";
            ulong num = 0;
            try
            {
                byte[] buffer = new byte[0x80];
                if ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version >= new System.Version(4, 0)))
                {
                    buffer[0] = 0x40;
                    Class21.GlobalMemoryStatusEx(buffer);
                    return BitConverter.ToUInt64(buffer, 8).ToString(CultureInfo.InvariantCulture);
                }
                buffer[0] = 0x20;
                Class21.GlobalMemoryStatus(buffer);
                num = BitConverter.ToUInt32(buffer, 8);
            }
            catch (Exception)
            {
                str = "Exception";
            }
            return str;
        }

        private static string smethod_13()
        {
            byte[] buffer = new byte[0x30];
            Class28.smethod_1(buffer);
            if (Use64BitCompatibleCpuid)
            {
                for (int j = 40; j < buffer.Length; j++)
                {
                    buffer[j] = 0;
                }
            }
            char[] chArray = new char[buffer.Length];
            for (int i = 0; i < buffer.Length; i++)
            {
                chArray[i] = (char) buffer[i];
            }
            return new string(chArray);
        }

        private static string[] smethod_14()
        {
            string[] strArray=null;
            try
            {
                string str;
                byte[] buffer = null;
                uint num = 0;
                int[] numArray = Class21.bool_0 ? int_8 : int_7;
                int num2 = 0;
                Class21.GetAdaptersInfo(null, ref num);
                buffer = new byte[num];
                Class21.GetAdaptersInfo(buffer, ref num);
                if ((buffer == null) || (buffer.Length == 0))
                {
                    goto Label_02B9;
                }
                ArrayList list = new ArrayList();
                goto Label_0225;
            Label_004E:
                if (Class21.bool_0)
                {
                    long num7 = BitConverter.ToInt64(buffer, 0);
                    if (num7 == 0)
                    {
                        goto Label_023D;
                    }
                    Marshal.Copy(new IntPtr(num7), buffer, 0, numArray[5]);
                }
                else
                {
                    int num8 = BitConverter.ToInt32(buffer, 0);
                    if (num8 == 0)
                    {
                        goto Label_023D;
                    }
                    Marshal.Copy(new IntPtr(num8), buffer, 0, numArray[5]);
                }
                goto Label_0225;
            Label_00A3:
                str = smethod_15(buffer, numArray[1], 0x80);
                if (((str.IndexOf("Windows Mobile") <= -1) && (str.IndexOf("Bluetooth") <= -1)) && ((str.IndexOf("VPN") <= -1) && ((buffer[numArray[4]] & 2) != 2)))
                {
                    string strB = smethod_15(buffer, numArray[2], 0x100);
                    using (RegistryKey key = Toolbox.GetRegistryKey(@"HKLM\SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002bE10318}", false))
                    {
                        if (key != null)
                        {
                            bool flag = false;
                            foreach (string str3 in key.GetSubKeyNames())
                            {
                                using (RegistryKey key2 = key.OpenSubKey(str3, false))
                                {
                                    string strA = key2.GetValue("NetCfgInstanceId") as string;
                                    if ((strA != null) && (string.Compare(strA, strB, true) == 0))
                                    {
                                        string str5 = key2.GetValue("NetworkAddress") as string;
                                        if ((str5 != null) && (str5.Length > 0))
                                        {
                                            flag = true;
                                            num2++;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (flag)
                            {
                                goto Label_004E;
                            }
                        }
                    }
                    StringBuilder builder = new StringBuilder();
                    int num4 = BitConverter.ToInt32(buffer, numArray[3]) + numArray[4];
                    for (int i = numArray[4]; i < num4; i++)
                    {
                        byte num6 = buffer[i];
                        builder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}:", new object[] { num6 });
                    }
                    list.Add(builder.ToString());
                }
                goto Label_004E;
            Label_0225:
                if (BitConverter.ToInt32(buffer, numArray[0]) != 6)
                {
                    goto Label_004E;
                }
                goto Label_00A3;
            Label_023D:
                if (num2 > 0)
                {
                    if (list.Count <= 0)
                    {
                        goto Label_028D;
                    }
                    while (num2 > 0)
                    {
                        list.Add("MANUALSAFE");
                        num2--;
                    }
                }
                goto Label_0291;
            Label_0264:
                list.Add(new Random().Next(0xfffff).ToString("X05"));
                num2--;
            Label_028D:
                if (num2 > 0)
                {
                    goto Label_0264;
                }
            Label_0291:
                if (list.Count == 0)
                {
                    return null;
                }
                return (list.ToArray(typeof(string)) as string[]);
            Label_02B9:
                strArray = null;
            }
            catch
            {
            }
            return strArray;
        }

        private static string smethod_15(byte[] byte_1, int int_9, int int_10)
        {
            for (int i = 0; i < int_10; i++)
            {
                if (byte_1[i + int_9] == 0)
                {
                    return Encoding.ASCII.GetString(byte_1, int_9, i);
                }
            }
            return Encoding.ASCII.GetString(byte_1, int_9, int_10);
        }

        private static string[] smethod_16(string string_1, bool bool_1, string string_2, params string[] string_3)
        {
            smethod_18();
            ArrayList list = new ArrayList();
            foreach (Struct32 struct2 in arrayList_0)
            {
                if (struct2.string_1 != string_1)
                {
                    continue;
                }
                if (string_2 != null)
                {
                    foreach (string str in struct2.string_2)
                    {
                        int index = str.IndexOf("&CC_");
                        if ((index < 0) || (string.Compare(string_2, 0, str, index + 4, 2) != 0))
                        {
                            goto Label_00C7;
                        }
                        if ((string_3 == null) || (string_3.Length <= 0))
                        {
                            goto Label_00BF;
                        }
                        bool flag = false;
                        foreach (string str2 in string_3)
                        {
                            if (string.Compare(str2, 0, str, index + 6, 2) == 0)
                            {
                                goto Label_00AE;
                            }
                        }
                        goto Label_00B9;
                    Label_00AE:
                        smethod_17(bool_1, list, struct2);
                        flag = true;
                    Label_00B9:
                        if (!flag)
                        {
                            goto Label_00C7;
                        }
                        break;
                    Label_00BF:
                        smethod_17(bool_1, list, struct2);
                    Label_00C7:;
                    }
                    continue;
                }
                smethod_17(bool_1, list, struct2);
            }
            return (list.ToArray(typeof(string)) as string[]);
        }

        private static void smethod_17(bool bool_1, ArrayList arrayList_1, Struct32 struct32_0)
        {
            string str;
            if (bool_1)
            {
                str = string.Format("{0}\0[{1}]", struct32_0.string_5, struct32_0.string_3);
            }
            else
            {
                str = struct32_0.string_5;
            }
            if (!arrayList_1.Contains(str))
            {
                arrayList_1.Add(str);
            }
        }

        private static void smethod_18()
        {
            if (arrayList_0 == null)
            {
                lock (typeof(MachineProfile))
                {
                    arrayList_0 = new ArrayList();
                    ArrayList list = new ArrayList();
                    list.Add("{4D36E97B-E325-11CE-BFC1-08002BE10318}");
                    list.Add("{4D36E965-E325-11CE-BFC1-08002BE10318}");
                    list.Add("{4D36E96A-E325-11CE-BFC1-08002BE10318}");
                    list.Add("{4D36E968-E325-11CE-BFC1-08002BE10318}");
                    list.Add("{4D36E97D-E325-11CE-BFC1-08002BE10318}");
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum", false))
                    {
                        if (key != null)
                        {
                            foreach (string str in new string[] { "ACPI", "PCI", "IDE" })
                            {
                                using (RegistryKey key2 = key.OpenSubKey(str, false))
                                {
                                    if (key2 != null)
                                    {
                                        foreach (string str2 in key2.GetSubKeyNames())
                                        {
                                            using (RegistryKey key3 = key2.OpenSubKey(str2, false))
                                            {
                                                if (key3 != null)
                                                {
                                                    foreach (string str3 in key3.GetSubKeyNames())
                                                    {
                                                        using (RegistryKey key4 = key3.OpenSubKey(str3, false))
                                                        {
                                                            if (key4 != null)
                                                            {
                                                                string item = key4.GetValue("ClassGUID") as string;
                                                                item = (item == null) ? null : item.ToUpper();
                                                                if ((item != null) && list.Contains(item))
                                                                {
                                                                    Struct32 struct2 = new Struct32 {
                                                                        string_0 = key4.Name,
                                                                        string_1 = item,
                                                                        string_3 = key4.GetValue("DeviceDesc") as string,
                                                                        string_4 = str,
                                                                        string_2 = key4.GetValue("HardwareID") as string[]
                                                                    };
                                                                    if (struct2.string_2 != null)
                                                                    {
                                                                        int index = struct2.string_0.IndexOf(struct2.string_2[0]);
                                                                        if (index != -1)
                                                                        {
                                                                            IntPtr ptr;
                                                                            struct2.string_5 = struct2.string_0.Substring(index);
                                                                            if (Class21.CM_Locate_DevNode(out ptr, struct2.string_5, 0) == 0)
                                                                            {
                                                                                arrayList_0.Add(struct2);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static string[] smethod_19(bool bool_1)
        {
            ArrayList list = new ArrayList();
            string[] c = null;
            c = smethod_16("{4D36E97D-E325-11CE-BFC1-08002BE10318}", bool_1, "05", new string[0]);
            if ((c != null) && (c.Length > 0))
            {
                list.AddRange(c);
            }
            c = smethod_16("{4D36E97D-E325-11CE-BFC1-08002BE10318}", bool_1, "06", new string[0]);
            if ((c != null) && (c.Length > 0))
            {
                list.AddRange(c);
            }
            c = smethod_16("{4D36E97D-E325-11CE-BFC1-08002BE10318}", bool_1, "08", new string[0]);
            if ((c != null) && (c.Length > 0))
            {
                list.AddRange(c);
            }
            c = smethod_16("{4D36E97D-E325-11CE-BFC1-08002BE10318}", bool_1, "0C", new string[] { "03", "00" });
            if ((c != null) && (c.Length > 0))
            {
                list.AddRange(c);
            }
            if (bool_1)
            {
                return (list.ToArray(typeof(string)) as string[]);
            }
            long num = 0;
            foreach (string str in list)
            {
                num += Class30.smethod_10(str);
            }
            return new string[] { num.ToString() };
        }

        private static void smethod_2(XmlTextWriter xmlTextWriter_0, string string_1)
        {
            if (string_1 != null)
            {
                int index = string_1.IndexOf('\0');
                if (((index > -1) && (string_1.Length > index)) && (string_1[index + 1] == '['))
                {
                    xmlTextWriter_0.WriteStartElement("Instance");
                    xmlTextWriter_0.WriteAttributeString("id", string_1.Substring(0, index));
                    xmlTextWriter_0.WriteAttributeString("details", string_1.Substring(index + 1));
                    xmlTextWriter_0.WriteEndElement();
                }
                else if (index > -1)
                {
                    xmlTextWriter_0.WriteStartElement("Instance");
                    xmlTextWriter_0.WriteAttributeString("id", string_1.Replace('\0', ' '));
                    byte[] inArray = new byte[string_1.Length];
                    for (int i = 0; i < inArray.Length; i++)
                    {
                        inArray[i] = (byte) string_1[i];
                    }
                    xmlTextWriter_0.WriteAttributeString("raw", Convert.ToBase64String(inArray));
                    xmlTextWriter_0.WriteEndElement();
                }
                else
                {
                    xmlTextWriter_0.WriteStartElement("Instance");
                    xmlTextWriter_0.WriteAttributeString("id", string_1);
                    xmlTextWriter_0.WriteEndElement();
                }
            }
        }

        private static StringBuilder smethod_3(string string_1)
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

        private static ArrayList smethod_4(string string_1, out byte[] byte_1)
        {
            byte_1 = null;
            ArrayList list = new ArrayList();
            byte[] array = Class30.smethod_5(smethod_3(string_1).ToString(), "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5");
            byte num = array[1];
            Array.Reverse(array);
            bool flag = (num & 1) != 0;
            list.Add(new int[] { num });
            int num2 = (array[array.Length - 4] & 15) + 1;
            int index = 0;
            if (flag)
            {
                while (index < num2)
                {
                    list.Add(new int[] { array[index] });
                    index++;
                }
            }
            else
            {
                int[] numArray = new int[num2];
                int num4 = 0;
                for (int i = array.Length - (4 + ((int) Math.Ceiling((double) (((double) num2) / 2.0)))); i < (array.Length - 4); i++)
                {
                    byte num6 = array[i];
                    numArray[num4++] = num6 >> 4;
                    if (num4 < numArray.Length)
                    {
                        numArray[num4++] = num6 & 15;
                    }
                }
                for (int j = 0; j < num2; j++)
                {
                    int[] numArray2 = new int[numArray[j]];
                    for (num4 = 0; num4 < numArray[j]; num4++)
                    {
                        numArray2[num4] = array[index++];
                    }
                    list.Add(numArray2);
                }
            }
            int count = array[array.Length - 4] >> 4;
            if (count > 0)
            {
                byte_1 = new byte[count];
                Buffer.BlockCopy(array, array.Length - (4 + count), byte_1, 0, count);
            }
            return list;
        }

        private static string smethod_5()
        {
            return smethod_6(Environment.GetFolderPath(Environment.SpecialFolder.System));
        }

        private static string smethod_6(string string_1)
        {
            string str = null;
            string str2;
            int num;
            int num2;
            string str3 = smethod_9(string_1, out str2);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                str = smethod_8(str3);
                if (str == null)
                {
                    str = smethod_7(str2);
                }
            }
            if (((str != null) && (str.Length != 0)) && !str.StartsWith("VEND:"))
            {
                return str;
            }
            if (!Class21.GetVolumeInformation(str2 + '\\', null, 0, out num, out num2, out num2, null, 0))
            {
                num = new Random().Next(0x7fffffff);
            }
            long num3 = 0;
            long num4 = 0;
            if (OSRecord.ThisMachine.Version.Major >= 5)
            {
                IntPtr ptr = Class21.CreateFile(string.Format(@"\\.\{0}", str2), 0, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
                byte[] buffer = new byte[0x100];
                try
                {
                    int num5 = 0;
                    if (Class21.DeviceIoControl(ptr, 0x70048, IntPtr.Zero, 0, buffer, buffer.Length, ref num5, IntPtr.Zero))
                    {
                        num3 = BitConverter.ToInt64(buffer, 0x10) - 0x1000;
                    }
                }
                finally
                {
                    Class21.CloseHandle(ptr);
                }
            }
            if ((num3 == 0) && !Class21.GetDiskFreeSpaceEx(str2 + '\\', out num4, out num3, out num4))
            {
                num3 = new Random().Next(0x7fffffff);
            }
            return string.Format("{3}{0:X4}-{1:X4}:{2}", new object[] { num >> 0x10, num & 0xffff, num3, str });
        }

        private static string smethod_7(string string_1)
        {
            string str2;
            IntPtr ptr = Class21.CreateFile(string.Format(@"\\.\{0}", string_1), 0, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
            if (ptr.ToInt32() == -1)
            {
                return null;
            }
            try
            {
                byte[] buffer = new byte[12];
                byte[] buffer2 = new byte[0x2710];
                int num = 0;
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    if (!Class21.DeviceIoControl(ptr, 0x2d1400, handle.AddrOfPinnedObject(), 12, buffer2, buffer2.Length, ref num, IntPtr.Zero))
                    {
                        return null;
                    }
                }
                finally
                {
                    handle.Free();
                }
                int num2 = BitConverter.ToInt32(buffer2, 0x18);
                if ((num2 <= num) && (num2 >= 0))
                {
                    string str = smethod_10(buffer2, num2);
                    if ((str != null) && (str.Length != 0))
                    {
                        return str.Trim();
                    }
                    num2 = BitConverter.ToInt32(buffer2, 12);
                    str = null;
                    if (num2 != 0)
                    {
                        str = smethod_11(buffer2, num2).Trim();
                    }
                    num2 = BitConverter.ToInt32(buffer2, 0x10);
                    if (num2 != 0)
                    {
                        str = str + '-' + smethod_11(buffer2, num2).Trim();
                    }
                    num2 = BitConverter.ToInt32(buffer2, 20);
                    if (num2 != 0)
                    {
                        str = str + '.' + smethod_11(buffer2, num2).Trim();
                    }
                    return ("VEND:" + str);
                }
                str2 = null;
            }
            finally
            {
                if (ptr.ToInt32() != -1)
                {
                    Class21.CloseHandle(ptr);
                }
            }
            return str2;
        }

        private static string smethod_8(string string_1)
        {
            string str;
            IntPtr ptr = Class21.CreateFile(string.Format(@"\\.\Scsi{0}:", string_1), 0xc0000000, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
            if (ptr.ToInt32() == -1)
            {
                return null;
            }
            try
            {
                byte[] buffer;
                int num3;
                for (int i = 0; i < 2; i++)
                {
                    buffer = new byte[0x22d];
                    Buffer.BlockCopy(byte_0, 0, buffer, 0, byte_0.Length);
                    GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    int num2 = 0;
                    if (Class21.DeviceIoControl(ptr, 0x4d008, handle.AddrOfPinnedObject(), 60, buffer, buffer.Length, ref num2, IntPtr.Zero))
                    {
                        goto Label_0092;
                    }
                    handle.Free();
                }
                return null;
            Label_0092:
                num3 = 0x40;
                while (num3 < 80)
                {
                    Array.Reverse(buffer, num3, 2);
                    num3 += 2;
                }
                str = Encoding.ASCII.GetString(buffer, 0x40, 0x10);
            }
            finally
            {
                if (ptr.ToInt32() != -1)
                {
                    Class21.CloseHandle(ptr);
                }
            }
            return str;
        }

        private static string smethod_9(string string_1, out string string_2)
        {
            string_2 = null;
            if ((string_1 != null) && (string_1.Length != 0))
            {
                StringBuilder builder = new StringBuilder(0xff);
                string pathRoot = Path.GetPathRoot(string_1);
                string_2 = (pathRoot == string_1) ? pathRoot : pathRoot.Substring(0, pathRoot.Length - 1);
                Class21.QueryDosDevice(string_2, builder, 0xff);
                if (builder.Length > 0)
                {
                    pathRoot = Path.GetDirectoryName(builder.ToString());
                    if (pathRoot == @"\Device")
                    {
                        pathRoot = builder.ToString();
                    }
                    int length = pathRoot.Length;
                    while (length > 0)
                    {
                        if (!char.IsDigit(pathRoot[length - 1]))
                        {
                            break;
                        }
                        length--;
                    }
                    if (length > 0)
                    {
                        return pathRoot.Substring(length);
                    }
                }
            }
            return null;
        }

        public MachineProfileEntryCollection HardwareList
        {
            get
            {
                return this.machineProfileEntryCollection_0;
            }
        }

        public string Hash
        {
            get
            {
                if (this.string_0 == null)
                {
                    this.string_0 = this.GetComparableHash(false, null);
                }
                return this.string_0;
            }
        }

        public static bool IsLaptop
        {
            get
            {
                if (int_6 == 0)
                {
                    int_6 = (!smethod_0() || !smethod_1()) ? -1 : 1;
                }
                return (int_6 == 1);
            }
        }

        public static DeployLX.Licensing.v4.MachineType MachineType
        {
            get
            {
                if (!IsLaptop)
                {
                    return DeployLX.Licensing.v4.MachineType.Desktop;
                }
                return DeployLX.Licensing.v4.MachineType.Laptop;
            }
        }

        public static MachineProfile Profile
        {
            get
            {
                if ((machineProfile_0 == null) && (machineProfile_0 == null))
                {
                    machineProfile_0 = GetDefaultProfile();
                }
                return machineProfile_0;
            }
        }

        public static bool Use64BitCompatibleCpuid
        {
            get
            {
                return bool_0;
            }
            set
            {
                bool_0 = value;
                machineProfile_0 = null;
            }
        }

        public int Version
        {
            get
            {
                return this.int_5;
            }
            set
            {
                //DeployLX.Licensing.v4.Check.GreaterThanEqual(value, 3, "Version");
                //DeployLX.Licensing.v4.Check.LessThanEqual(value, 4, "Version");
                this.int_5 = value;
                this.string_0 = null;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Struct32
        {
            /* private scope */ public string string_0;
            /* private scope */ public string string_1;
            /* private scope */ public string[] string_2;
            /* private scope */ public string string_3;
            /* private scope */ public string string_4;
            /* private scope */ public string string_5;
        }
    }
}

