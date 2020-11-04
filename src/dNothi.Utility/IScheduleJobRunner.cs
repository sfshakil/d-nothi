using System;

namespace dNothi.Utility
{
    public interface IScheduleJobRunner
    {
        void RunScheduleJob(Action job, TimeSpan breakTime);
    }
}