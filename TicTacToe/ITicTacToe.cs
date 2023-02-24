using TicTacToe.Enums;

namespace TicTacToe;

public interface ITicTacToe
{
    void StartGame();
    void ResetWinners();
    ResponseData Play(Position position);
    Status Status { get; set; }
    Player Player { get; set; }
    int XWins { get; set; }
    int OWins { get; set; }
    List<PositionHistory> GamePositionPlayed { get; set; }
    string[,] GameBoard { get; set; }

}