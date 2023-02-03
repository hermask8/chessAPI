namespace chessAPI.models.game;

public sealed class clsNewGame
{
    public clsNewGame()
    {
        started = "";
        whites = 0;
        blacks = 0;
        turn = false;
        winner = 0;
    }

    public string started { get; set; }
    public int whites { get; set; }
    public int blacks { get; set; }
    public bool turn { get; set; }
    public int winner { get; set; }
}