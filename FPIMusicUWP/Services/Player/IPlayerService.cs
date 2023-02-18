using FPIMusicUWP.Core.Model;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Player
{
    public interface IPlayerService
    {
        Task AddPrioritizeSongAsync(int id, int songType);
        Task AddSongAsync(int id, int songType);
        Task Next();
        Task Pause();
        Task Play();
        Task PlaySongAsync(int id, int songType);
        Task Previous();
        Task<PlayerListStatus> Status();
        Task Stop();
    }
}