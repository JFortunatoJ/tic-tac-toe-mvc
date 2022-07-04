using TicTacToe.Game.Board;
using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        private BoardController _board;
        private Player.Player _player1;
        private Player.Player _player2;
        private Player.Player _currentPlayer;

        private void Awake()
        {
            Instance = this;

            _board = FindObjectOfType<BoardController>();
        }

        private void Start()
        {
            _board.OnTapSlot = OnSlotTap;
            _board.InstantiateBoard();

            _player1 = new Player.Player(SlotModel.SlotSign.X);
            _player2 = new Player.Player(SlotModel.SlotSign.O);
            _currentPlayer = _player1;
        }

        private void ChangeCurrentPlayer()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }

        private void OnSlotTap(SlotController slot)
        {
            slot.Sign = _currentPlayer.sing;

            if (_board.CheckWinner() == SlotModel.SlotSign.None)
            {
                ChangeCurrentPlayer();
            }
            else
            {
                print("Acabou");
            }
        }

        /*
        [Inject]
        public void Construct(BoardView board)
        {
            _board = board;
        }
        */
    }
}