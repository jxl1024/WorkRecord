using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkRecord.Common.Log
{
    public class InitRepository
    {
        public static ILoggerRepository LogRepository { get; set; }
    }
}
