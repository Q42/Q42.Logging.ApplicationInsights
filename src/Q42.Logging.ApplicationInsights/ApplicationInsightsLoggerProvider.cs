using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using Q42.Logging.ApplicationInsights;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q42.Logging.ApplicationInsights
{
	/// <summary>
	/// Based on: https://github.com/alexvaluyskiy/BookPortal/tree/master/src/BookPortal.Core.Logging
	/// </summary>
	public class ApplicationInsightsLoggerProvider : ILoggerProvider
	{
		private readonly TelemetryClient _telemetryClient;
		private readonly LogLevel _minLevel;

		public ApplicationInsightsLoggerProvider(TelemetryClient telemetryClient, LogLevel minLevel)
		{
			_telemetryClient = telemetryClient;
			_minLevel = minLevel;
		}

		public ILogger CreateLogger(string name)
		{
			return new ApplicationInsightsLogger(_telemetryClient, _minLevel);
		}

		public void Dispose()
		{

		}

	}
}
