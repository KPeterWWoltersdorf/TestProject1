using System.Threading;

namespace TestProject1
{
    internal static class SlowDownTime
    {
        public static void Pause(int secondsToWait = 3000)
        {
            Thread.Sleep(secondsToWait);
        }
    }
}
