using System.Reflection;

namespace MethodPerformance
{
    public static class MethodTimeLogger
    {
        public static ILogger Logger;
        public static void Log(MethodBase methodBase,TimeSpan timeSpan,string message)
        {
            Logger.LogTrace("{className}.{Method}: {Duration} {message}",
                    methodBase.DeclaringType!.Name,
                    methodBase.Name,
                    timeSpan,
                    message);
                 
        }
    }
}
