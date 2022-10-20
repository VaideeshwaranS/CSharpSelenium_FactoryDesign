﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreServices.Performance
{
    public class PerformanceMetrics
    {
        public double TotalTimeforNavigation { get; set; }
        public double DomLoaded { get; set; }
        public double TotalScriptDuration { get; set; }
        public double FirstMeaningfulPaintDuration { get; set; }
        public double TotalTimeTaken { get; set; }
        public double TotalResponseTime { get; set; }
    }
}
