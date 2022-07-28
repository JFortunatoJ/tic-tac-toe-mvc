using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.GameOver
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _resultText;
        [SerializeField]
        private TextMeshProUGUI _player1ScoreText;
        [SerializeField]
        private TextMeshProUGUI _player2ScoreText;
        [Space]
        public Button playAgainButton;
        public Button backMenuButton;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show(int player1Score, int player2Score, GameResult result)
        {
            _player1ScoreText.text = $"Player 1 Score: {player1Score}";
            _player2ScoreText.text = $"Player 2 Score: {player2Score}";

            switch (result)
            {
                case GameResult.Victory:
                    _resultText.text = "Victory!";
                    break;
                case GameResult.Defeat:
                    _resultText.text = "Defeat";
                    break;
                case GameResult.Tie:
                    _resultText.text = "Tie";
                    break;
            }
            
            Show();
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}