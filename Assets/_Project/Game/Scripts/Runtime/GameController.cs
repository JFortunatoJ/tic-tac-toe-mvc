using TicTacToe.Game.Board;
using TicTacToe.Game.Player;
using TicTacToe.Game.Slot;
using UnityEngine;
using Zenject;

namespace TicTacToe.Game
{
    public class GameController : MonoBehaviour
    { 
        private BoardController _board;
        
        private PlayerController _player1;
        private PlayerController _player2;
        public  PlayerController CurrentPlayer { get; private set; }

        [Inject]
        public void Construct(BoardController board)
        {
            _board = board;
        }

        private void Start()
        {
            _board.InstantiateBoard();

            _player1 = new PlayerFactory().LoadHumanPlayer(this, SlotModel.SlotSign.X);
            _player2 = new PlayerFactory().LoadAiPlayer(this, SlotModel.SlotSign.O);
            
            CurrentPlayer = _player1;
            CurrentPlayer.AllowPlay();
        }

        public void CheckWinner()
        {
            if (_board.GetWinnerSign() == SlotModel.SlotSign.None)
            {
                if (_board.AllSlotsWereFilled())
                {
                    //TODO: Tie
                }
                else
                {
                    //ChangeCurrentPlayer(); 
                }
            }
            else
            {
                print("Acabou");
            }
        }

        private void ChangeCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
            CurrentPlayer.AllowPlay();
        }
    }
}