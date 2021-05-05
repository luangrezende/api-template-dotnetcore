using Microsoft.Extensions.Logging;
using System;

namespace Template.Project.Util.Logs.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(ILogger _logger, object args, string message);

        void LogError(ILogger _logger, object args, Exception exception, string message);
    }
}
