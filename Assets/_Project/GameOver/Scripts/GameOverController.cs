using System;
using TicTacToe.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TicTacToe.GameOver
{
    public class GameOverController : MonoBehaviour
    {
        private GameOverView _view;
        private GameController _gameController;

        [Inject]
        public void Construct(GameController gameController)
        {
            _gameController = gameController;
        }

        private void Awake()
        {
            _view = GetComponent<GameOverView>();
        }

        private void Start()
        {
            _view.playAgainButton.onClick.AddListener(OnRestartButtonClick);
            _view.backMenuButton.onClick.AddListener(BackToMenuButtonClick);
            
            _view.Hide();
        }
        
        public void ShowPanel(int player1Score, int player2Score, GameResult result)
        {
            _view.Show(player1Score, player2Score, result);
        }
        
        private void BackToMenuButtonClick()
        {
            SceneManager.LoadScene("StartMenu");
        }
        
        private void OnRestartButtonClick()
        {
            _view.Hide();
            _gameController.RestartGame();
        }
    }
}