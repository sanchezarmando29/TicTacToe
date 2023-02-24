using TicTacToe;
using TicTacToe.Enums;

namespace TicTacToeConsole;

public class GameLoop
{
    private readonly ITicTacToe _ticTacToe;
    private bool exit;
    public GameLoop(ITicTacToe ticTacToe)
    {
        _ticTacToe = ticTacToe;
        exit = false;
    }

    public void Execute()
    {
        _ticTacToe.StartGame();

        while(!exit)
        {
            PrincipalMenu();
        }
      


    }

    private void PrincipalMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tTicTacToe Game");
            Console.WriteLine("1 - Start Game");
            Console.WriteLine("2 - Reset Winners");
            Console.WriteLine("3 - Show Winners");
            Console.WriteLine("4 - Exit Game");
            Console.Write("Enter the Option:");

            int option = Convert.ToInt32(Console.ReadLine());

            if (option>4 || option<1)
            {
               
                Console.WriteLine("Invalid Option press any key for continue.");
                Console.ReadKey();
            }
            else if (option==1)
            {
                NewGame();
            }
            else if (option == 2)
            {
                _ticTacToe.ResetWinners();
            }
            else if (option == 3)
            {
                ShowWinnerHistory();
            }
            else if (option == 4)
            {
                exit = true;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Option press any key for continue.");
            Console.ReadKey();
        } 
    }
    private void NewGame()
    {
        _ticTacToe.StartGame();

        while (_ticTacToe.Status == Status.InProgress)
        {
            Console.Clear();
            PrintBoard();
            EnterGamePositions();
        }
    }
    private void EnterGamePositions()
    {
        try
        {
            Console.WriteLine("Enter the X Position");
            int x =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Y Position");
            int y = Convert.ToInt32(Console.ReadLine());

            ResponseData responseData= _ticTacToe.Play(new Position(x, y));

            if (responseData.GameEvent == GameEvent.InvalidPosition || responseData.GameEvent == GameEvent.UsedPosition)
            {
                Console.WriteLine(responseData.Message);
                Console.WriteLine("...press any key for continue.");
                Console.ReadKey();
            }
            else if (responseData.GameEvent == GameEvent.Won || responseData.GameEvent == GameEvent.Lock)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("");

                GameResume();

                Console.WriteLine(responseData.Message);
                Console.WriteLine("1 - New Game");
                Console.WriteLine("Press any key for Go To Main Menu.");

                Console.Write("Enter the Option:");
                //TODO: Show the resume Game.
                string option= Console.ReadLine();
            
                if (option== "1")
                {
                    NewGame();
                } 
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Option press any key for continue.");
            Console.ReadKey();
        }

    }
    private void ShowWinnerHistory()
    {
        Console.WriteLine($"X has {_ticTacToe.XWins} Won");
        Console.WriteLine($"O has {_ticTacToe.OWins} Won");
        Console.WriteLine("");
        Console.WriteLine("Press any key for Go To Main Menu.");
        Console.ReadKey();
       
    }
    private void GameResume()
    {
        Console.WriteLine("Game Resume");

        foreach (PositionHistory position in _ticTacToe.GamePositionPlayed.OrderBy(c=>c.PlayedOrder))
        {
            Console.WriteLine($"Player: {position.Player} - Position: {position.Position.X},{position.Position.Y} - Order: {position.PlayedOrder}");
        }
        Console.WriteLine("");
    }
    private void PrintBoard()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Console.Write(" "+_ticTacToe.GameBoard[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Current Player: " + _ticTacToe.Player);
        Console.WriteLine();
    }

}
