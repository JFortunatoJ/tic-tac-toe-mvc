using System.Collections.Generic;
using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Player
{
    public class AIController : PlayerController
    {
        private SlotSign[,] _boardGrid;

        private Dictionary<SlotSign, int> _scores;

        public override void Construct(PlayerModel model, GameController gameController)
        {
            base.Construct(model, gameController);

            //Caching the board grid;
            _boardGrid = _gameController.Board.Model.boardGrid;

            _scores = new Dictionary<SlotSign, int>
            {
                { SlotSign.O, 1 },
                { SlotSign.X, -1 },
                { SlotSign.Empty, 0 }
            };
        }

        public override void AllowPlay()
        {
            PlayerAction();
        }

        protected override void PlayerAction()
        {
            SelectSlot(GetBestMove());
        }

        private SlotController GetBestMove()
        {
            int bestScore = int.MinValue;
            (int, int) bestMove = (-1, -1);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_boardGrid[i, j] != SlotSign.Empty) continue;

                    _boardGrid[i, j] = model.Sing;
                    int score = Minimax(0, false);
                    _boardGrid[i, j] = SlotSign.Empty;
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = (i, j);
                    }
                }
            }

            return _gameController.Board.GetSlotByPosition(new Vector2Int(bestMove.Item1, bestMove.Item2));
        }

        private int Minimax(int depth, bool isMaximizing)
        {
            SlotSign winnerSign = _gameController.Board.GetWinnerSign();
            if (winnerSign != SlotSign.Empty)
            {
                return _scores[winnerSign];
            }

            if (_gameController.Board.AllSlotsWereFilled())
            {
                return _scores[SlotSign.Empty];
            }

            if (isMaximizing)
            {
                int bestScore = int.MinValue;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_boardGrid[i, j] != SlotSign.Empty) continue;

                        _boardGrid[i, j] = model.Sing;
                        int score = Minimax(depth + 1, false);
                        _boardGrid[i, j] = SlotSign.Empty;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }

                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_boardGrid[i, j] != SlotSign.Empty) continue;

                        _boardGrid[i, j] = _gameController.Player1.model.Sing;
                        int score = Minimax(depth + 1, true);
                        _boardGrid[i, j] = SlotSign.Empty;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }

                return bestScore;
            }
        }
    }
}