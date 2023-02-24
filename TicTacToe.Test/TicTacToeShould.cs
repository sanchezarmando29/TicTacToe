using TicTacToe.Enums;

namespace TicTacToe.Test
{
    public class TicTacToeShould
    {
        [Fact]
        public void ValdateValidPosition()
        {
            // Arrange
            TicTacToeGame TicTacToe= new TicTacToeGame();
            ResponseData responseData;

            // Act
            TicTacToe.StartGame();
            responseData = TicTacToe.Play(new Position(0,0));

            // Assert
            Assert.Equal(GameEvent.GoodPlayed, responseData.GameEvent);
        }


        [Fact]
        public void ValdateInValidPosition()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame();
            ResponseData responseData;

            // Act
            TicTacToe.StartGame();
            responseData = TicTacToe.Play(new Position(3, 0));

            // Assert
            Assert.Equal(GameEvent.InvalidPosition, responseData.GameEvent);
        }

        [Fact]
        public void ValdateUsedPosition()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame();
            ResponseData responseData;

            // Act
            TicTacToe.StartGame();
            TicTacToe.Play(new Position(0, 0));
            responseData = TicTacToe.Play(new Position(0, 0));

            // Assert
            Assert.Equal(GameEvent.UsedPosition, responseData.GameEvent);
        }


        [Fact]
        public void ValdateWin()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame();
            ResponseData responseData;

            // Act
            TicTacToe.StartGame();
            // -------X
            TicTacToe.Play(new Position(0, 0));
            // -------O
            TicTacToe.Play(new Position(0, 1));
            // -------X
            TicTacToe.Play(new Position(1, 0));
            // -------O
            TicTacToe.Play(new Position(1, 1));
            // -------X
            responseData= TicTacToe.Play(new Position(2, 0));

            // Assert
            Assert.Equal(GameEvent.Won, responseData.GameEvent);
        }
        [Fact]
        public void ValdateLock()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame();
            ResponseData responseData;

            // Act
            TicTacToe.StartGame();
            // -------X
            TicTacToe.Play(new Position(0, 0));
            // -------O
            TicTacToe.Play(new Position(2, 2));
            // -------X
            TicTacToe.Play(new Position(2, 1));
            // -------O
            TicTacToe.Play(new Position(1, 0));
            // -------X
            TicTacToe.Play(new Position(2, 0));
            // -------O
            TicTacToe.Play(new Position(0, 2));
            // -------X
            TicTacToe.Play(new Position(1, 2));
            // -------O
            TicTacToe.Play(new Position(1, 1));
            // -------X
            responseData= TicTacToe.Play(new Position(0, 1)); 

            // Assert
            Assert.Equal(GameEvent.Lock, responseData.GameEvent);
        }

        [Fact]
        public void ValdateCurrentPlayer()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame(); 

            // Act
            TicTacToe.StartGame();
            // -------X
            TicTacToe.Play(new Position(0, 0)); 
            
            // Assert
            Assert.Equal(Player.O, TicTacToe.Player);
        }

        [Fact]
        public void ValdateWinnerCount()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame(); 

            // Act
            TicTacToe.StartGame();
            // -------X
            TicTacToe.Play(new Position(0, 0));
            // -------O
            TicTacToe.Play(new Position(0, 1));
            // -------X
            TicTacToe.Play(new Position(1, 0));
            // -------O
            TicTacToe.Play(new Position(1, 1));
            // -------X
            TicTacToe.Play(new Position(2, 0));
            // Assert
            Assert.Equal(1, TicTacToe.XWins);
        }

        [Fact]
        public void ValdateResetStatusCount()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame();

            // Act
            TicTacToe.StartGame();
            // -------X
            TicTacToe.Play(new Position(0, 0));
            // -------O
            TicTacToe.Play(new Position(0, 1));
            // -------X
            TicTacToe.Play(new Position(1, 0));
            // -------O
            TicTacToe.Play(new Position(1, 1));
            // -------X
            TicTacToe.Play(new Position(2, 0));

            TicTacToe.StartGame();

            // Assert
            Assert.Equal(Status.InProgress, TicTacToe.Status);
        }

        [Fact]
        public void ValdateValidResetWinners()
        {
            // Arrange
            TicTacToeGame TicTacToe = new TicTacToeGame();

            // Act
            TicTacToe.StartGame();
            // -------X
            TicTacToe.Play(new Position(0, 0));
            // -------O
            TicTacToe.Play(new Position(0, 1));
            // -------X
            TicTacToe.Play(new Position(1, 0));
            // -------O
            TicTacToe.Play(new Position(1, 1));
            // -------X
            TicTacToe.Play(new Position(2, 0));

            TicTacToe.ResetWinners();

            // Assert
            Assert.NotEqual(1, TicTacToe.XWins);
        }
    }
}