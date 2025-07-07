// <copyright file="ServiceLoggerCollectionTests.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using PRUEBA_SODIMAC.Logger;
using PRUEBA_SODIMAC.Logger.Models;

using Serilog.Extensions.Logging;

namespace PRUEBA_SODIMAC.UnitTests.Logger
{
	public class ServiceLoggerCollectionTests
	{
		[Fact]
		public void AddLogger_ShouldConfigureLoggerWithDefaultSettings()
		{
			// Arrange
			var services = new ServiceCollection();
			var setupAction = new LoggerOptions();

			// Act
			var result = services.AddLogger(setupAction);

			// Assert
			Assert.Same(setupAction, result);
			var serviceProvider = services.BuildServiceProvider();
			var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
			var logger = loggerFactory?.CreateLogger("Test");
			Assert.NotNull(logger);
			Assert.IsType<SerilogLoggerFactory>(loggerFactory);
		}

		[Fact]
		public void AddLogger_ShouldConfigureLoggerWithCustomProperties()
		{
			// Arrange
			var services = new ServiceCollection();
			var setupAction = new LoggerOptions();
			var customProperties = new Dictionary<string, object>
			{
				{ "CustomProperty1", "Value1" },
				{ "CustomProperty2", 123 }
			};

			// Act
			var result = services.AddLogger(setupAction, customProperties);

			// Assert
			Assert.Same(setupAction, result);
			var serviceProvider = services.BuildServiceProvider();
			var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
			var logger = loggerFactory?.CreateLogger("Test");
			Assert.NotNull(logger);
			Assert.IsType<SerilogLoggerFactory>(loggerFactory);
		}
		[Fact]
		public void IncludeProperty_ShouldAddPropertyToLoggerConfiguration()
		{
			// Arrange
			var services = new ServiceCollection();
			var setupAction = new LoggerOptions();
			services.AddLogger(setupAction);
			var serviceProvider = services.BuildServiceProvider();
			var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
			var logger = loggerFactory?.CreateLogger("Test");

			// Act
			setupAction.IncludeProperty("TestProperty", "TestValue");

			// Assert
			Assert.NotNull(logger);
			Assert.IsType<SerilogLoggerFactory>(loggerFactory);
		}
	}

}
