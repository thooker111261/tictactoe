using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine(board.Display(true));
            string currentMark = "Y";
            do
            {
                bool validMark = false;
                currentMark = currentMark == "X" ? "Y" : "X";
                do
                {
                    Console.Write($"{currentMark}: ");
                    string coordinates = Console.ReadLine();

                    // Validate Input
                    if (coordinates.Length != 3 || coordinates.IndexOf(' ') == -1) continue;
                    if (int.TryParse(coordinates.Substring(0, coordinates.IndexOf(' ')),
                        out int x) == false ||
                        int.TryParse(coordinates.Substring(coordinates.IndexOf(' '), coordinates.Length - 1),
                        out int y) == false) continue;

                    validMark = board.TryToMarkBoard(y, x, currentMark);

                } while (!validMark);
                Console.WriteLine(board.Display());

            } while (board.Winner == string.Empty);

            Console.WriteLine();
            Console.WriteLine($"{board.Winner} Wins!");
            Console.ReadKey();
        }
    }
}
