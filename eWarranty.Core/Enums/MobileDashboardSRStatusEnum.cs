using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public enum MobileDashboardSRStatusEnum
    {
        TodaysJobs = 1,
        UnattendedJobs = 2,
        FutureScheduleJobs = 3,
        PendingJobs = 4,
        CompletedJobs = 5,
        InProgressJob = 6
    }
}
