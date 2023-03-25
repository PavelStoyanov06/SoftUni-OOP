using Log4U.Core.Enums;
using Log4U.Core.Layouts.Interfaces;
using Log4U.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4U.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get; }

        void AppendMessage(IMessage message);
    }
}
