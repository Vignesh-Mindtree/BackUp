using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using System.Text;

namespace NLogging
{
    [LayoutRenderer("ApplicationName")]
    public class ApplicationNameLayoutRenderer : LayoutRenderer
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name+Name1+Name2);
        }
    }

    [LayoutRenderer("HostAddress")]
    public class HostAddressLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1]);
        }        
    }
}
