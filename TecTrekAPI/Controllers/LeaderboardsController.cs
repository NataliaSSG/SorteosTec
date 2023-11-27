using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[Route("/api/leaderboard")]
    [ApiController]
    public class Leaderboard : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        // Fix the constructor name to match the class name
        public Leaderboard(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaderboardModel>>> GetLeaderboards()
        {
            return await _leaderboardService.GetLeaderboardAsync();
        }
    }

}