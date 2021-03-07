namespace DeployLX.Licensing.v4
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Xml;

    public sealed class OSRecord : IChange
    {
        /* private scope */ bool bool_0;
        /* private scope */ ChangeEventHandler changeEventHandler_0;
        /* private scope */ OSEditions oseditions_0;
        /* private scope */ OSProduct osproduct_0;
        /* private scope */ static OSRecord osrecord_0;
        /* private scope */ string string_0;
        /* private scope */ System.Version version_0;

        public event ChangeEventHandler Changed
        {
            add
            {
                ChangeEventHandler handler2;
                ChangeEventHandler handler = this.changeEventHandler_0;
                do
                {
                    handler2 = handler;
                    ChangeEventHandler handler3 = (ChangeEventHandler) Delegate.Combine(handler2, value);
                    handler = Interlocked.CompareExchange<ChangeEventHandler>(ref this.changeEventHandler_0, handler3, handler2);
                }
                while (handler != handler2);
            }
            remove
            {
                ChangeEventHandler handler2;
                ChangeEventHandler handler = this.changeEventHandler_0;
                do
                {
                    handler2 = handler;
                    ChangeEventHandler handler3 = (ChangeEventHandler) Delegate.Remove(handler2, value);
                    handler = Interlocked.CompareExchange<ChangeEventHandler>(ref this.changeEventHandler_0, handler3, handler2);
                }
                while (handler != handler2);
            }
        }

        void IChange.MakeReadOnly()
        {
            this.bool_0 = true;
        }

        public bool IsMatch(OSRecord record)
        {
            if (((this.osproduct_0 != OSProduct.NotSet) && (record.osproduct_0 != OSProduct.NotSet)) && (this.osproduct_0 != record.osproduct_0))
            {
                return false;
            }
            if ((this.oseditions_0 != OSEditions.NotSet) && (record.oseditions_0 != OSEditions.NotSet))
            {
                bool flag;
                IEnumerator enumerator = Enum.GetValues(typeof(OSEditions)).GetEnumerator();
                //{
                    while (enumerator.MoveNext())
                    {
                        int current = (int) enumerator.Current;
                        OSEditions editions = (OSEditions)((int)(record.oseditions_0) & current);
                        OSEditions editions2 = (OSEditions)((int)(this.oseditions_0) & current);
                        if ((editions != OSEditions.NotSet) && (editions2 == OSEditions.NotSet))
                        {
                            goto Label_0079;
                        }
                    }
                    goto Label_0094;
                Label_0079:
                    flag = false;
                //}
                return flag;
            }
        Label_0094:
            if ((this.version_0 != null) && (record.version_0 != null))
            {
                if (this.version_0.Major != record.version_0.Major)
                {
                    return false;
                }
                if ((record.version_0.Minor > -1) && (this.version_0.Minor != record.version_0.Minor))
                {
                    return false;
                }
                if ((record.version_0.Build > -1) && (this.version_0.Build != record.version_0.Build))
                {
                    return false;
                }
            }
            return ((record.string_0 == null) || ((this.string_0 != null) && (string.Compare(this.string_0, record.string_0, true) == 0)));
        }

        private void method_0(string string_1)
        {
            if (this.changeEventHandler_0 != null)
            {
                this.changeEventHandler_0(this, new ChangeEventArgs(string_1, this));
            }
        }

        private void method_1()
        {
            if (this.bool_0)
            {
                throw new Exception("E_ReadOnlyObject");
            }
        }

        public bool ReadFromXml(XmlReader reader)
        {
            this.osproduct_0 = OSProduct.NotSet;
            this.oseditions_0 = OSEditions.NotSet;
            this.version_0 = null;
            string attribute = reader.GetAttribute("product");
            if (attribute != null)
            {
                this.osproduct_0 = (OSProduct) Toolbox.FastParseInt32(attribute);
            }
            attribute = reader.GetAttribute("edition");
            if (attribute != null)
            {
                this.oseditions_0 = (OSEditions) Toolbox.FastParseInt32(attribute);
            }
            attribute = reader.GetAttribute("version");
            if (attribute != null)
            {
                this.version_0 = new System.Version(attribute);
            }
            this.string_0 = reader.GetAttribute("servicePack");
            reader.Read();
            return true;
        }

        private static OSRecord smethod_0()
        {
            byte[] buffer;
            OSRecord record = new OSRecord {
                version_0 = Environment.OSVersion.Version
            };
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32S:
                    record.osproduct_0 = OSProduct.Windows32s;
                    goto Label_02B5;

                case PlatformID.Win32Windows:
                    record.osproduct_0 = OSProduct.Windows9x;
                    goto Label_02B5;

                case PlatformID.Win32NT:
                {
                    if (record.version_0.Major <= 4)
                    {
                        goto Label_01E7;
                    }
                    buffer = new byte[0x11c];
                    buffer[0] = 0x1c;
                    buffer[1] = 1;
                    GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                    try
                    {
                        if (!Class21.GetVersionEx(handle.AddrOfPinnedObject()))
                        {
                            buffer[0] = 20;
                            buffer[1] = 1;
                            Class21.GetVersionEx(handle.AddrOfPinnedObject());
                        }
                    }
                    finally
                    {
                        handle.Free();
                    }
                    int major = BitConverter.ToInt32(buffer, 4);
                    int minor = BitConverter.ToInt32(buffer, 8);
                    int build = BitConverter.ToInt32(buffer, 12);
                    record.version_0 = new System.Version(major, minor, build);
                    switch (buffer[0x11a])
                    {
                        case 1:
                            record.oseditions_0 |= OSEditions.Workstation;
                            break;

                        case 2:
                            record.oseditions_0 |= OSEditions.DomainController;
                            break;

                        case 3:
                            record.oseditions_0 |= OSEditions.Server;
                            break;
                    }
                    break;
                }
                case PlatformID.WinCE:
                    record.osproduct_0 = OSProduct.WindowsCE;
                    goto Label_02B5;

                default:
                    goto Label_02B5;
            }
            if ((BitConverter.ToInt16(buffer, 280) & 0x200) != 0)
            {
                record.oseditions_0 |= OSEditions.Home;
            }
            else if ((record.oseditions_0 & (OSEditions.DomainController | OSEditions.Server)) == OSEditions.NotSet)
            {
                record.oseditions_0 |= OSEditions.Professional;
            }
            int count = 0x100;
            for (int i = 20; i < 0x114; i += 2)
            {
                if (buffer[i] == 0)
                {
                    count = i - 20;
                    break;
                }
            }
            record.string_0 = Encoding.Unicode.GetString(buffer, 20, count);
            if (Class21.GetSystemMetrics(0x57) != 0)
            {
                record.oseditions_0 |= OSEditions.MediaCenter;
            }
            if (Class21.GetSystemMetrics(0x56) != 0)
            {
                record.oseditions_0 |= OSEditions.TabletPC;
            }
        Label_01E7:
            switch (record.version_0.Major)
            {
                case 3:
                case 4:
                    record.osproduct_0 = OSProduct.WindowsNT;
                    goto Label_02B5;

                case 5:
                    switch (record.Version.Minor)
                    {
                        case 0:
                            record.osproduct_0 = OSProduct.Windows2000;
                            goto Label_02B5;

                        case 1:
                            record.osproduct_0 = OSProduct.WindowsXP;
                            goto Label_02B5;

                        case 2:
                            if ((record.oseditions_0 & OSEditions.Workstation) != OSEditions.NotSet)
                            {
                                record.osproduct_0 = OSProduct.WindowsXP;
                            }
                            else
                            {
                                record.osproduct_0 = OSProduct.Windows2003;
                            }
                            goto Label_02B5;
                    }
                    goto Label_02B5;

                case 6:
                    if (record.Version.Minor != 1)
                    {
                        if ((record.oseditions_0 & OSEditions.Workstation) != OSEditions.NotSet)
                        {
                            record.osproduct_0 = OSProduct.WindowsVista;
                        }
                        else
                        {
                            record.osproduct_0 = OSProduct.Windows2008;
                        }
                    }
                    else
                    {
                        record.osproduct_0 = OSProduct.Windows7;
                    }
                    goto Label_02B5;
            }
        Label_02B5:
            if (IntPtr.Size == 8)
            {
                record.oseditions_0 |= OSEditions.SixtyFourBit;
                return record;
            }
            if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432") != null)
            {
                record.oseditions_0 |= OSEditions.SixtyFourBit;
                return record;
            }
            record.oseditions_0 |= OSEditions.ThirtyTwoBit;
            return record;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(200);
            OSProduct product = this.osproduct_0;
            if (product <= OSProduct.WindowsNT)
            {
                if (product <= OSProduct.WindowsCE)
                {
                    if (product != OSProduct.NotSet)
                    {
                        if (product != OSProduct.WindowsCE)
                        {
                            goto Label_011D;
                        }
                        builder.Append("Windows CE");
                    }
                    else
                    {
                        builder.Append("Unknown OS");
                    }
                    goto Label_0145;
                }
                switch (product)
                {
                    case OSProduct.Windows9x:
                        builder.Append("Windows 9x");
                        goto Label_0145;

                    case OSProduct.WindowsNT:
                        builder.Append("Windows NT");
                        goto Label_0145;

                    case OSProduct.Windows32s:
                        builder.Append("Windows 3.x");
                        goto Label_0145;
                }
            }
            else
            {
                switch (product)
                {
                    case OSProduct.Windows2000:
                        builder.Append("Windows 2000");
                        goto Label_0145;

                    case OSProduct.WindowsXP:
                        builder.Append("Windows XP");
                        goto Label_0145;

                    case OSProduct.Windows2003:
                        builder.Append("Windows 2003");
                        goto Label_0145;

                    case OSProduct.WindowsVista:
                        builder.Append("Windows Vista");
                        goto Label_0145;

                    case OSProduct.Windows2008:
                        builder.Append("Windows 2008");
                        goto Label_0145;

                    case OSProduct.Windows7:
                        builder.Append("Windows 7");
                        goto Label_0145;

                    case OSProduct.Unknown:
                        builder.Append("UNIX");
                        goto Label_0145;
                }
            }
        Label_011D:
            builder.Append("ERROR BAD OS");
        Label_0145:
            if (this.osproduct_0 < OSProduct.WindowsVista)
            {
                if ((this.oseditions_0 & OSEditions.Home) != OSEditions.NotSet)
                {
                    builder.Append(" Home");
                }
                if ((this.oseditions_0 & OSEditions.Professional) != OSEditions.NotSet)
                {
                    builder.Append(" Professional");
                }
                if ((this.oseditions_0 & (OSEditions.DomainController | OSEditions.Server)) != OSEditions.NotSet)
                {
                    builder.Append(" Server");
                }
                if ((this.oseditions_0 & OSEditions.TabletPC) != OSEditions.NotSet)
                {
                    builder.Append(" Tablet PC");
                }
                if ((this.oseditions_0 & OSEditions.MediaCenter) != OSEditions.NotSet)
                {
                    builder.Append(" Media Center");
                }
            }
            if ((this.oseditions_0 & (OSEditions.DomainController | OSEditions.Server)) != OSEditions.NotSet)
            {
                builder.Append(" Server");
            }
            if ((this.oseditions_0 & OSEditions.ThirtyTwoBit) != OSEditions.NotSet)
            {
                builder.Append(" 32-bit");
            }
            if ((this.oseditions_0 & OSEditions.SixtyFourBit) != OSEditions.NotSet)
            {
                builder.Append(" 64-bit");
            }
            if ((this.string_0 != null) && (this.string_0.Length > 0))
            {
                builder.Append(' ');
                builder.Append(this.string_0);
            }
            if ((this.version_0 != null) && (this.version_0.Major > 0))
            {
                builder.Append(" [");
                builder.Append(this.version_0.Major);
                if (this.version_0.Minor > -1)
                {
                    builder.Append('.');
                    builder.Append(this.version_0.Minor);
                    if (this.version_0.Build > -1)
                    {
                        builder.Append(" Build ");
                        builder.Append(this.version_0.Build);
                    }
                }
                builder.Append(']');
            }
            return builder.ToString();
        }

        public bool WriteToXml(XmlWriter writer)
        {
            writer.WriteStartElement("OSRecord");
            if (this.osproduct_0 != OSProduct.NotSet)
            {
                writer.WriteAttributeString("product", ((int) this.osproduct_0).ToString());
            }
            if (this.oseditions_0 != OSEditions.NotSet)
            {
                writer.WriteAttributeString("edition", ((int) this.oseditions_0).ToString());
            }
            if ((this.version_0 != null) && (this.version_0.Major > 0))
            {
                writer.WriteAttributeString("version", this.version_0.ToString());
            }
            if ((this.string_0 != null) && (this.string_0.Length > 0))
            {
                writer.WriteAttributeString("servicePack", this.string_0);
            }
            writer.WriteEndElement();
            return true;
        }

        public OSEditions Edition
        {
            get
            {
                return this.oseditions_0;
            }
            set
            {
                this.method_1();
                if (this.oseditions_0 != value)
                {
                    this.oseditions_0 = value;
                    this.method_0("Edition");
                }
            }
        }

        public OSProduct Product
        {
            get
            {
                return this.osproduct_0;
            }
            set
            {
                this.method_1();
                if (this.osproduct_0 != value)
                {
                    this.osproduct_0 = value;
                    this.method_0("Product");
                }
            }
        }

        public string ServicePack
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.method_1();
                if (this.string_0 != value)
                {
                    this.string_0 = value;
                    this.method_0("ServicePack");
                }
            }
        }

        public static OSRecord ThisMachine
        {
            get
            {
                if (osrecord_0 == null)
                {
                    //lock (SecureLicenseManager.SyncRoot)
                    //{
                        if (osrecord_0 == null)
                        {
                            osrecord_0 = smethod_0();
                        }
                    //}
                }
                return osrecord_0;
            }
        }

        public System.Version Version
        {
            get
            {
                return this.version_0;
            }
            set
            {
                this.method_1();
                if (this.version_0 != value)
                {
                    this.version_0 = value;
                    this.method_0("Version");
                }
            }
        }
    }
}

