using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public enum Symbole
    {
        Blank,
        Cross,
        Circle,
        Draw
    }

    public class Move
    {
        public Symbole Symbole { get; set; }
        public Tuple<int, int> Position { get; set; }
    }

    public delegate bool UserActionDelegate(Symbole symbole);

    public class TicTacToe
    {
        private Move[,] moves = new Move[3, 3];
        public void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    moves.SetValue(new Move { Symbole = Symbole.Blank, Position = new Tuple<int, int>(i, j) }, i, j);
                }
            }
        }
        private void RenderBoard(Move[,] moves)
        {
            for (int row = 0; row < 11; row++)
            {
                for (int col = 0; col < 11; col++)
                {
                    if (col == 3 || col == 7)
                    {
                        Console.Write("|");
                    }
                    else if (row == 3 || row == 7)
                    {
                        Console.Write("---");
                    }
                    else
                    {
                        var cellPosition = GetCellPosition(GetRenderPosition(row, col));
                        if(cellPosition == null)
                            Console.Write("   ");
                        else
                        {
                            var value = (Move)moves.GetValue(cellPosition.Item1, cellPosition.Item2);
                            Console.Write(" {0} ", value.Symbole == Symbole.Cross ? "X": value.Symbole == Symbole.Circle ? "O": Convert.ToString(GetRenderPosition(row, col)));
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private int GetRenderPosition(int x, int y)
        {
            if (x == 1 && y == 1)
                return 0;
            else if (x == 1 && y == 5)
                return 1;
            else if (x == 1 && y == 9)
                return 2;
            else if (x == 5 && y == 1)
                return 3;
            else if (x == 5 && y == 5)
                return 4;
            else if (x == 5 && y == 9)
                return 5;
            else if (x == 9 && y == 1)
                return 6;
            else if (x == 9 && y == 5)
                return 7;
            else if (x == 9 && y == 9)
                return 8;
            else
                return -1;
        }

        private Tuple<int, int> GetCellPosition(int i)
        {
            if (i == 0)
                return new Tuple<int, int>(0, 0);
            else if (i == 1)
                return new Tuple<int, int>(0, 1);
            else if (i == 2)
                return new Tuple<int, int>(0, 2);
            else if (i == 3)
                return new Tuple<int, int>(1, 0);
            else if (i == 4)
                return new Tuple<int, int>(1, 1);
            else if (i == 5)
                return new Tuple<int, int>(1, 2);
            else if (i == 6)
                return new Tuple<int, int>(2, 0);
            else if (i == 7)
                return new Tuple<int, int>(2, 1);
            else if (i == 8)
                return new Tuple<int, int>(2, 2);
            else
                return null;
        }

        public void Launcher()
        {
            ResetGame();
            int player = 1;
            bool finished = false;
            do
            {
                RenderBoard(moves);
                Console.Write("\nEnter available cell number for \"{0}\" : ", player % 2 == 0 ? 'O' : 'X');
                var pos = GetCellPosition(int.Parse(Console.ReadLine()));
                if (pos != null)
                {
                    var move = (Move)moves.GetValue(pos.Item1, pos.Item2);
                    if (move.Symbole == Symbole.Blank)
                    {
                        move.Symbole = player % 2 == 0 ? Symbole.Circle : Symbole.Cross;
                        finished = PlayMove(move, UserAction);
                        player++;
                    }
                    if (player > 9 && !finished)
                    {
                        player = 1;
                        finished = UserAction(Symbole.Draw);
                    }
                }
                Console.Clear();
            }
            while (!finished);
        }

        private bool PlayMove(Move move, UserActionDelegate userActionDelegate)
        {
            bool gameover = false;
            moves.SetValue(move, move.Position.Item1, move.Position.Item2);
            switch (CheckState())
            {
                case Symbole.Circle:
                    gameover = userActionDelegate(Symbole.Circle);
                    break;
                case Symbole.Cross:
                    gameover = userActionDelegate(Symbole.Cross);
                    break;
                default:
                    gameover = false;
                    break;
            }
            return gameover;
        }

        private bool UserAction(Symbole symbole)
        {
            Console.Clear();
            RenderBoard(moves);
            if (symbole == Symbole.Draw)
                Console.Write("\nmatch drawn. ");
            else
                Console.Write("\nPlayer '{0}' wins. ", symbole == Symbole.Circle ? 'O' : 'X');
            Console.Write("play again? [Y/N]: ");
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            if (keyinfo.Key == ConsoleKey.Y)
            {
                ResetGame();
                return false;
            }
            else if (keyinfo.Key == ConsoleKey.N)
            {
                return true;
            }
            else
            {
                return UserAction(symbole);
            }
        }

        private Symbole CheckState()
        {
            for (int i = 0, j = 0; i < 3 && j < 3; i++, j++)
            {
                if (moves[i, 0].Symbole == moves[i, 1].Symbole && moves[i, 1].Symbole == moves[i, 2].Symbole)
                {
                    return moves[i, 0].Symbole;
                }
                if (moves[0, j].Symbole == moves[1, j].Symbole && moves[1, j].Symbole == moves[2, j].Symbole)
                {
                    return moves[0, j].Symbole;
                }
            }
            if (moves[0, 0].Symbole == moves[1, 1].Symbole && moves[1, 1].Symbole == moves[2, 2].Symbole)
            {
                return moves[1, 1].Symbole;
            }
            if (moves[2, 0].Symbole == moves[1, 1].Symbole && moves[1, 1].Symbole == moves[0, 2].Symbole)
            {
                return moves[1, 1].Symbole;
            }
            return Symbole.Blank;
        }
    }
}
