# Measure time for each method

1. Install the Nuget Package MethodTimer.Fody
1. In the method you want to measure, decorate the method with [Time] attribute
1. The Trace log will display the milliseconds it tool for the each method you have decorated.
1. To use it with ILogger, create a Static class MethodTimeLogger and write a static method for log.
1. Change the appsettings LogLevel to Trace.
