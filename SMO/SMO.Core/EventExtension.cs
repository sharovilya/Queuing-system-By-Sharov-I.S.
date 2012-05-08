using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO.Core
{
    public static class EventExtension
    {
        public static void Raise<TArgs>(this EventHandler<TArgs> @event, object @this, TArgs e) where TArgs : EventArgs
        {
            var handler = @event;
            if (handler != null)
            {
                handler(@this, e);
            }
        }
    }
}
