Q42.Logging.ApplicationInsights
=========

Small library that will send logs to Application Insights when using the default ASP.Net Core 1.0 logging.

Usage:
Make sure you've set up ApplicationInsights in your application:

Startup.cs / ConfigureServices:  
`services.AddApplicationInsightsTelemetry(Configuration);`

Add this package to your project.json and use it:
Startup.cs / Configure:  
`loggerFactory.AddApplicationInsights(app.ApplicationServices.GetRequiredService<TelemetryClient>(), LogLevel.Warning);`


### Credits
This project is based on:
https://github.com/alexvaluyskiy/BookPortal/tree/master/src/BookPortal.Core.Logging

