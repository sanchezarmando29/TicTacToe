using TicTacToe.Enums;

namespace TicTacToe
{
    public class PositionHistory
    {
        public PositionHistory(Position position, int playedOrder, Player player)
        {
            Position = position;
            PlayedOrder = playedOrder;
            Player = player;
        }

        public Position Position { get; set; }
        public int PlayedOrder { get; set; }
        public Player  Player { get; set; }
    }
}