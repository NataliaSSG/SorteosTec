using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Data;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Models;

namespace TecTrekAPI.Services
{
	public class LeaderboardService : LeaderboardServiceI
	{
        private readonly dbContext _context;
        public LeaderboardService(dbContext context)
        {
            _context = context;
        }
        public async Task<List<LeaderboardModel>> GetLeaderboardAsync()
        {
            return await _context.leaderboard.ToListAsync();
        }
    }
}