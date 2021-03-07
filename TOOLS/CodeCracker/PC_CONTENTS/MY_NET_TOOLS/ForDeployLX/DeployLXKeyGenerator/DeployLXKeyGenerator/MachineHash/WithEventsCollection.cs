namespace DeployLX.Licensing.v4
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    [Serializable]
    public abstract class WithEventsCollection : IEnumerable, ICollection, IChange, IList
    {
        [NonSerialized]
        private CollectionEventHandler _added;
        [NonSerialized]
        private CollectionEventHandler _adding;
        [NonSerialized]
        private CollectionEventHandler _changed;
        [NonSerialized]
        private CollectionEventHandler _changing;
        [NonSerialized]
        private ChangeEventHandler _ichanged;
        private bool _isReadOnly;
        private ArrayList _list;
        [NonSerialized]
        private CollectionEventHandler _removed;
        [NonSerialized]
        private CollectionEventHandler _removing;
        private int _suspendEvents;

        public event CollectionEventHandler Added
        {
            add
            {
                lock (this)
                {
                    this._added = (CollectionEventHandler) Delegate.Combine(this._added, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._added = (CollectionEventHandler) Delegate.Remove(this._added, value);
                }
            }
        }

        public event CollectionEventHandler Adding
        {
            add
            {
                lock (this)
                {
                    this._adding = (CollectionEventHandler) Delegate.Combine(this._adding, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._adding = (CollectionEventHandler) Delegate.Remove(this._adding, value);
                }
            }
        }

        public event CollectionEventHandler Changed
        {
            add
            {
                lock (this)
                {
                    this._changed = (CollectionEventHandler) Delegate.Combine(this._changed, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._changed = (CollectionEventHandler) Delegate.Remove(this._changed, value);
                }
            }
        }

        public event CollectionEventHandler Changing
        {
            add
            {
                lock (this)
                {
                    this._changing = (CollectionEventHandler) Delegate.Combine(this._changing, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._changing = (CollectionEventHandler) Delegate.Remove(this._changing, value);
                }
            }
        }

        event ChangeEventHandler IChange.Changed
        {
            add
            {
                lock (this)
                {
                    this._ichanged = (ChangeEventHandler) Delegate.Combine(this._ichanged, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._ichanged = (ChangeEventHandler) Delegate.Remove(this._ichanged, value);
                }
            }
        }

        public event CollectionEventHandler Removed
        {
            add
            {
                lock (this)
                {
                    this._removed = (CollectionEventHandler) Delegate.Combine(this._removed, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._removed = (CollectionEventHandler) Delegate.Remove(this._removed, value);
                }
            }
        }

        public event CollectionEventHandler Removing
        {
            add
            {
                lock (this)
                {
                    this._removing = (CollectionEventHandler) Delegate.Combine(this._removing, value);
                }
            }
            remove
            {
                lock (this)
                {
                    this._removing = (CollectionEventHandler) Delegate.Remove(this._removing, value);
                }
            }
        }

        protected WithEventsCollection()
        {
            this._list = new ArrayList();
        }

        protected WithEventsCollection(WithEventsCollection source)
        {
            //DeployLX.Licensing.v4.Check.NotNull(source, "source");
            this._list = source._list;
            source.Added += new CollectionEventHandler(this.method_5);
            source.Removed += new CollectionEventHandler(this.method_4);
            source.Removing += new CollectionEventHandler(this.method_3);
            source.Adding += new CollectionEventHandler(this.method_2);
            source.Changing += new CollectionEventHandler(this.method_1);
            source.Changed += new CollectionEventHandler(this.method_0);
        }

        public virtual void Clear()
        {
            if (this.Count != 0)
            {
                if (((this._removed == null) && (this._removing == null)) && ((this._changed == null) && (this._changing == null)))
                {
                    this.IList_0.Clear();
                }
                else
                {
                    ArrayList list = new ArrayList(this.IList_0);
                    this.IList_0.Clear();
                    if ((this._removing != null) || (this._changing != null))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            CollectionEventArgs args = new CollectionEventArgs(CollectionChangeAction.Remove, list[i]);
                            this.OnRemoving(args);
                        }
                    }
                    if ((this._removed != null) || (this._changed != null))
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            CollectionEventArgs args2 = new CollectionEventArgs(CollectionChangeAction.Remove, list[j]);
                            this.OnRemoved(args2);
                        }
                    }
                }
            }
        }

        public void MakeReadOnly()
        {
            this.MakeReadOnly(true);
        }

        protected virtual void MakeReadOnly(bool isReadOnly)
        {
            this._isReadOnly = isReadOnly;
            if (isReadOnly)
            {
                foreach (object obj2 in this._list)
                {
                    IChange change = obj2 as IChange;
                    if (change != null)
                    {
                        change.MakeReadOnly();
                    }
                }
            }
        }

        private void method_0(object sender, CollectionEventArgs e)
        {
            this.OnChanged(e);
        }

        private void method_1(object sender, CollectionEventArgs e)
        {
            this.OnChanging(e);
        }

        private void method_2(object sender, CollectionEventArgs e)
        {
            this.OnAdding(e);
        }

        private void method_3(object sender, CollectionEventArgs e)
        {
            this.OnRemoving(e);
        }

        private void method_4(object sender, CollectionEventArgs e)
        {
            this.OnRemoved(e);
        }

        private void method_5(object sender, CollectionEventArgs e)
        {
            this.OnAdded(e);
        }

        protected virtual void OnAdded(CollectionEventArgs collectionEventArgs_0)
        {
            if ((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0))
            {
                if (this._added != null)
                {
                    this._added(this, collectionEventArgs_0);
                }
                this.OnChanged(collectionEventArgs_0);
            }
        }

        protected virtual void OnAdding(CollectionEventArgs collectionEventArgs_0)
        {
            if ((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0))
            {
                if (this._adding != null)
                {
                    this._adding(this, collectionEventArgs_0);
                }
                this.OnChanging(collectionEventArgs_0);
            }
        }

        protected virtual void OnChanged(CollectionEventArgs collectionEventArgs_0)
        {
            if ((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0))
            {
                if (this._changed != null)
                {
                    this._changed(this, collectionEventArgs_0);
                }
                this.OnIChanged(collectionEventArgs_0);
            }
        }

        protected virtual void OnChanging(CollectionEventArgs collectionEventArgs_0)
        {
            if (((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0)) && (this._changing != null))
            {
                this._changing(this, collectionEventArgs_0);
            }
        }

        protected virtual void OnIChanged(CollectionEventArgs collectionEventArgs_0)
        {
            if (((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0)) && (this._ichanged != null))
            {
                this._ichanged(this, new ChangeEventArgs(null, this, collectionEventArgs_0.Element, collectionEventArgs_0.Action));
            }
        }

        protected virtual void OnRemoved(CollectionEventArgs collectionEventArgs_0)
        {
            if ((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0))
            {
                if (this._removed != null)
                {
                    this._removed(this, collectionEventArgs_0);
                }
                this.OnChanged(collectionEventArgs_0);
            }
        }

        protected virtual void OnRemoving(CollectionEventArgs collectionEventArgs_0)
        {
            if ((collectionEventArgs_0.Element != null) && (this._suspendEvents <= 0))
            {
                if (this._removing != null)
                {
                    this._removing(this, collectionEventArgs_0);
                }
                this.OnChanging(collectionEventArgs_0);
            }
        }

        public virtual void RemoveAt(int index)
        {
            object element = null;
            CollectionEventArgs args = null;
            if (((this._removing != null) || (this._removed != null)) || ((this._changed != null) || (this._changing != null)))
            {
                element = this.IList_0[index];
                args = new CollectionEventArgs(CollectionChangeAction.Remove, element);
            }
            if (args != null)
            {
                this.OnRemoving(args);
            }
            this.IList_0.RemoveAt(index);
            if (args != null)
            {
                this.OnRemoved(args);
            }
        }

        public void ResumeEvents()
        {
            this._suspendEvents--;
            if (this._suspendEvents < 0)
            {
                this._suspendEvents = 0;
            }
        }

        public void SuspendEvents()
        {
            this._suspendEvents++;
        }

        void ICollection.CopyTo(Array array, int index)
        {
            this.IList_0.CopyTo(array, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.IList_0.GetEnumerator();
        }

        int IList.Add(object value)
        {
            if (value == null)
            {
                return -1;
            }
            int num = -1;
            CollectionEventArgs args = null;
            if (((this._added != null) || (this._adding != null)) || ((this._changed != null) || (this._changing != null)))
            {
                args = new CollectionEventArgs(CollectionChangeAction.Add, value);
            }
            if (args != null)
            {
                this.OnAdding(args);
                value = args.Element;
            }
            num = this.IList_0.Add(value);
            if (args != null)
            {
                this.OnAdded(args);
            }
            return num;
        }

        bool IList.Contains(object value)
        {
            return this.IList_0.Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return this.IList_0.IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            if (value != null)
            {
                CollectionEventArgs args = null;
                if (((this._adding != null) || (this._added != null)) || ((this._changed != null) || (this._changing != null)))
                {
                    args = new CollectionEventArgs(CollectionChangeAction.Add, value);
                }
                if (args != null)
                {
                    this.OnAdding(args);
                }
                this.IList_0.Insert(index, value);
                if (args != null)
                {
                    this.OnAdded(args);
                }
            }
        }

        void IList.Remove(object value)
        {
            if (value != null)
            {
                CollectionEventArgs args = null;
                if (((this._removing != null) || (this._removed != null)) || ((this._changed != null) || (this._changing != null)))
                {
                    args = new CollectionEventArgs(CollectionChangeAction.Remove, value);
                }
                if (args != null)
                {
                    this.OnRemoving(args);
                    value = args.Element;
                }
                this.IList_0.Remove(value);
                if (args != null)
                {
                    this.OnRemoved(args);
                }
            }
        }

        public virtual int Count
        {
            get
            {
                return this.IList_0.Count;
            }
        }

        public bool EventsSuspended
        {
            get
            {
                return (this._suspendEvents > 0);
            }
        }

        private IList IList_0
        {
            get
            {
                return this._list;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this._isReadOnly;
            }
        }

        protected IList List
        {
            get
            {
                return this;
            }
        }

        public virtual object SyncRoot
        {
            get
            {
                return this.IList_0.SyncRoot;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return this.IList_0.IsSynchronized;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return this.IList_0.IsFixedSize;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.IList_0[index];
            }
            set
            {
                object element = this.IList_0[index];
                CollectionEventArgs args = null;
                if (element != value)
                {
                    args = new CollectionEventArgs(CollectionChangeAction.Remove, element);
                    this.OnRemoving(args);
                }
                CollectionEventArgs args2 = new CollectionEventArgs(CollectionChangeAction.Add, value);
                this.OnAdding(args2);
                this.IList_0[index] = args2.Element;
                if (element != value)
                {
                    this.OnRemoved(args);
                }
                this.OnAdded(args2);
            }
        }
    }
}

