using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCParentConsole.Interfaces
{
    public interface ILoggerClass
    {
        void CreateNewEventViewerLog();
        void WriteLoginToEventViewer();
        void WriteTransactionToEventViewer(string transaction);
        void WriteExceptionToEventViewer(string exception);
        void WriteLogoffToEventViewer();
    }
}
