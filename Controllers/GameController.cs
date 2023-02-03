using Microsoft.AspNetCore.Mvc;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using chessAPI;
using chessAPI.business.interfaces;
using chessAPI.models.player;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Events;

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
        [Route("getGame")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> getGame(IPlayerBusiness<int> bs,clsNewPlayer newPlayer)
        {
            var x = Results.Ok(await bs.addPlayer(newPlayer));
            return Ok(x);
        }
    }
}

