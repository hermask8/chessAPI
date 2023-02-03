using Microsoft.AspNetCore.Mvc;
using chessAPI.business.interfaces;
using chessAPI.models.player;
using chessAPI.models.game;
using Microsoft.AspNetCore.Authorization;


namespace chessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost]
        //Le indicamos el tipo de respuesta que enviará
        [Produces("application/json")]
        //Le indicamos el path que indicará en las peticiones
        [Route("PostPlayer")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> postPlayer(IPlayerBusiness<int> bs,clsNewPlayer newPlayer)
        {
            var result = Results.Ok(await bs.addPlayer(newPlayer));
            return Ok(result);
        }

        
        [HttpPost]
        [Produces("application/json")]
        [Route("PostGame")]
        [AllowAnonymous]
        public async Task<IActionResult> postGame(IGameBusiness<int> bss,clsNewGame newGame)
        {
            var result = Results.Ok(await bss.addGame(newGame));
            return Ok(result);
        }
        
    }
}

