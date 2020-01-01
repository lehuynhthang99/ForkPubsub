using System;
using SuperMaxim.Core.WeakRef;

namespace SuperMaxim.Core.Threading
{
    public class DispatcherTask : IDisposable
    {
        public WeakRefDelegate Action 
        {
            get; private set;
        }

        public object[] Payload
        {
            get; private set;
        }

        public DispatcherTask(Delegate action, object[] payload)
        {
            Action = new WeakRefDelegate(action);
            Payload = payload;
        }

        public void Invoke()
        {
            if(Action == null || !Action.IsAlive)
            {
                return;
            }
            Action.Invoke(Payload);            
        }

        public void Dispose()
        {
            if(Action != null)
            {
                Action.Dispose();
                Action = null;
            }
            Payload = null;            
        }
    }    
}