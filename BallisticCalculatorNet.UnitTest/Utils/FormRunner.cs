using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    internal class FormRunner
    {
        private readonly Thread mThread;
        private readonly ManualResetEvent mStarted = new ManualResetEvent(false);
        private readonly ManualResetEvent mStopped = new ManualResetEvent(false);
        private Exception mException;

        public FormRunner(Form formToRun)
        {
            mThread = new Thread(() =>
            {
                formToRun.Load += (sender, args) =>
                {
                    mStarted.Set();
                };

                try
                {
                    Application.Run(new ApplicationContext(formToRun));
                }
                catch (Exception e)
                {
                    mException = e;
                }
                finally
                {
                    mStopped.Set();
                }
            });
        }

        public void Start()
        {
            mThread.Start();
            mStarted.WaitOne();
            mStarted.Reset();
        }

        public bool Join(TimeSpan timeout)
        {
            bool rc = mStopped.WaitOne(timeout);
            mStopped.Reset();
            return rc;
        }

        public bool IsAlive => mThread.IsAlive;

        public Exception Exception => mException;
    }
}

