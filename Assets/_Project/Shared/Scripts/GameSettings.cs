using UnityEngine;

namespace TicTacToe.Settings
{
    public static class GameSettings
    {
        public enum DifficultyEnum
        {
            Easy = 0,
            Medium = 5,
            Hard = 10
        }

        private static readonly string DIFFICULTY_KEY = "DIFFICULTY";

        public static DifficultyEnum Difficulty
        {
            get => (DifficultyEnum)PlayerPrefs.GetInt(DIFFICULTY_KEY);
            set => PlayerPrefs.SetInt(DIFFICULTY_KEY, (int)value);
        }
    }
}