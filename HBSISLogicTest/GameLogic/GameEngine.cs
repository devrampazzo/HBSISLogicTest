using HBSISLogicTest.GameLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBSISLogicTest.GameLogic
{
    public class GameEngine
    {
        private const int I_PLAYER = 0;
        private const int I_MOVE = 1;

        private string[] rps_game_calc(string[] playerMove1, string[] playerMove2)
        {
            var validMoves = new string[] { "R", "P", "S" };

            var playerMoves = new string[][] { playerMove1, playerMove2 };

            foreach(var playerMove in playerMoves)
            {
                if (!validMoves.Contains(playerMove[I_MOVE].ToUpper()))
                    throw new NoSuchStrategyError(playerMove[I_MOVE]);
            }

            if (playerMove1[I_MOVE].Equals(playerMove2[I_MOVE]))
                return playerMove1;

            string[] winner = null;

            if (playerMove1[I_MOVE].ToUpper().Equals("R"))
                winner = playerMove2[I_MOVE].ToUpper().Equals("P") ? playerMove2 : playerMove1;
            if (playerMove1[I_MOVE].Equals("P"))
                winner = playerMove2[I_MOVE].ToUpper().Equals("S") ? playerMove2 : playerMove1;
            if (playerMove1[I_MOVE].Equals("S"))
                winner = playerMove2[I_MOVE].ToUpper().Equals("R") ? playerMove2 : playerMove1;

            return winner;
        }

        public string[] rps_game_winner(string[][] game)
        {
            if (game.Length != 2)
                throw new WrongNumberOfPlayersError(game.Length);

            return rps_game_calc(game[0], game[1]);
        }

        public string[] rps_tournament_winner(string[][][] tournament)
        {
            List<string[][]> gameWinnersToNextRound = new List<string[][]>();
            
            for (int index = 0; index < tournament.Length && tournament.Length > 1 ; index = index + 2)
            {
                var game1 = tournament[index];
                var game2 = tournament[index + 1];

                var game1Winner = rps_game_winner(game1);
                var game2Winner = rps_game_winner(game2);

                var nextRoundGame = new string[][] { game1Winner, game2Winner };

                gameWinnersToNextRound.Add(nextRoundGame);
            }

            string[] tournamentWinner = null;

            if (gameWinnersToNextRound.Count > 1)
                return rps_tournament_winner(gameWinnersToNextRound.ToArray());

            return rps_game_winner(gameWinnersToNextRound.First());
        }
    }
}
