using Log4U.Core.Appenders;
using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.IO;
using Log4U.Core.IO.Interfaces;
using Log4U.Core.Layouts;
using Log4U.Core.Layouts.Interfaces;
using Log4U.Core.Loggers;
using Log4U.Core.Loggers.Interfaces;
using Log4U.Core.Utils;

ILayout simpleLayout = new SimpleLayout();

IAppender appender = new ConsoleAppender(simpleLayout);

ILogger logger = new Logger(appender);

DateTimeValidator.AddFormat("M-dd-yyyy h:mm:ss tt");

logger.Info("3-26-2015 2:08:11 PM", "User Pesho successfully registered.");

ILogFile file = new LogFile();
var fileAppender = new FileAppender(simpleLayout, file, ReportLevel.Info);