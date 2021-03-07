namespace DeployLX.Licensing.v4
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public sealed class MachineProfileEntryCollection : WithEventsCollection
    {
        public int Add(MachineProfileEntry item)
        {
            return base.List.Add(item);
        }

        public void AddRange(MachineProfileEntry[] items)
        {
            if (items != null)
            {
                foreach (MachineProfileEntry entry in items)
                {
                    this.Add(entry);
                }
            }
        }

        public void AddRange(MachineProfileEntryCollection items)
        {
            if (items != null)
            {
                foreach (MachineProfileEntry entry in (IEnumerable) items)
                {
                    this.Add(entry);
                }
            }
        }

        public bool Contains(MachineProfileEntry item)
        {
            return base.List.Contains(item);
        }

        public void CopyTo(MachineProfileEntry[] array, int index)
        {
            base.List.CopyTo(array, index);
        }

        public int IndexOf(MachineProfileEntry item)
        {
            return base.List.IndexOf(item);
        }

        public void Insert(int index, MachineProfileEntry item)
        {
            base.List.Insert(index, item);
        }

        protected override void MakeReadOnly(bool isReadOnly)
        {
            base.MakeReadOnly(isReadOnly);
        }

        public void Remove(MachineProfileEntry item)
        {
            base.List.Remove(item);
        }

        public MachineProfileEntry this[int index]
        {
            get
            {
                return (base.List[index] as MachineProfileEntry);
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

