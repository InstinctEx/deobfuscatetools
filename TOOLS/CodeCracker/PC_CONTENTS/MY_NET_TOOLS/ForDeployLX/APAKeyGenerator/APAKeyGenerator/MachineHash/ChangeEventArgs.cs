namespace DeployLX.Licensing.v4
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    public class ChangeEventArgs : EventArgs
    {
        /* private scope */ CollectionChangeAction collectionChangeAction_0;
        /* private scope */ object object_0;
        /* private scope */ object object_1;
        /* private scope */ Stack stack_0;
        /* private scope */ string string_0;

        public ChangeEventArgs(string name, object element)
        {
            this.stack_0 = new Stack();
            this.string_0 = name;
            this.object_0 = element;
        }

        public ChangeEventArgs(string name, object element, object item, CollectionChangeAction action)
        {
            this.stack_0 = new Stack();
            this.string_0 = name;
            this.object_0 = element;
            this.object_1 = item;
            this.collectionChangeAction_0 = action;
        }

        public Stack BubbleStack
        {
            get
            {
                return this.stack_0;
            }
        }

        public CollectionChangeAction CollectionAction
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

        public object CollectionItem
        {
            get
            {
                return this.object_1;
            }
            set
            {
                this.object_1 = value;
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

        public string Name
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}

