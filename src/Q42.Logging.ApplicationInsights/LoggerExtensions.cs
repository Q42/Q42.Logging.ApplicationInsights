using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;

namespace Q42.Logging.ApplicationInsights
{
	/// <summary>
	/// Based on: https://github.com/alexvaluyskiy/BookPortal/tree/master/src/BookPortal.Core.Logging
	/// </summary>
	public static class LoggerExtensions
    {
		public static ILoggerFactory AddApplicationInsights(
			this ILoggerFactory factory,
			TelemetryClient telemetryClient,
			LogLevel minLevel)
		{
			factory.AddProvider(new ApplicationInsightsLoggerProvider(telemetryClient, minLevel));
			return factory;
		}

	}
}
