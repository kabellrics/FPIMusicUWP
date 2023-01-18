using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer.Interface
{
    public interface IDeezerPlaylistService
    {
        Task<IEnumerable<GroupedDeezerExtendedPlaylist>> GroupedPlaylists();
        Task<IEnumerable<DeezerExtendedPlaylist>> Playlists();
        Task<DeezerExtendedPlaylist> Playlist(int id);
        Task<IEnumerable<DeezerExtendedPlaylist>> Playlist(string name);
        Task Playlist(DeezerExtendedPlaylist item);
    }
}
