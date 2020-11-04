using System;
using System.Threading;

namespace dNothi.Utility
{
    public class ThreadSleepScheduleJobRunner : IScheduleJobRunner
    {
        public void RunScheduleJob(Action job, TimeSpan breakTime)
        {
            var runnerThread = new Thread(() =>
              {
                  while (true)
                  {
                      Thread.Sleep(breakTime);
                      job?.Invoke();
                  }
              }
            );
            runnerThread.Start();
        }
    }
}