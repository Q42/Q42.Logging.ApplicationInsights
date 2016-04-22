using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q42.Logging.ApplicationInsights
{
	/// <summary>
	/// Based on: https://github.com/alexvaluyskiy/BookPortal/tree/master/src/BookPortal.Core.Logging
	/// </summary>
	public class ApplicationInsightsLogger : ILogger
	{
		private readonly TelemetryClient _telemetryClient;
		private readonly LogLevel _minLogLevel;

		public ApplicationInsightsLogger(TelemetryClient telemetryClient, LogLevel minLevel)
		{
			_telemetryClient = telemetryClient;
			_minLogLevel = minLevel;
		}

		public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
		{
			if (!IsEnabled(logLevel))
			{
				return;
			}

			var message = string.Empty;
			if (state != null)
			{
				message += state;
			}
			if (exception != null)
			{
				message += Environment.NewLine + exception;
			}

			if (!string.IsNullOrEmpty(message))
			{
				_telemetryClient.TrackTrace(message, ConvertSeverityLevel(logLevel), new Dictionary<string, string> { { "EventId", eventId.ToString() }});
			}
		}

		private SeverityLevel ConvertSeverityLevel(LogLevel logLevel)
		{
			SeverityLevel level;
			switch (logLevel)
			{
				case LogLevel.Critical:
					level = SeverityLevel.Critical;
					break;
				case LogLevel.Error:
					level = SeverityLevel.Error;
					break;
				case LogLevel.Warning:
					level = SeverityLevel.Warning;
					break;
				case LogLevel.Information:
					level = SeverityLevel.Information;
					break;
				default:
					level = SeverityLevel.Verbose;
					break;
			}

			return level;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel >= _minLogLevel;
		}

		public IDisposable BeginScopeImpl(object state)
		{
			return null;
		}
	}
}