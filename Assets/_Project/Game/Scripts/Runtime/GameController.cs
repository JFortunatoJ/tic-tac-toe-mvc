using TicTacToe.Game.Board;
using TicTacToe.Game.Player;
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

        [Inject]
        public void Construct(BoardController board)
        {
            Board = board;
        }

        private void Start()
        {
            Board.InstantiateBoard();

            PlayerFactory playerFactory = new PlayerFactory();
            Player1 = playerFactory.LoadHumanPlayer(this, SlotSign.X);
            //Player2 = playerFactory.LoadHumanPlayer(this, SlotSign.O);
            Player2 = playerFactory.LoadAiPlayer(this, SlotSign.O);
            
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
                    print("Empate");
                }
                else
                {
                    ChangeCurrentPlayer(); 
                }
            }
            else
            {
                print($"O {winnerSign} venceu!");
            }
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