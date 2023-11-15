using System;
using Microsoft.AspNetCore.Builder;

namespace Tests.APITests.Data
{
	public class dbContextTest
	{
		private readonly TecTrekWebApplicationFactory<Startup> _factory;
		public dbContextTest()
		{
		}
	}
}