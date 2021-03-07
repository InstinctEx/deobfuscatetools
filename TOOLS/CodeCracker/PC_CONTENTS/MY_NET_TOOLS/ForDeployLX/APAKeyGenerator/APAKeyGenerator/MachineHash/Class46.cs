namespace DeployLX.Licensing.v4
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    internal class Class46 : IDisposable
    {
        /* private scope */ public IntPtr intptr_0 = IntPtr.Zero;

        public Class46()
        {
            if (Class21.bool_1)
            {
                this.method_0();
            }
        }

        public void Dispose()
        {
            if (Class21.bool_1)
            {
                this.method_1();
            }
        }

        private void method_0()
        {
            Class21.Wow64DisableWow64FsRedirection(ref this.intptr_0);
        }

        private void method_1()
        {
            Class21.Wow64RevertWow64FsRedirection(this.intptr_0);
        }

        public static void smethod_0(MethodInvoker methodInvoker_0)
        {
            Class47 class2 = new Class47 {
                methodInvoker_0 = methodInvoker_0,
                exception_0 = null
            };
            new Thread(new ThreadStart(class2.method_0)).Start();
            if (class2.exception_0 != null)
            {
                throw class2.exception_0;
            }
        }

        [CompilerGenerated]
        private sealed class Class47
        {
            /* private scope */ public Exception exception_0;
            /* private scope */ public MethodInvoker methodInvoker_0;

            public void method_0()
            {
                try
                {
                    this.methodInvoker_0();
                }
                catch (Exception exception)
                {
                    this.exception_0 = exception;
                }
            }
        }
    }
}

