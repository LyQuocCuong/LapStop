﻿namespace Contracts.Utilities.Logger
{
    public interface ILogService
    {
        void LogDebug(string message);
        void LogError(string message);
        void LogWarn(string message);
        void LogInfo(string message);
    }
}
