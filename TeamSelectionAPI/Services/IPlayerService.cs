using TeamSelectionAPI.Models;

namespace TeamSelectionAPI.Services
{
    public interface IPlayerService
    {
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
        IEnumerable<Player> ListPlayers();
        TeamSelectionResponse SelectBestPlayer(TeamSelectionRequest request);
    }
}
