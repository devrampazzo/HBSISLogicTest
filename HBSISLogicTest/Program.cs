using HBSISLogicTest.GameLogic;
using System;

namespace HBSISLogicTest
{
    class Program
    {
        private static GameEngine _game = new GameEngine();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var gameTest1 = new string[][] {
                new string[] { "Armando", "P" }, new string[] { "Dave", "S" }
            };
            var gameWinner1 = _game.rps_game_winner(gameTest1);

            Console.WriteLine($"Game 1 set: [{gameTest1[0][0]},{gameTest1[0][1]}], [{gameTest1[1][0]},{gameTest1[1][1]}]");
            Console.WriteLine($"Game 1, Winner: [{gameWinner1[0]},{gameWinner1[1]}]");

            var tournament = new string[][][]
            {
                gameTest1,
                new string[][] {
                    new string[] { "Richard", "R" }, new string[] { "Michael", "S" }
                },
                new string[][] {
                    new string[] { "Allen", "S" }, new string[] { "Omer", "P" }
                },
                new string[][] {
                    new string[] { "David E.", "R" }, new string[] { "Richard X.", "P" }
                }
            };

            var tournamentWinner1 = _game.rps_tournament_winner(tournament);

            Console.WriteLine($"Tournament 1, Winner: [{tournamentWinner1[0]},{tournamentWinner1[1]}]");
            Console.ReadKey();
        }
    }
}
