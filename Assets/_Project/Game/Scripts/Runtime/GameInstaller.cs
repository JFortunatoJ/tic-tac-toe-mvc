using TicTacToe.Game.Board;
using Zenject;

namespace TicTacToe.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(FindObjectOfType<GameController>());
            Container.BindInstance(FindObjectOfType<BoardController>());
        }
    }
}