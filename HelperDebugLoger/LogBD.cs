using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogStandert;
using str = System.String;

namespace LogStandertBD
{
    public class LogBD
    {
        public static Dictionary<string, LOG> Logs { get; }

        static LogBD() { Logs = new Dictionary<str, LOG>(); }

        public void Create(LOG log) => Logs.Add(log.Key, log);
        public void Create(str type, str header, str text_Stack)
        {
            var createLog = new CreateLog(type, header, text_Stack);
            var log = createLog.Log;

            Logs.Add(log.Key, log);
        }

        public void Delite(LOG log) => Delite(log.Name, log.Key);
        public void Delite(str Name, str Key)
        {

        }
    }
}
