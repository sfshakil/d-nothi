using System;

namespace dNothi.Utility
{
  public interface IDelayedProvider<T>
  {
    T Get(Func<T> get, Predicate<T> verify);
  }
}