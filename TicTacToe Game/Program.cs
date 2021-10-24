using System;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks.Sources;

namespace TicTacToe_Game
{
    class Program
    {
        static void DrawTicTacToeMatrix(string[,] matrix)
        {
            Console.WriteLine();
            Console.Write("      1   2   3 ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
                Console.WriteLine("     --- --- ---");
                if (i == 0)
                {
                    Console.Write("  a");
                }
                else if (i == 1)
                {
                    Console.Write("  b");
                }
                else Console.Write("  c");
                Console.Write(" | ");
                for (int j = 0; j < 3; j++)
                {
                    if (j == 1 || j == 2)
                    {
                        Console.Write(" | ");
                    }
                    if (matrix[i, j] == "")
                    {
                        Console.Write(" ");
                    }
                    else if (matrix[i, j] == "X")
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                    if (j == 2)
                    {
                        Console.Write(" | ");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("     --- --- ---");
            Console.WriteLine();
        }

        static string CheckWin(string[,] m)
        {
            string win = "noWin";
            if (m[0, 0] == m[0, 1] && m[0, 0] == m[0, 2] && m[0, 0] != "")
            {
                win = m[0, 0];
            }
            else if ((m[1, 0] == m[1, 1] && m[1, 0] == m[1, 2] && m[1, 0] != ""))
            {
                win = m[1, 0];
            }
            else if ((m[2, 0] == m[2, 1] && m[2, 0] == m[2, 2] && m[2, 0] != ""))
            {
                win = m[2, 0];
            }
            else if ((m[0, 0] == m[1, 1] && m[2, 2] == m[0, 0] && m[0, 0] != ""))
            {
                win = m[0, 0];
            }
            else if (m[0, 2] == m[1, 1] && m[0, 2] == m[2, 0] && m[0, 2] != "")
            {
                win = m[0, 2];
            }
            else if (m[0, 0] == m[1, 0] && m[0, 0] == m[2, 0] && m[0, 0] != "")
            {
                win = m[0, 0];
            }
            else if (m[0, 1] == m[1, 1] && m[0, 1] == m[2, 1] && m[0, 1] != "")
            {
                win = m[0, 1];
            }
            else if (m[0, 2] == m[1, 2] && m[0, 2] == m[2, 2] && m[0, 2] != "")
            {
                win = m[0, 2];
            }

            return win;
        }

        static void ClearTicTacToeMatrix(string[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = "";
                }
            }
        }
        static bool AvalibleMove(string[,] m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m[i, j] == "")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool validCoordinates(string xyCoordinates, string[,] matrix)
        {
            bool valid = true;
            string x = "";
            int y = -1;
            try
            {
                x = xyCoordinates.Substring(0, 1);
                y = int.Parse(xyCoordinates.Substring(1, 1));
            }
            catch
            {
                valid = false;
            }
            finally
            {
                if (y > 3 || y < 1)
                {
                    valid = false;
                }
                else if ((x == "a" || x == "b" || x == "c") == false)
                {
                    valid = false;
                }
                else if (x == "a")
                {
                    if (matrix[0, y - 1] != "")
                    {
                        valid = false;
                    }
                }
                else if (x == "b")
                {
                    if (matrix[1, y - 1] != "")
                    {
                        valid = false;
                    }
                }
                else if (x == "c")
                {
                    if (matrix[2, y - 1] != "")
                    {
                        valid = false;
                    }
                }
            }

            return valid;
        }
        static string chnagePlayerTurn(string value)
        {
            if (value == "X")
            {
                value = "O";
            }
            else
            {
                value = "X";
            }
            return value;
        }
        static int GetX(string xy)
        {
            int x = 1;

            if (xy.Substring(0, 1) == "a")
            {
                x = 0;
            }
            else if (xy.Substring(0, 1) == "b")
            {
                x = 1;

            }
            else if (xy.Substring(0, 1) == "c")
            {
                x = 2;

            }
            return x;
        }
        static int GetY(string xy)
        {
            int y = int.Parse(xy.Substring(1, 1)) - 1;
            return y;
        }
        static void PlayWinMusic()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125);
            Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125);
            Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125);
            Thread.Sleep(375);
            Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125);
            Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125);
            Thread.Sleep(125);
            Console.Beep(494, 125); Thread.Sleep(125);
            Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125);
            Console.Beep(392, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125);
            Console.Beep(880, 125);
            Thread.Sleep(125);
            Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(523, 125);
            Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125);
        }
        static void TwoPlayersGame(string[,] TicTacToe)
        {
            ClearTicTacToeMatrix(TicTacToe);
            Console.Clear();
            DrawTicTacToeMatrix(TicTacToe);
            string nextTurn = "X";
            Console.Beep(1000, 100);
            Console.Beep(1000, 100);

            while ((AvalibleMove(TicTacToe) == true))
            {
                if (CheckWin(TicTacToe) != "noWin")
                {
                    break;
                }

                Console.Clear();
                DrawTicTacToeMatrix(TicTacToe);

                Console.WriteLine($"Please enter coordinates for {nextTurn}!");

                string xy = Console.ReadLine();


                if (validCoordinates(xy, TicTacToe) == true)
                {
                    TicTacToe[GetX(xy), GetY(xy)] = nextTurn;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter valid coordinates!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.Beep(300, 400);
                    Console.Beep(100, 400);
                    Console.ReadKey();
                    //Skip changing Turns of players
                    continue;

                }
                //Change Turns
                nextTurn = chnagePlayerTurn(nextTurn);

            }
            Console.Clear();
            if (CheckWin(TicTacToe) == "noWin")
            {
                Console.WriteLine("==============================");
                Console.WriteLine("             DRAW!");
                Console.WriteLine("==============================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"  PLAYER {CheckWin(TicTacToe)} WON THE GAME!!!");
                Console.WriteLine("==============================");
            }
            DrawTicTacToeMatrix(TicTacToe);
            PlayWinMusic();
        }
        static void bestMoveByAI(string[,] m, string turn)
        {
            string xy = "";
            string bestMove = "-+-";
            string x = "";
            int score = int.MinValue;
            int bestScore = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    x = "a";
                }
                else if (i == 1)
                {
                    x = "b";
                }
                else
                {
                    x = "c";
                }
                for (int j = 1; j <= 3; j++)
                {
                    xy = x + j;
                    if (validCoordinates(xy, m))
                    {
                        m[GetX(xy), GetY(xy)] = turn;
                        score = minimax(m, 0, true);
                        m[GetX(xy), GetY(xy)] = "";
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove = xy;
                        }
                    }

                }
            }
            try
            {
                m[GetX(bestMove), GetY(bestMove)] = turn;
            }
            catch
            {

            }
            finally
            {
                string value = "AI move" + "  -" + bestMove + "-";
                Console.WriteLine(value);
                Thread.Sleep(700);
            }
        }
        static int minimax(string[,] m, int depth, bool maxin)
        {
            int score = 0;
            int bestscore = 0;
            string x = "";
            string xy = "";
            if (CheckWin(m) != "noWin")
            {
                return bestscore = int.MaxValue;
            }

            Random r = new Random();

            return r.Next(1, 345678);
        }
        static void PlayVsPC(string[,] TicTacToe)
        {
            ClearTicTacToeMatrix(TicTacToe);
            Console.Clear();
            DrawTicTacToeMatrix(TicTacToe);
            string nextTurn = "X";
            Console.Beep(1000, 100);
            Console.Beep(1000, 100);

            while ((AvalibleMove(TicTacToe) == true))
            {
                if (CheckWin(TicTacToe) != "noWin")
                {
                    break;
                }

                Console.Clear();
                DrawTicTacToeMatrix(TicTacToe);
                if (nextTurn == "X")
                {
                    bestMoveByAI(TicTacToe, nextTurn);
                    nextTurn = chnagePlayerTurn(nextTurn);
                    continue;
                }
                Console.WriteLine($"Please enter coordinates for {nextTurn}!");

                string xy = Console.ReadLine();


                if (validCoordinates(xy, TicTacToe) == true)
                {
                    TicTacToe[GetX(xy), GetY(xy)] = nextTurn;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter valid coordinates!");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.Beep(300, 400);
                    Console.Beep(100, 400);
                    Console.ReadKey();
                    //Skip changing Turns of players
                    continue;

                }
                //Change Turns
                nextTurn = chnagePlayerTurn(nextTurn);

            }
            Console.Clear();
            if (CheckWin(TicTacToe) == "noWin")
            {
                Console.WriteLine("==============================");
                Console.WriteLine("             DRAW!");
                Console.WriteLine("==============================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"  PLAYER {CheckWin(TicTacToe)} WON THE GAME!!!");
                Console.WriteLine("==============================");
            }
            DrawTicTacToeMatrix(TicTacToe);
            PlayWinMusic();
        }
        /// 
        ///  -------------------------------------------------------------------------------
        /// |                                                                               |
        /// |                                                                               |
        /// |                          HAVE FUN!!!!!!!!!!!!!!!!                             |
        /// |                          HAVE FUN!!!!!!!!!!!!!!!!                             |
        /// |                                                                               |                         
        /// |                                                                               |                         
        ///  -------------------------------------------------------------------------------
        /// 
        static void Main(string[] args)
        {
            string[,] TicTacToe =
            {
                { "O", "X", "" }, { "O", "X", "" }, { "O", "X", "" },
            };
            string answer = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("TicTacToe game is about to hit you? \n\n1. Multiplayer vs enemy or friend?\n2. Play vs computer\n3. Exit\n" +
                    "Type your choice 1, 2, 3 and press enter");
                answer = Console.ReadLine();

                if (answer == "1")
                {
                    TwoPlayersGame(TicTacToe);
                }
                else if (answer == "2")
                {
                    PlayVsPC(TicTacToe);
                }
                else if (answer == "3")
                {
                    Console.WriteLine("Чао, чао!");
                    break;
                }
            }
        }
    }
}
