using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.game;
using Dapper;

namespace chessAPI.dataAccess.repositores;

public sealed class clsGameRepository<TI, TC> : clsDataAccess<clsGameEntityModel<TI, TC>, TI, TC>, IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    public clsGameRepository(IRelationalContext<TC> rkm,
                               ISQLData queries,
                               ILogger<clsGameRepository<TI, TC>> logger) : base(rkm, queries, logger)
    {
    }

    public async Task<TI> addGame(clsNewGame game)
    {
        var p = new DynamicParameters();
        p.Add("STARTED", game.started);
        p.Add("WHITES",game.whites);
        p.Add("BLACKS",game.blacks);
        p.Add("TURN",game.turn);
        p.Add("WINNER",game.winner);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<IEnumerable<clsGameEntityModel<TI, TC>>> addGames(IEnumerable<clsNewGame> games)
    {
        var r = new List<clsGameEntityModel<TI, TC>>(games.Count());
        foreach (var game in games)
        {
            TI gameId = await addGame(game).ConfigureAwait(false);
            r.Add(new clsGameEntityModel<TI, TC>() { id = gameId, started = game.started, whites = game.whites, blacks = game.blacks, turn = game.turn, winner = game.winner });
        }
        return r;
    }

    public Task deleteGame(TI id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<clsGameEntityModel<TI, TC>>> getGamesByGame(TI gameId)
    {
        throw new NotImplementedException();
    }

    public Task updateGame(clsGame<TI> updatedGame)
    {
        throw new NotImplementedException();
    }

    protected override DynamicParameters fieldsAsParams(clsGameEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add("STARTED", entity.started);
        p.Add("WHITES",entity.whites);
        p.Add("BLACKS",entity.blacks);
        p.Add("TURN",entity.turn);
        p.Add("WINNER",entity.winner);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }
}