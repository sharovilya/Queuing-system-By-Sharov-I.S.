using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMO.Core;

namespace SMO.UI.Views
{
    public class GeneratorView
    {
        private ISystemGenerator generator;
        private ISystemClock clock;

        public GeneratorView(ISystemGenerator generator, ISystemClock clock)
        {
            this.generator = generator;

            clock.TickEvent += clock_TickEvent;
        }

        void clock_TickEvent(object sender, EventArgs e)
        {
            
        }
    }
}
