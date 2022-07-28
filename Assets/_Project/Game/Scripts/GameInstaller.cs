using TicTacToe.Game.Board;
using TicTacToe.GameOver;
using TicTacToe.Settings;
using UnityEngine;
using Zenject;

namespace TicTacToe.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private GameController _gameController;
        [SerializeField]
        private BoardController _boardControler;
        [SerializeField]
        private GameOverController _gameOverController;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_gameController);
            Container.BindInstance(_boardControler);
            Container.BindInstance(_gameOverController);
        }
    }
}