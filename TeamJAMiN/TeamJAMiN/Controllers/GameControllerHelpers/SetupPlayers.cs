﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeamJAMiN.Controllers.GameLogicHelpers;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public static class SetupPlayers
    {
        public static void setupPlayers(this Game newGame)
        {
            newGame.assignColors();
            foreach (Player player in newGame.Players)
            {
                player.GetNewAssistant();
                player.GetNewAssistant();
                player.GalleristLocation = PlayerLocation.Gallery;
            }
            newGame.PlayerOrder = newGame.Players.Shuffle().ToList();
        }
        public static void assignColors(this Game newGame)
        {
            var rPlayers = newGame.Players.Shuffle();
            var colorEnum = ((PlayerColor[])Enum.GetValues(typeof(PlayerColor))).Shuffle().GetEnumerator(); ;
            foreach (Player player in rPlayers)
            {
                colorEnum.MoveNext();
                if (colorEnum.Current == PlayerColor.none)
                {
                    colorEnum.MoveNext();
                }
                player.Color = (PlayerColor)colorEnum.Current;
            }
        }

        public static void UpdatePlayerOrder(this Game game)
        {
            var currentPlayer = game.PlayerOrder.First();
            game.CurrentPlayerId = currentPlayer.Id;
            if(game.Players.Count != 1) //todo add logic for kicked out or executive actions
            {
                var isRemoved = game.PlayerOrder.Remove(currentPlayer);
                game.PlayerOrder.Add(currentPlayer);
                game.PlayerOrder = game.PlayerOrder;
            }
        }
    }
}