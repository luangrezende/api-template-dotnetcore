using Template.Project.Util.Logs.Interfaces;
using Microsoft.Extensions.Logging;
using Template.Project.Util.Enum;
using System;

namespace Template.Project.Util.Logs
{
    public class LoggerService : ILoggerService
    {
        private readonly EventId _eventIdInfo;
        private readonly EventId _eventIdError;

        public LoggerService()
        {
            _eventIdInfo = new EventId((int)TemplateEnum.UserCreate, TemplateEnum.UserCreate.ToString());
            _eventIdError = new EventId((int)TemplateEnum.UserError, TemplateEnum.UserError.ToString());
        }

        public void LogInformation(ILogger _logger, object args, string message)
        {
            _logger.LogInformation(_eventIdInfo, message, args);
        }

        public void LogError(ILogger _logger, object args, Exception exception, string message)
        {
            _logger.LogError(_eventIdError, exception, message, args);
        }
    }
}
