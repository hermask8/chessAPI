using Microsoft.AspNetCore.Mvc;
using chessAPI.business.interfaces;
//using chessAPI.models.player;
using chessAPI.models.game;
using Microsoft.AspNetCore.Authorization;


namespace chessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameBusiness bs;
        //private readonly clsNewPlayer newPlayer;

        public GameController(IGameBusiness bs)
        {
            this.bs = bs;
            //this.newPlayer = newPlayer; 
        }
        /*
        [HttpPost]
        //Le indicamos el tipo de respuesta que enviará
        [Produces("application/json")]
        //Le indicamos el path que indicará en las peticiones
        [Route("PostPlayer")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> postPlayer(clsNewPlayer newPlayer)
        {
            var result = Results.Ok(await bs.addPlayer(newPlayer));
            return Ok(result);
        }
        */
              
        [HttpPost]
        [Produces("application/json")]
        [Route("PostGame")]
        [AllowAnonymous]
        public async Task<IActionResult> postGame(clsNewGame newGame)
        {
            await bs.startGame(newGame).ConfigureAwait(false);
            return Ok();
        }

        /*

        [HttpGet]
        [Produces("application/json")]
        [Route("GetGames")]
        [AllowAnonymous]
        public async Task<IActionResult> getGames()
        {
            var result = Results.Ok(await bs.)
            return Ok();
        }
        
        */
    }
}