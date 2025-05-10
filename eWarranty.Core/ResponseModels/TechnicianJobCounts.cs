using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class TechnicianJobCounts
    {
        public int TodaysJobs { get; set; }
        public int UnattendedJobs { get; set; }
        public int FutureScheduleJobs { get; set; }
        public int PendingJobs { get; set; }
        public int ClosedJobs { get; set; }
        public int InProgressJobs { get; set; }
    }
}
