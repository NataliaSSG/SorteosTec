using System.Collections.Generic;
using System.Threading.Tasks;
using TecTrekAPI.Models;

namespace TecTrekAPI.Interfaces
{
    public interface LeaderboardServiceI
    {
        Task<List<LeaderboardModel>> GetLeaderboardAsync();
    }
}