using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
	public class TecTrekWebApplicationFactory<TStartup>:WebApplicationFactory<TStartup> where TStartup: class
	{
		public TecTrekWebApplicationFactory()
		{
		}
	}
}

