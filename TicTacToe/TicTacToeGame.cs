using TicTacToe.Enums;

namespace TicTacToe;

public class TicTacToeGame: ITicTacToe
{
    public string[,] GameBoard { get; set; }
    public  Status Status { get; set; }
    public  Player Player { get; set; }
    public int XWins { get; set; }
    public int OWins { get; set; }
    public List<PositionHistory> GamePositionPlayed { get; set; }
    public int _movements { get; set; }

    private readonly Position[,] _winnersPosition;

    public TicTacToeGame()
    {
        _winnersPosition = new Position[8, 3] {
            { new Position(0, 0), new Position(0, 1) , new Position(0, 2) },
            { new Position(0, 0), new Position(1, 1) , new Position(2, 2) },
            { new Position(0, 0), new Position(1, 0) , new Position(2, 0) },
            { new Position(0, 1), new Position(1, 1) , new Position(2, 1) },
            { new Position(0, 2), new Position(1, 1) , new Position(2, 0) },
            { new Position(0, 2), new Position(1, 2) , new Position(2, 2) },
            { new Position(1, 0), new Position(1, 1) , new Position(1, 2) },
            { new Position(2, 0), new Position(2, 1) , new Position(2, 2) },
        };
        GamePositionPlayed = new List<PositionHistory>();
        GameBoard = new string[3, 3];

        StartGame();
   
    }

    public void StartGame()
    {
        _movements = 0;
        Player = Player.X;
        Status = Status.InProgress;
        GamePositionPlayed.Clear();

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                GameBoard[x, y] = "0";
            }
        }
    }

    public void ResetWinners()
    {
        XWins= 0;
        OWins= 0;
    }

    public ResponseData Play(Position position)
    {
        if ((position.X >= 3 || position.X < 0) || (position.Y >= 3 || position.Y < 0))
        {
            return new ResponseData(GameEvent.InvalidPosition, "Invalid Position.");
        } 

        if (GameBoard[position.X, position.Y] != "0")
        {
            return new ResponseData(GameEvent.UsedPosition, "This Position are played.");
        }
        
        _movements++;

        GameBoard[position.X, position.Y] = Player.ToString();

        GamePositionPlayed.Add(new PositionHistory(new Position(position.X, position.Y),_movements,Player));

        if (checkWinner() == GameEvent.Won)
        {
            XWins = Player == Player.X ? XWins += 1 : XWins;

            OWins = Player == Player.O ? OWins += 1 :OWins;

            Status = Status.Won;

            return new ResponseData(GameEvent.Won, $"The Player {Player.ToString()} won.");
        }  

        if (_movements == 9)
        {
            Status = Status.Lock;

            return new ResponseData(GameEvent.Lock, "The Game is Locked.");
        }

        return new ResponseData(GameEvent.GoodPlayed);
    }

    private GameEvent checkWinner()
    {
        for (int x = 0; x < 8; x++)
        {

            if (GameBoard[_winnersPosition[x, 0].X, _winnersPosition[x, 0].Y] == "0")
            {
                continue;
            }

            if ((GameBoard[_winnersPosition[x, 0].X, _winnersPosition[x, 0].Y] == GameBoard[_winnersPosition[x, 1].X, _winnersPosition[x, 1].Y]) && (GameBoard[_winnersPosition[x, 0].X, _winnersPosition[x, 0].Y] == GameBoard[_winnersPosition[x, 2].X, _winnersPosition[x, 2].Y]))
            {
                return GameEvent.Won;
            }

        }

        Player = (Player == Player.X) ? Player.O : Player.X;

        return GameEvent.GoodPlayed;
    }
}