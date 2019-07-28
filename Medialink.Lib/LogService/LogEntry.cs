using System;

namespace MediaLink.Lib.LogService
{
    public class LogEntry
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int A { get; set; }

        public int B { get; set; }

        public int Result { get; set; }

        public DateTime DateTime { get; set; }
    }
}
