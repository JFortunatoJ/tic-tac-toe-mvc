using TicTacToe.Game.Slot;

namespace TicTacToe.Game.Player
{
    public class PlayerController : BaseController<PlayerModel>
    {
        protected GameController _gameController;

        public virtual void Construct(PlayerModel model, GameController gameController)
        {
            this.model = model;
            _gameController = gameController;
        }

        public virtual void AllowPlay()
        {
        }

        protected virtual void PlayerAction()
        {
        }

        public virtual void SelectSlot(SlotController slot)
        {
            if (_gameController.GameOver || !slot.CanInteractWithSlot()) return;
            
            _gameController.Board.SetSlotSignAtBoard(model.Sing, slot.Model.boardPosition);
            _gameController.CheckWinner();
        }

        public void Win()
        {
            model.score++;
        }

        protected bool MyTurn()
        {
            return _gameController.CurrentPlayer == this;
        }
    }
}