using Microsoft.AspNetCore.Http;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{

	public class SessionDataService
	{
	
		private SessionDataModel _sessionData;

		public SessionDataService( )
		{
	
		}
		

		public SessionDataModel GetSessionData()
		{
			return _sessionData;
		}

		public void SetSessionData(SessionDataModel sessionData)
        {
            _sessionData = sessionData;
        }
	}
}