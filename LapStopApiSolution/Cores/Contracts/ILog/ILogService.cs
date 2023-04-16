using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ILog
{
    public interface ILogService
    {
        void LogDebug (string message);
        void LogError (string message);
        void LogWarn (string message);
        void LogInfo (string message);
    }
}
