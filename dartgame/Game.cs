using System;
using System.Collections.Generic;

namespace dartgame
{
    class Game : IGame
    {
        private List<Player> _players = new();

        public void PlayGame()
        {
            Console.WriteLine("\nWELCOME TO THE DART GAME !!");
            Console.WriteLine("\n---------------------------------\n");

            var numOfPlayers = 0;
            var validNumOfPlayers = new List<string>() { "1", "2", "3", "4"};

            // enter number of players
            do
            {
                Console.Write("Enter number of players (1-4): ");
                string input = Console.ReadLine();

                if (!validNumOfPlayers.Contains(input) || numOfPlayers.Equals(String.Empty))
                    Console.WriteLine("Invalid input.");
                else
                    numOfPlayers = int.Parse(input);

            } while (numOfPlayers < 1);

            Console.WriteLine("");

            // enter name of each player
            while (_players.Count < numOfPlayers)
            {
                Console.Write($"Enter player {_players.Count + 1}: ");
                var input = Console.ReadLine();

                if (input.Equals(String.Empty))
                    Console.WriteLine("Invalid input.");
                else
                    AddPlayer(input);
            }

            // if only one player is added, they play against the computer
            if (_players.Count < 2)
                _players.Add(new ComputerPlayer());

            var goal = 301;
            var totalScore = 0;

            // throw arrows until one player reaches at least 301 points
            while (totalScore < goal)
            {
                foreach (var player in _players)
                {
                    if (player.GetType() == typeof(ComputerPlayer))
                        player.AddTurn();
                    else
                    {
                        Console.WriteLine($"\n{player}'s turn");

                        var validInput = new List<string>()
                        {
                            "0",
                            "1",
                            "2",
                            "3",
                            "4",
                            "5",
                            "6",
                            "7",
                            "8",
                            "9",
                            "10",
                            "11",
                            "12",
                            "13",
                            "14",
                            "15",
                            "16",
                            "17",
                            "18",
                            "19",
                            "20"
                        };

                        var throws = new int[3];

                        for (var i = 0; i < throws.Length;)
                        {
                            Console.Write($"Throw {i + 1}: ");
                            string input = Console.ReadLine();

                            if (!validInput.Contains(input) || input.Equals(String.Empty))
                                Console.WriteLine("Not a valid number.");
                            else
                            {
                                throws[i] = int.Parse(input);
                                i++;
                            }
                        }

                        player.AddTurn(throws[0], throws[1], throws[2]);
                    }
                    
                    totalScore = player.CalculatePoints();
                    Console.WriteLine($"{player}'S TOTAL SCORE: {totalScore}");

                    if (totalScore >= goal)
                        break;
                }
            }

            PrintGame();
        }

        public void AddPlayer(string name)
        {
            _players.Add(new HumanPlayer(name));
        }

        private void PrintGame()
        {
            var winner = _players[0];

            foreach (var player in _players)
            {
                if (winner.CalculatePoints() < player.CalculatePoints())
                    winner = player;
            }

            Console.WriteLine("\n---------------------------------\n");
            Console.WriteLine($"GAME OVER");

            foreach (var player in _players)
            {
                Console.WriteLine("\n---------------------------------\n");
                Console.WriteLine(player);
                player.PrintTurns();
                Console.WriteLine($"TOTAL SCORE: {player.CalculatePoints()}");
            }

            Console.WriteLine("\n---------------------------------\n");
            Console.WriteLine($"THE WINNER IS {winner} !!");
            Console.WriteLine("\n---------------------------------\n");
            Console.ReadLine();
        }
    }
}
