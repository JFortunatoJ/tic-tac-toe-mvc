using System.Collections;
using TicTacToe.Game.Board;
using TicTacToe.Game.Player;
using TicTacToe.GameOver;
using UnityEngine;
using Zenject;

namespace TicTacToe.Game
{
    public class GameController : MonoBehaviour
    {
        public PlayerController Player1 { get; private set; }
        public PlayerController Player2 { get; private set; }
        public  PlayerController CurrentPlayer { get; private set; }
        public BoardController Board { get; private set; }
        public bool GameOver { get; set; }
        
        
        private GameOverController _gameOverController;
        private WaitForSeconds _delayToRestart;
        
        /// <summary>
        /// Delay to show the game over panel.
        /// Used so the player can see the end result before the panel shows up.
        /// </summary>
        private WaitForSeconds _delayToGameOverPanel;
        
        [Inject]
        public void Construct(BoardController board, GameOverController gameOverController)
        {
            Board = board;
            _gameOverController = gameOverController;
        }

        private void Start()
        {
            _delayToRestart = new WaitForSeconds(.25f);
            _delayToGameOverPanel = new WaitForSeconds(1);
            
            Board.InstantiateBoard();
            
            PlayerFactory playerFactory = new PlayerFactory();
            Player1 = playerFactory.LoadHumanPlayer(this, SlotSign.X);
            Player2 = playerFactory.LoadAiPlayer(this, SlotSign.O);
            
            //If is PVP, just load another human player instead of AI Player
            //Player2 = playerFactory.LoadHumanPlayer(this, SlotSign.O);
            
            CurrentPlayer = Player1;
            CurrentPlayer.AllowPlay();
        }

        public void CheckWinner()
        {
            SlotSign winnerSign = Board.GetWinnerSign();
            if (winnerSign == SlotSign.Empty)
            {
                if (Board.AllSlotsWereFilled())
                {
                    OnGameOver(SlotSign.Empty);
                }
                else
                {
                    ChangeCurrentPlayer(); 
                }
            }
            else
            {
                OnGameOver(winnerSign);
            }
        }

        private void OnGameOver(SlotSign winnerSign)
        {
            StartCoroutine(GameOverCoroutine(winnerSign));
        }

        private IEnumerator GameOverCoroutine(SlotSign winnerSign)
        {
            GameOver = true;
            GameResult result;
            
            if (winnerSign == SlotSign.Empty)
            {
                result = GameResult.Tie;
            }
            else
            {
                result = winnerSign == Player1.model.Sing ? GameResult.Victory : GameResult.Defeat;
                PlayerController winner = GetPlayerBySign(winnerSign);
                winner.Win();
            }

            yield return _delayToGameOverPanel; 
            _gameOverController.ShowPanel(Player1.model.score,Player2.model.score, result);
        }

        public void RestartGame()
        {
            StartCoroutine(RestartGameCoroutine());
        }

        private IEnumerator RestartGameCoroutine()
        {
            yield return _delayToRestart;
            
            Board.ClearBoard();
            CurrentPlayer = Player1;
            CurrentPlayer.AllowPlay();
            GameOver = false;
        }
        
        private void ChangeCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            CurrentPlayer.AllowPlay();
        }

        public PlayerController GetPlayerBySign(SlotSign sign)
        {
            return sign == Player1.model.Sing ? Player1 : Player2;
        }
    }
}