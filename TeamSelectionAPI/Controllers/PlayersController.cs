using Microsoft.AspNetCore.Mvc;
using TeamSelectionAPI.Models;
using TeamSelectionAPI.Services;

namespace TeamSelectionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("add")]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            _playerService.AddPlayer(player);
            return Ok("Player added.");
        }

        [HttpPut("update")]
        public IActionResult UpdatePlayer([FromBody] Player player)
        {
            _playerService.UpdatePlayer(player);
            return Ok("Player updated.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            _playerService.DeletePlayer(id);
            return Ok("Player deleted.");
        }

        [HttpGet("list")]
        public IActionResult ListPlayers()
        {
            var players = _playerService.ListPlayers();
            return Ok(players);
        }

        [HttpPost("select")]
        public IActionResult SelectBestPlayer([FromBody] TeamSelectionRequest request)
        {
            var response = _playerService.SelectBestPlayer(request);
            return response == null ? NotFound("No suitable player found.") : Ok(response);
        }
    }
}
