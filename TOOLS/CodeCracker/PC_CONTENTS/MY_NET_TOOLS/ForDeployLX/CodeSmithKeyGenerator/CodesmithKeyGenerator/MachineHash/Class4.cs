namespace DeployLX.Licensing.v4
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    internal abstract class Class4
    {
        /* private scope */ bool bool_0;
        /* private scope */ ManualResetEvent manualResetEvent_0 = new ManualResetEvent(false);

        protected Class4()
        {
        }

        public void method_0()
        {
            Thread thread = new Thread(new ThreadStart(this.method_2));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Name = this.ToString();
            thread.Start();
        }

        public void method_1()
        {
            this.method_0();
            this.manualResetEvent_0.WaitOne();
        }

        private void method_2()
        {
            try
            {
                this.vmethod_0();
            }
            catch (Exception exception)
            {
                if (this.bool_0)
                {
                    throw;
                }
                try
                {
                    Thread.Sleep(0x3e8);
                    this.vmethod_0();
                }
                catch
                {
                	MessageBox.Show(exception.ToString());
                }
            }
            finally
            {
                this.manualResetEvent_0.Set();
            }
        }

        protected abstract void vmethod_0();

        public bool Boolean_0
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }
    }
}

