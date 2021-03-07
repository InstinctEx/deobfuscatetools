namespace DeployLX.Licensing.v4
{
    using System;
    using System.Threading;
    using System.Xml;

    [Serializable]
    public sealed class MachineProfileEntry : ICloneable, IChange
    {
        private string _displayName;
        private Interface1 _entryMaker;
        private int _fileMovedWeight;
        private bool _isReadOnly;
        private int _partialMatchWeight;
        private MachineProfileEntryType _type;
        private int _weight;
        private ChangeEventHandler changed;

        public event ChangeEventHandler Changed
        {
            add
            {
                ChangeEventHandler handler2;
                ChangeEventHandler changed = this.changed;
                do
                {
                    handler2 = changed;
                    ChangeEventHandler handler3 = (ChangeEventHandler) Delegate.Combine(handler2, value);
                    changed = Interlocked.CompareExchange<ChangeEventHandler>(ref this.changed, handler3, handler2);
                }
                while (changed != handler2);
            }
            remove
            {
                ChangeEventHandler handler2;
                ChangeEventHandler changed = this.changed;
                do
                {
                    handler2 = changed;
                    ChangeEventHandler handler3 = (ChangeEventHandler) Delegate.Remove(handler2, value);
                    changed = Interlocked.CompareExchange<ChangeEventHandler>(ref this.changed, handler3, handler2);
                }
                while (changed != handler2);
            }
        }

        public MachineProfileEntry()
        {
            this._weight = 2;
            this._partialMatchWeight = -1;
            this._fileMovedWeight = -1;
        }

        public MachineProfileEntry(MachineProfileEntryType type, int weight, int partialWeight, int fileMovedWeight)
        {
            this._weight = 2;
            this._partialMatchWeight = -1;
            this._fileMovedWeight = -1;
            this._type = type;
            this._weight = weight;
            this._partialMatchWeight = partialWeight;
            this._fileMovedWeight = fileMovedWeight;
        }

        public void MakeReadOnly()
        {
            this._isReadOnly = true;
        }

        private void method_0(ChangeEventArgs changeEventArgs_0)
        {
            //if (this.Changed != null)
            //{
            //    this.Changed(this, changeEventArgs_0);
            //}
        }

        private void method_1()
        {
            if (this._isReadOnly)
            {
                throw new Exception("E_ReadOnlyObject");
            }
        }

        public bool ReadFromXml(XmlReader reader)
        {
            //DeployLX.Licensing.v4.Check.NotNull(reader, "reader");
            string attribute = reader.GetAttribute("type");
            if (attribute == null)
            {
                return false;
            }
            this._type = (MachineProfileEntryType) Toolbox.FastParseInt32(attribute);
            attribute = reader.GetAttribute("weight");
            if (attribute != null)
            {
                this._weight = Toolbox.FastParseInt32(attribute);
            }
            else
            {
                this._weight = 1;
            }
            attribute = reader.GetAttribute("partialWeight");
            if (attribute != null)
            {
                this._partialMatchWeight = Toolbox.FastParseInt32(attribute);
            }
            else
            {
                this._partialMatchWeight = -1;
            }
            attribute = reader.GetAttribute("movedWeight");
            if (attribute != null)
            {
                this._fileMovedWeight = Toolbox.FastParseInt32(attribute);
            }
            else
            {
                this._fileMovedWeight = -1;
            }
            this._displayName = reader.GetAttribute("displayName");
            attribute = reader.GetAttribute("entryMaker");
            if (attribute != null)
            {
                System.Type type = TypeHelper.FindType(attribute, true);
                this._entryMaker = Activator.CreateInstance(type) as Interface1;
            }
            reader.Read();
            return true;
        }

        object ICloneable.Clone()
        {
            return base.MemberwiseClone();
        }

        public override string ToString()
        {
            return this.DisplayName;
        }

        public void WriteToXml(XmlWriter writer)
        {
            //DeployLX.Licensing.v4.Check.NotNull(writer, "writer");
            writer.WriteStartElement("Entry");
            writer.WriteAttributeString("type", ((int) this._type).ToString());
            writer.WriteAttributeString("weight", this._weight.ToString());
            if ((this._partialMatchWeight != -1) && (this._partialMatchWeight != this._weight))
            {
                writer.WriteAttributeString("partialWeight", this._partialMatchWeight.ToString());
            }
            if ((this._fileMovedWeight != -1) && (this._fileMovedWeight != this._weight))
            {
                writer.WriteAttributeString("movedWeight", this._fileMovedWeight.ToString());
            }
            if (this._displayName != null)
            {
                writer.WriteAttributeString("displayName", this._displayName);
            }
            if (this._entryMaker != null)
            {
                writer.WriteAttributeString("entryMaker", this._entryMaker.GetType().AssemblyQualifiedName);
            }
            writer.WriteEndElement();
        }

        public string DisplayName
        {
            get
            {
                if (this._displayName == null)
                {
                    return this._type.ToString();
                }
                return this._displayName;
            }
            set
            {
                this.method_1();
                if (this._displayName != value)
                {
                    this._displayName = value;
                    this.method_0(new ChangeEventArgs("DisplayName", this));
                }
            }
        }

        public int FileMovedWeight
        {
            get
            {
                if (this._fileMovedWeight != -1)
                {
                    return this._fileMovedWeight;
                }
                return this._weight;
            }
            set
            {
                this._fileMovedWeight = value;
            }
        }

        internal Interface1 Interface1_0
        {
            get
            {
                return this._entryMaker;
            }
            set
            {
                this.method_1();
                if (this._entryMaker != null)
                {
                    throw new Exception("E_ReadOnlyObject");
                }
                if (this._entryMaker != value)
                {
                    this._entryMaker = value;
                    this.method_0(new ChangeEventArgs("EntryMaker", this));
                }
            }
        }

        public int PartialMatchWeight
        {
            get
            {
                if (this._partialMatchWeight != -1)
                {
                    return this._partialMatchWeight;
                }
                return this._weight;
            }
            set
            {
                this.method_1();
                if (this._partialMatchWeight != value)
                {
                    this._partialMatchWeight = value;
                    this.method_0(new ChangeEventArgs("PartialMatchWeight", this));
                }
            }
        }

        public MachineProfileEntryType Type
        {
            get
            {
                return this._type;
            }
        }

        public int Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this.method_1();
                if (this._weight != value)
                {
                    this._weight = value;
                    this.method_0(new ChangeEventArgs("Weight", this));
                }
            }
        }
    }
}

