namespace DeployLX.Licensing.v4
{
    using System;
    using System.ComponentModel;

    public class CollectionEventArgs : EventArgs
    {
        /* private scope */ CollectionChangeAction collectionChangeAction_0;
        /* private scope */ object object_0;

        public CollectionEventArgs()
        {
        }

        public CollectionEventArgs(CollectionChangeAction action, object element)
        {
            this.object_0 = element;
            this.collectionChangeAction_0 = action;
        }

        public CollectionChangeAction Action
        {
            get
            {
                return this.collectionChangeAction_0;
            }
            set
            {
                this.collectionChangeAction_0 = value;
            }
        }

        public object Element
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
            }
        }
    }
}

