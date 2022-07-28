using System;
using TicTacToe.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe.StartMenu
{
    public class StartMenuController : MonoBehaviour
    {
        private StartMenuView _view;

        private void Awake()
        {
            _view = GetComponent<StartMenuView>();
            
            _view.startGameButton.onClick.AddListener(OnStartMenuButtonClick);
            _view.difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
        }

        private void Start()
        {
            _view.difficultyDropdown.value = (int)GameSettings.Difficulty;
        }

        private void OnStartMenuButtonClick()
        {
            SceneManager.LoadScene("Game");
        }
        
        private void OnDifficultyChanged(int value)
        {
            GameSettings.Difficulty = (GameSettings.DifficultyEnum)value;
        }
    }
}