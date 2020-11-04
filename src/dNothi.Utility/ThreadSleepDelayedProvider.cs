using System;
using System.Threading;

namespace dNothi.Utility
{
    public class ThreadSleepDelayedProvider<T> : IDelayedProvider<T>
    {
        private readonly TimeSpan _initialSleepTime;
        private readonly TimeSpan _maximumSleepTime;

        public ThreadSleepDelayedProvider(TimeSpan initialSleepTime, TimeSpan maximumSleepTime)
        {
            _initialSleepTime = initialSleepTime;
            _maximumSleepTime = maximumSleepTime;
        }

        public T Get(Func<T> get, Predicate<T> verify)
        {
            for (var sleepTime = _initialSleepTime; sleepTime < _maximumSleepTime; sleepTime = sleepTime + sleepTime)
            {
                var obj = get();

                if (verify(obj))
                    return obj;

                Thread.Sleep(sleepTime);
            }

            throw new Exception("Object is not verified for long time");
        }
    }
}