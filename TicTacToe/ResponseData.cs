using TicTacToe.Enums;

namespace TicTacToe;

public class ResponseData
{

    public ResponseData(GameEvent gameEvent, string message)
    {
        GameEvent = gameEvent;
        Message = message;
    }

    public ResponseData(GameEvent gameEvent)
    {
        GameEvent = gameEvent;
    }

    public GameEvent GameEvent { get; set; }
    public string Message { get; set; }

}