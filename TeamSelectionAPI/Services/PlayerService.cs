using TeamSelectionAPI.Models;

namespace TeamSelectionAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly List<Player> _players = new();

        public void AddPlayer(Player player)
        {
            player.Id = _players.Any() ? _players.Max(p => p.Id) + 1 : 1;
            _players.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            var existing = _players.FirstOrDefault(p => p.Id == player.Id);
            if (existing != null)
            {
                existing.Name = player.Name;
                existing.Position = player.Position;
                existing.Skills = player.Skills;
            }
        }

        public void DeletePlayer(int id) => _players.RemoveAll(p => p.Id == id);

        public IEnumerable<Player> ListPlayers() => _players;

        public TeamSelectionResponse SelectBestPlayer(TeamSelectionRequest request)
        {
            var bestPlayer = _players
                .Where(p => p.Position == request.Position && p.Skills.Any(s => s.Name == request.DesiredSkill))
                .Select(p => new
                {
                    Player = p,
                    SkillValue = p.Skills.First(s => s.Name == request.DesiredSkill).Value
                })
                .OrderByDescending(p => p.SkillValue)
                .FirstOrDefault();

            if (bestPlayer == null) return null;

            return new TeamSelectionResponse
            {
                Position = request.Position,
                PlayerName = bestPlayer.Player.Name,
                SkillValue = bestPlayer.SkillValue
            };
        }
    }
}
