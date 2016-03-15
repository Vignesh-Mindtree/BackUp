﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLogging
{
    public class NLogConfig
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public bool KeepFileOpen { get; set; }
        public bool CreateDirectory { get; set; }
        public bool ArchiveOldFileOnStartup { get; set; }
        public bool ConcurrentWrites { get; set; }
        public string Level { get; set; }
        public string Layout { get; set; }
    }
}
