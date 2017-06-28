using System;
using System.ComponentModel;
using System.Net.Http;
using System.Web.Http.Tracing;
using log4net;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers.Infastructure.Logging
{
    public class LogWriter : ITraceWriter
    {
        private readonly ILog _log;

        public LogWriter(ILogManager logManager)
        {
            _log = logManager?.GetLog(typeof(LogWriter)) ?? throw new ArgumentNullException(nameof(logManager));
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level,
            Action<TraceRecord> traceAction)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            if (traceAction == null)
                throw new ArgumentNullException(nameof(traceAction));

            if (!Enum.IsDefined(typeof(TraceLevel), level))
                throw new InvalidEnumArgumentException(nameof(level), (int) level, typeof(TraceLevel));

            var record = new TraceRecord(request, category, level);
            traceAction(record);
            WriteToLog(record);
        }

        public void WriteToLog(TraceRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            const string traceFormat =
                "RequestId={0}; Kind={1}; Status={2}; Operation={3}; Operator={4}; Category={5} Request={6} Message={7}";

            var args = new object[]
            {
                record.RequestId,
                record.Kind,
                record.Status,
                record.Operation,
                record.Operator,
                record.Category,
                record.Request,
                record.Message
            };

            switch (record.Level)
            {
                case TraceLevel.Error:
                    _log.ErrorFormat(traceFormat, args);
                    break;
                case TraceLevel.Fatal:
                    _log.FatalFormat(traceFormat, args);
                    break;
            }
        }
    }
}