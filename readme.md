Q42.Logging.ApplicationInsights
=========

[![Build status](https://ci.appveyor.com/api/projects/status/oquqg1efmr8drhfh/branch/master?svg=true)](https://ci.appveyor.com/project/Q42/q42-logging-applicationinsights/branch/master)

Small library that will send logs to Application Insights when using the default ASP.Net Core 1.0 logging.

Available on [NuGet](https://www.nuget.org/packages/Q42.Logging.ApplicationInsights/)

Usage:
Make sure you've set up ApplicationInsights in your application:

Startup.cs / ConfigureServices:  
`services.AddApplicationInsightsTelemetry(Configuration);`

Add this package to your project.json and use it:
Startup.cs / Configure:  
`loggerFactory.AddApplicationInsights(app.ApplicationServices.GetRequiredService<TelemetryClient>(), LogLevel.Warning);`

### Contributions
Contributions are welcome, just send a PR!

### Credits
This project is based on:
https://github.com/alexvaluyskiy/BookPortal/tree/master/src/BookPortal.Core.Logging

