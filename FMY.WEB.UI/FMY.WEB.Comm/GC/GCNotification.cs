using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FMY.WEB.Comm.GCHelper
{
    /*
     * GCNotification类在第0代和第2代回收时引发一个事件。
     * 可以利用该事件再发生一次回收时响铃，计算两次回收的时间间隔，计算两次回收之间分配了多少内存等。
     * 可以利用这个类方便地检测应用程序，更好的理解应用程序内存使用情况。
     */
    public class GCNotification
    {
        private static Action<Int32> s_gcDone = null;

        public static event Action<Int32> GCDone
        {
            add
            {
                if (s_gcDone == null)
                {
                    new GenObject(0);
                    new GenObject(2);
                }
            }
            remove { s_gcDone -= value; }
        }
         
        private sealed class GenObject
        {
            private Int32 m_generation;

            public GenObject(Int32 generation)
            {
                m_generation = generation;
            }

            ~GenObject()
            {
                if (GC.GetGeneration(this) >= m_generation)
                {
                    Action<Int32> temp = Volatile.Read(ref s_gcDone);
                    if (temp != null) temp(m_generation);
                }

                if ((s_gcDone != null)
                    && !AppDomain.CurrentDomain.IsFinalizingForUnload()
                    && !Environment.HasShutdownStarted)
                {
                    if (m_generation == 0) new GenObject(0);
                    else GC.ReRegisterForFinalize(this);
                }
                else
                {
                    //让对象释放
                }
            }
        }
    }
}
