using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.IO;
using Log4U.Core.IO.Interfaces;
using Log4U.Core.Layouts.Interfaces;
using Log4U.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4U.Core.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
            LogFile = logFile;
        }

        public ILayout Layout { get; }

        public ILogFile LogFile { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            string content = string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

            LogFile.WriteLine(content);

            File.AppendAllText(LogFile.FullPath, content + Environment.NewLine);

            MessagesAppended++;
        }
    }
}
